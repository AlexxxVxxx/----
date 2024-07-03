using UnityEngine;
public class Ball : MonoBehaviour
{

    public Rigidbody2D rigidbody2D;
    public float ballSpeed = 5f;
    public Vector2 lastVelocity;
    public bool isBallActive = false;
    public bool goal = false;
    public Score Score;
    public Movement firstPlayerBoard;
    public Movement secondPlayerBoard;

    public void BallMovement()
    {
        rigidbody2D.velocity = Vector3.zero;
        rigidbody2D.isKinematic = true;
        transform.position = Vector3.zero;
        rigidbody2D.isKinematic = false;

        rigidbody2D.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * 5f;
        lastVelocity = rigidbody2D.velocity;
    }

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }



    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            BallMovement();
            firstPlayerBoard.defaultSpeed = 2;
            secondPlayerBoard.defaultSpeed = 2;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigidbody2D.velocity = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
        lastVelocity = rigidbody2D.velocity * 1.1f;
        firstPlayerBoard.speed *= 1.1f;
        secondPlayerBoard.speed *= 1.1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.position.x > 0)
        {
            Debug.Log("Left player scored");
            Score.IncrementFirstUserScore();
            Debug.Log(Score.firstUserScore);
            goal = true;
        }
        if (transform.position.x < 0)
        {
            Debug.Log("Right player scored");
            Score.IncrementSecondUserScore();
            goal = true;
        }

    }

}
