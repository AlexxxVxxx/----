using UnityEngine;

public class Movement : MonoBehaviour
{

    public Rigidbody2D rigidBody2d;

    public float speed = 2;

    public KeyCode UpKey;
    public KeyCode DownKey;


    private void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(UpKey) && transform.position.y < 4)
        {
            rigidBody2d.velocity = Vector2.up * speed;
        }
        else if (Input.GetKey(DownKey) && transform.position.y > -4)
        {
            rigidBody2d.velocity = Vector2.down * speed;
        }
        else
        {
            rigidBody2d.velocity = Vector2.zero;
        }
    }
}
