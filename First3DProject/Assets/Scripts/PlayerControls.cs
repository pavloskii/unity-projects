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
            transform.Translate(MoveSpeed * Time.deltaTime * Vector3.left);
            PlayerDragon.transform.localRotation = Quaternion.Euler(0, 270, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(MoveSpeed * Time.deltaTime * Vector3.right);
            PlayerDragon.transform.localRotation = Quaternion.Euler(0, 90, 0);

        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(MoveSpeed * Time.deltaTime * Vector3.forward);
            PlayerDragon.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(MoveSpeed * Time.deltaTime * Vector3.back);
            PlayerDragon.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            PlayerDragon.transform.localRotation = Quaternion.Euler(0, 45, 0);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            PlayerDragon.transform.localRotation = Quaternion.Euler(0, 135, 0);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            PlayerDragon.transform.localRotation = Quaternion.Euler(0, 315, 0);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            PlayerDragon.transform.localRotation = Quaternion.Euler(0, 225, 0);
        }
    }
}
