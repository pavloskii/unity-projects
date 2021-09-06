using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    [SerializeField]
    public Transform vfxHitGreen;
    [SerializeField]
    public Transform vfxHitRed;

    public Rigidbody bulletRigidbody;
    public const float Speed = 40f;

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        bulletRigidbody.velocity = transform.forward * Speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        //TODO: check for more optimal condition (tag or type)
        MarkTargetOnHit(other.GetComponent<BulletTarget>() != null);
        Destroy(gameObject);
    }

    private void MarkTargetOnHit(bool isHit)
    {
        Instantiate(isHit ? vfxHitGreen : vfxHitRed, transform.position, Quaternion.identity);
    }
}
