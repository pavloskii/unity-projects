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
    private Transform bulletProjectile;
    [SerializeField]
    private Transform spawnBulletPosition;
    [SerializeField]
    public Transform vfxHitGreen;
    [SerializeField]
    public Transform vfxHitRed;

    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;
    private Animator animator;

    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var targetTuple = GetAimTargetTransfromAndPosition();

        ToggleAim(starterAssetsInputs.aim, targetTuple.Item2);

        if (starterAssetsInputs.shoot)
        {
            Shoot(targetTuple.Item1);
        }
    }

    private void Shoot(Transform target)
    {
        if (target != null)
        {
            MarkTargetOnHit(target);
        }
        //Vector3 aimDirection = (mousePosition - spawnBulletPosition.position).normalized;
        //Instantiate(bulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDirection, Vector3.up));
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
        
        //set Aiming layer animation with index 1 to 1 or 0 depending if it is aiming or not
        animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), aim ? 1f : 0f, Time.deltaTime * 10f));
        //set aim camera to active (has priority over normal)
        aimVirtualCamera.gameObject.SetActive(aim);
        //Set different sensitivity in aim and normal
        thirdPersonController.SetSensitivity(aim ? aimSensitivity : normalSensitivity);
        //rotate character face while not aiming
        thirdPersonController.SetRotateOnMove(!aim);
    }

    //Used for shooting hitscan method
    private Tuple<Transform, Vector3> GetAimTargetTransfromAndPosition()
    {
        Transform hitTransform = null;
        Vector3 mouseWorldPosition = Vector3.zero;

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            hitTransform = raycastHit.transform;
            mouseWorldPosition = raycastHit.point;
        }

        return new Tuple<Transform, Vector3>(hitTransform, mouseWorldPosition);
    }

    private void MarkTargetOnHit(Transform target)
    {
        var isHit = target.GetComponent<BulletTarget>() != null;

        Instantiate(isHit ? vfxHitGreen : vfxHitRed, target.position, Quaternion.identity);
    }
}
