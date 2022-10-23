using System.Collections.Generic;
using UnityEngine;

public enum BulletSpawnerType
{
    plus,
    multiply
}

public class BulletSpawner : MonoBehaviour
{
    private bool isAdded = false;
    public List<Transform> spawnPositions;
    public BulletSpawnerType spawnerType;
    public int spawnIncreaseValue;
    public bool IsAdded
    {
        get { return isAdded; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isAdded == false)
        {
            isAdded = true;

            Vector3 pos = new Vector3(other.transform.position.x + -.25f, other.transform.position.y, other.transform.position.z + .75f);
            transform.position = pos;
            transform.SetParent(GameManager.instance.playerT);

            PistolController.instance.AddSpawnerBullet(this);
        }
        else if (other.CompareTag("BulletSpawner") && isAdded == false)
        {
            isAdded = true;

            BulletSpawner bulletSpawner = other.GetComponent<BulletSpawner>();
            Vector3 pos = Vector3.zero;
            float distance = 999f;
            foreach (Transform spawnT in bulletSpawner.spawnPositions)
            {
                float newDistance = Vector3.Distance(transform.position, spawnT.position);
                if (distance > newDistance)
                {
                    distance = newDistance;
                    pos = spawnT.position;
                }
            }
            transform.position = pos + new Vector3(0, 0, .5f);
            transform.SetParent(GameManager.instance.playerT);

            PistolController.instance.AddSpawnerBullet(this);
        }
    }
}