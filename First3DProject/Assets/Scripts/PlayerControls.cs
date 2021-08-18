using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float MoveSpeed = 1.5f;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(MoveSpeed * Time.deltaTime * Vector3.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(MoveSpeed * Time.deltaTime * Vector3.right);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(MoveSpeed * Time.deltaTime * Vector3.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(MoveSpeed * Time.deltaTime * Vector3.back);
        }
    }
}
