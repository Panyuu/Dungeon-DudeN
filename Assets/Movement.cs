using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public ItemList items;
    private Vector3 target;

    public float speed;
    float xOffset = 0f, yOffset = 0f;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        items = new ItemList();
    }

    // Update is called once per frame
    void Update()
    {/*
        xOffset = Input.GetAxisRaw("Horizontal") * speed;
        yOffset = Input.GetAxisRaw("Vertical") * speed;
        animator.SetFloat("mspeed", Mathf.Abs(xOffset) + Mathf.Abs(yOffset));
        Debug.Log(animator.GetFloat("mspeed"));
       */

        if (Input.GetMouseButtonDown(1))
        {
            items.print();
        }

            if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }
        float lx = transform.position.x, ly = transform.position.y;
        //Debug.Log(transform.position.x + " " + transform.position.y);
        //transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        controller.move(transform.position.x, transform.position.y, target, speed);
        if (transform.position.x == lx && transform.position.y == ly)
        {
            animator.SetBool("swap", false);
        }
        else
            animator.SetBool("swap", true);
       

    }
    
    private void FixedUpdate()
    {
        //controller.Move(xOffset * Time.fixedDeltaTime, yOffset * Time.fixedDeltaTime, false, false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("N collided!");
        if (collision.gameObject.name == "Item")
        {
            items.Add(new Item(collision.gameObject.name));
            Destroy(collision.gameObject);
        }
    }
}
