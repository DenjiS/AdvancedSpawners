using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _secondsBeforeDie;

    private EnemyMovement _movement;
    private WaitForSeconds _deathDelay;

    private void Awake()
    {
        _movement = GetComponent<EnemyMovement>();
        _deathDelay = new WaitForSeconds(_secondsBeforeDie);
    }

    private void OnEnable()
    {
        StartCoroutine(Dying());
    }

    public void Init(Transform target, Color color)
    {
        _movement.SetTarget(target);

        gameObject
            .GetComponent<MeshRenderer>()
            .material
            .color = color;
    }

    private IEnumerator Dying()
    {
        yield return _deathDelay;

        gameObject.SetActive(false);
    }
}
