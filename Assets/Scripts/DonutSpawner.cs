using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class DonutSpawner : MonoBehaviour
{
    [SerializeField] private Donut _prefab;
    [SerializeField] private int _poolCapacity = 8;
    [SerializeField] private int _poolMaxSize = 8;
    [SerializeField] private Transform[] _spawnPoints;

    private ObjectPool<Donut> _pool;
    private int _currentSpawnPointIndex = 0;

    private void Awake()
    {
        _pool = new ObjectPool<Donut>
        (
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (donut) => GetDonutFromPool(donut),
            actionOnRelease: (donut) => donut.gameObject.SetActive(false),
            actionOnDestroy: (donut) => Destroy(donut.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize
        );
    }

    private void Start()
    {
        StartCoroutine(nameof(SpawnDonuts));
    }

    private IEnumerator SpawnDonuts()
    {
        while(_currentSpawnPointIndex < _poolCapacity && _currentSpawnPointIndex < _spawnPoints.Length)
        {
            SpawnDonut();
            _currentSpawnPointIndex++;

            yield return null; 
        }
    }

    private void SpawnDonut()
    {
        _pool.Get();
    }

    private void GetDonutFromPool(Donut _prefab)
    {
        _prefab.transform.position = _spawnPoints[_currentSpawnPointIndex].position;
        _prefab.gameObject.SetActive(true);
        _prefab.OnReturnToPool += ReturnDonutToPool;
    }

    private void ReturnDonutToPool(Donut donut)
    {
        donut.OnReturnToPool -= ReturnDonutToPool;
        _pool.Release(donut);
    }
}
