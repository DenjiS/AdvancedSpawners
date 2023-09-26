using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private readonly List<GameObject> _pool = new();

    private void Awake()
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject instance = Instantiate(_template, _container.transform);

            instance.SetActive(false);

            _pool.Add(instance);
        }
    }

    public bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(result => result.activeSelf == false);

        return result != null;
    }
}
