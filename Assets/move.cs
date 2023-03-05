using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    public float moveSpeed = 5;
    public Rigidbody2D rb;
    public Animator animator;
    private static Vector3 _position;
    private float distance1;
    private float distance2;
    public GameObject npc1;
    public GameObject npc2;
    public float dialogueOffset = 2.0f;
    
     public GameObject dialogue;
     private bool haveKey;
     
     
     public static string[] dialogLines = new string[3]
     {
         "I think I dropped the key somewhere east of here",
         "Great. My friend will tell you how to escape this place",
         "The exit is north of here, hidden behind a tree."
     };

    // Start is called before the first frame update
    void Start()
    {
        dialogue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * (moveSpeed * Time.deltaTime);
            animator.SetFloat("vertical",0);
            animator.SetFloat("horizontal",1);
           
            animator.SetFloat("speed", moveSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.right * (-moveSpeed * Time.deltaTime);
            animator.SetFloat("vertical",0);
            animator.SetFloat("horizontal",-1);
            
            animator.SetFloat("speed", moveSpeed);

        }

        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * (moveSpeed * Time.deltaTime);
            animator.SetFloat("horizontal",0);
            animator.SetFloat("vertical",1);
            
            animator.SetFloat("speed", moveSpeed);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.up * (-moveSpeed * Time.deltaTime);
            animator.SetFloat("horizontal",0);
            animator.SetFloat("vertical",-1);
           
            animator.SetFloat("speed", moveSpeed);

        }
        else
        {
            animator.SetFloat("horizontal",0);
            animator.SetFloat("vertical",0);
            animator.SetFloat("speed",0);
        }
       
        _position = transform.position;
        
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);

        if (other.gameObject.name == "key")
        {
            haveKey = true;
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.name == "door" && haveKey)
        {
            Destroy(other.gameObject);
        }

    
        if (other.gameObject.name == "npc1")
        {
            if (haveKey)
            {
                // get key
               
                dialogue.SetActive(true);
                dialogue.GetComponentInChildren<TextMeshProUGUI>().text = dialogLines[1];
              
            }

            else
            {
                // not get key
                
                dialogue.SetActive(true);
                dialogue.GetComponentInChildren<TextMeshProUGUI>().text = dialogLines[0];
               
            }
        }
        if (other.gameObject.name == "npc2")
        {
           
            dialogue.SetActive(true);
            dialogue.GetComponentInChildren<TextMeshProUGUI>().text = dialogLines[2];
        }
        
        if (other.gameObject.name == "exit")
        {
            dialogue.SetActive(false);
            SceneManager.LoadScene("GameEnd");
        }
        
    }

    
    
    public static Vector2 Target()
        {
            return _position;
            
        }
        
}
