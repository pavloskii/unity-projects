using UnityEngine;

//Hybrid shooting method: Hitscan with trail renderer //WIP not used
public class BulletProjectileRayCast : MonoBehaviour
{
    [SerializeField]
    public Transform vfxHitGreen;
    [SerializeField]
    public Transform vfxHitRed;

    private Vector3 _targetPosition;

    public void Setup(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
    }

    private void Update()
    {
        float distanceBefore = Vector3.Distance(transform.position, _targetPosition);

        Vector3 moveDirection = (_targetPosition - transform.position).normalized;
        float moveSpeed = 200f;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        float distanceAfter = Vector3.Distance(transform.position, _targetPosition);

        if (distanceBefore < distanceAfter)
        {
            Instantiate(vfxHitRed, _targetPosition, Quaternion.identity);
            transform.Find("Trail").SetParent(null);
            Destroy(gameObject);
        }
    }
}
