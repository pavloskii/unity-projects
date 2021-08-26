using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Vector2 jumpVelocity;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GetComponent<Rigidbody2D>().velocity = jumpVelocity;
        }
    }
}
