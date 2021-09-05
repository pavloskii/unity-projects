using UnityEngine;
using Cinemachine;
using StarterAssets;
using System;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera aimVirtualCamera;

    private StarterAssetsInputs starterAssetsInputs;

    private void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        ToggleAim(starterAssetsInputs.aim);
    }

    private void ToggleAim(bool aim)
    {
        aimVirtualCamera.gameObject.SetActive(aim);
    }
}
