using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        print("Hey");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody2D.velocity = Vector2.up;
    }
        else if (Input.GetKey(KeyCode.S))
        {
            rigidbody2D.velocity = Vector2.down;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rigidbody2D.velocity = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody2D.velocity = Vector2.right;
        }
        else
        {
            rigidbody2D.velocity = Vector2.zero;
        }


    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

}
