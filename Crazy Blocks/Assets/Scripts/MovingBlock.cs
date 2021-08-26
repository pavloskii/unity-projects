using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3f;
    private float startingYPosition;
    public static int Score;
    public static int HighScore;

    void Start()
    {
        startingYPosition = transform.position.y;    
    }

    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * moveSpeed;

        if (transform.position.x <= -15)
        {
            transform.position += Vector3.right * 30f;
            float newY = startingYPosition + UnityEngine.Random.Range(-1f, 1f);
            transform.position = new Vector3(transform.position.x, newY, 0f);
            Score++;

            if (Score > HighScore)
            {
                HighScore = Score;
            }
        }
    }
}
