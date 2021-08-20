using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    public int RotateSpeed = 1;

    void Update()
    {
        transform.Rotate(0, RotateSpeed * Time.timeScale, 0, Space.World);
    }
}
