using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float MoveSpeed = 1.5f;
    public GameObject PlayerDragon;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
            RotatePlayerOnYAxis(270);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right);
            RotatePlayerOnYAxis(90);

        }
        if (Input.GetKey(KeyCode.W))
        {
            Move(Vector3.forward);
            RotatePlayerOnYAxis(0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(Vector3.back);
            RotatePlayerOnYAxis(180);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            RotatePlayerOnYAxis(45);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            RotatePlayerOnYAxis(135);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            RotatePlayerOnYAxis(315);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            RotatePlayerOnYAxis(225);
        }
    }

    private void RotatePlayerOnYAxis(float degrees)
    {
        PlayerDragon.transform.localRotation = Quaternion.Euler(0, degrees, 0);
    }

    private void Move(Vector3 direction)
    {
        transform.Translate(MoveSpeed * Time.deltaTime * direction);

    }
}
