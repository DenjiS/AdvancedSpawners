using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private Transform _spawnedTarget;
    [SerializeField] private Color _color;
    [SerializeField] private float _timeBetweenSpawns;

    private WaitForSeconds _delay;

    private Coroutine _spawning;

    private void OnValidate()
    {
        foreach (ParticleSystem particles in GetComponentsInChildren<ParticleSystem>())
        {
            ParticleSystem.MainModule mainModule = particles.main;
            mainModule.startColor = _color;
        }
    }

    private void Awake()
    {
        _delay = new WaitForSeconds(_timeBetweenSpawns);
    }

    private void Update()
    {
        _spawning ??= StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        yield return _delay;

        Spawn();

        _spawning = null;
    }

    private void Spawn()
    {
        if (_pool.TryGetObject(out GameObject result))
        {
            ConfigureSpawned(result);
            result.SetActive(true);
        }
    }

    private void ConfigureSpawned(GameObject spawned)
    {
        spawned.transform.position = transform.position;

        if (spawned.TryGetComponent(out Enemy enemy))
            enemy.Init(_spawnedTarget, _color);
    }
}
