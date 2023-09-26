using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _target;

    void Update()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        transform.Translate(_speed * Time.deltaTime * direction);
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
