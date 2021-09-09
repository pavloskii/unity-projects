using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed =20.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //Move forward base on vertical input up/down
        transform.Translate(speed * Time.deltaTime * forwardInput * Vector3.forward);
        //Rotate the car base on horizontal input lefrt/right
        transform.Rotate(horizontalInput * Time.deltaTime * turnSpeed * Vector3.up);
    }
}
