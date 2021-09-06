using UnityEngine;
using Cinemachine;
using StarterAssets;
using System;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField]
    private float normalSensitivity;
    [SerializeField]
    private float aimSensitivity;
    [SerializeField]
    private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField]
    private Transform debugTransform;
    [SerializeField]
    private Transform bulletProjectile;
    [SerializeField]
    private Transform spawnBulletPosition;

    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;

    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        Vector3 mousePosition = GetAimTargetPosition();
        
        ToggleAim(starterAssetsInputs.aim, mousePosition);

        if (starterAssetsInputs.shoot)
        {
            Shoot(mousePosition);
        }
    }

    private void Shoot(Vector3 mousePosition)
    {
        Vector3 aimDirection = (mousePosition - spawnBulletPosition.position).normalized;
        Instantiate(bulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDirection, Vector3.up));
        starterAssetsInputs.shoot = false;
    }

    private void ToggleAim(bool aim, Vector3 mousePosition)
    {
        if (aim)
        {
            //face towards the aim on aim mode
            Vector3 worldAimTarget = mousePosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        }

        //set aim camera to active (has priority over normal)
        aimVirtualCamera.gameObject.SetActive(aim);
        //Set different sensitivity in aim and normal
        thirdPersonController.SetSensitivity(aim ? aimSensitivity : normalSensitivity);
        //rotate character face while not aiming
        thirdPersonController.SetRotateOnMove(!aim);
    }

    private Vector3 GetAimTargetPosition()
    {
        //get center of the screen
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            return raycastHit.point;
        }
        //this can be used for not putting collider walls
        //mouseWorldPosition = ray.GetPoint(10)
        //return default of zero if a point can not be found
        return Vector3.zero;
    }
}
