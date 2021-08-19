using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public AudioSource CollectFx;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectFx.Play();
            GlobalCoins.CointCount += 1;
            gameObject.SetActive(false);
        }
    }
}
