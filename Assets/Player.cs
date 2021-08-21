using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody rb;

    [SerializeField]
    private float JumpPower = 800;
    [SerializeField]
    private float MoveSpeed = 10;

    Animator anim;

    private bool Grounded;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.TransformDirection(Vector3.forward * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.TransformDirection(Vector3.back * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -5, 0));    
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 5, 0));
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isRunning", true);
        }

        else
        {
            anim.SetBool("isRunning", false);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Grounded == true)
        {
            rb.AddForce(Vector3.up * JumpPower);
        }
    }
}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Grounded = true;
        }

        if (collision.gameObject.tag == "MoveFloor")// もし、触れた物のタグがMoveFloorなら
        {
            Grounded = true;// Groundedをtrueにする
            transform.SetParent(collision.transform);// 触れた物の子オブジェクトにする
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Grounded = false;
        }

        if (collision.gameObject.tag == "MoveFloor")// もし、離れた物のタグがMoveFloorなら、
        {
            Grounded = false;//  Groundedをfalseにする
            transform.SetParent(null);// 離れた物との親子関係を解除する
        }
    }
}