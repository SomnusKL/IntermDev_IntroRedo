using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float moveSpeed = 5;
    public Rigidbody2D rb;
    public Animator animator;
    private static Vector3 _position;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
