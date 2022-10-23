using System.Collections.Generic;
using UnityEngine;

public enum BulletSpawnerType
{
    plus,
    multiply
}

public class BulletSpawner : MonoBehaviour
{
    private bool isAddedToPistol = false;
    public List<Transform> spawnPositions;
    public List<Transform> meshList;
    public BulletSpawnerType spawnerType;
    public int spawnIncreaseValue;

    public bool IsAdded
    {
        get { return isAddedToPistol; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isAddedToPistol == false)
        {
            isAddedToPistol = true;
            // hiç bullet spawner eklenmemiþse çalýþýr
            if (PistolController.instance.bulletSpawners.Count == 0)
            {
                AddToThePlayer(other);
            }
            // bullet spawner eklenmiþse listenin sonundaki bulletspawnerin en yakýn noktasýndaki transforma eklenir
            else
            {
                AddToTheLastBulletSpawner();
            }
            PistolController.instance.AddSpawnerBullet(this);
        }

        else if (other.CompareTag("BulletSpawner") && isAddedToPistol == false)
        {
            isAddedToPistol = true;

            AddToTheLastBulletSpawner();
            PistolController.instance.AddSpawnerBullet(this);
        }
    }

    private void AddToThePlayer(Collider other)
    {
        Vector3 pos = new Vector3(other.transform.position.x + -.25f, other.transform.position.y, other.transform.position.z + .75f);
        transform.position = pos;
        transform.SetParent(GameManager.instance.playerT);
    }

    private void AddToTheLastBulletSpawner()
    {
        BulletSpawner bulletSpawner = PistolController.instance.bulletSpawners[PistolController.instance.bulletSpawners.Count - 1];
        Vector3 pos = Vector3.zero;
        Transform parentT = bulletSpawner.spawnPositions[0];
        float distance = 999f;
        foreach (Transform spawnT in bulletSpawner.spawnPositions)
        {
            float newDistance = Vector3.Distance(transform.position, spawnT.position);
            if (distance > newDistance)
            {
                distance = newDistance;
                pos = spawnT.position;
                parentT = spawnT;
            }
        }
        transform.position = pos + new Vector3(0, 0, .5f);
        transform.SetParent(GameManager.instance.playerT);
    }
}