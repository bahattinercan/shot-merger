using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolController : MonoBehaviour
{
    public static PistolController instance;
    public List<BulletSpawner> bulletSpawners = new List<BulletSpawner>();
    public List<Transform> bulletSpawnPositions = new List<Transform>();
    [SerializeField] private Transform baseBulletSpawnPoint;
    [SerializeField] private int bulletPerSec;
    [SerializeField] private Transform bulletPrefab;
    private RaycastHit hit;
    [SerializeField] private LayerMask bulletSpawnerLayer;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(SpawnBullet(bulletPerSec, baseBulletSpawnPoint));
    }

    public void AddSpawnerBullet(BulletSpawner bulletSpawner)
    {
        switch (bulletSpawner.spawnerType)
        {
            case BulletSpawnerType.plus:
                bulletPerSec += bulletSpawner.spawnIncreaseValue;
                break;

            case BulletSpawnerType.multiply:
                bulletPerSec *= bulletSpawner.spawnIncreaseValue;
                break;

            default:
                Debug.LogError("Not added to PistolController/AddSpawnerBullet ");
                break;
        }
        GameManager.instance.UpdateBulletPerSecText(bulletPerSec);
        bulletSpawners.Add(bulletSpawner);
        StopAllCoroutines();
        StartSpawnBullet();
    }

    public void RemoveSpawnerBullet(BulletSpawner bulletSpawner)
    {
        switch (bulletSpawner.spawnerType)
        {
            case BulletSpawnerType.plus:
                bulletPerSec -= bulletSpawner.spawnIncreaseValue;
                break;

            case BulletSpawnerType.multiply:
                bulletPerSec /= bulletSpawner.spawnIncreaseValue;
                break;

            default:
                Debug.LogError("Not added to PistolController/RemoveSpawnerBullet ");
                break;
        }
        GameManager.instance.UpdateBulletPerSecText(bulletPerSec);
        bulletSpawners.Remove(bulletSpawner);
        StopAllCoroutines();
        StartSpawnBullet();
    }

    private void StartSpawnBullet()
    {
        List<Transform> bulletPositions = new List<Transform>();

        foreach (BulletSpawner spawner in bulletSpawners)
        {
            foreach (Transform bulletT in spawner.spawnPositions)
            {
                if (CheckCanSpawn(bulletT))
                {
                    bulletPositions.Add(bulletT);
                }
            }
        }

        if (bulletPositions.Count != 0)
        {
            float bulletPerSecForEachSpawner = bulletPerSec / (bulletPositions.Count);
            foreach (Transform bulletPos in bulletPositions)
            {
                StartCoroutine(SpawnBullet(bulletPerSecForEachSpawner, bulletPos));
            }
        }
        else
        {
            StartCoroutine(SpawnBullet(bulletPerSec, baseBulletSpawnPoint));
        }
    }

    private IEnumerator SpawnBullet(float bulletPerSec, Transform spawnT)
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / bulletPerSec);
            Instantiate(bulletPrefab, spawnT.position, Quaternion.identity);
        }
    }

    private bool CheckCanSpawn(Transform t)
    {
        if (Physics.Raycast(t.position, Vector3.forward, out hit, 20, bulletSpawnerLayer))
        {
            if (hit.collider.GetComponent<BulletSpawner>().IsAdded == true)
                return false;
            else
                return true;
        }
        else
        {
            return true;
        }
    }
}