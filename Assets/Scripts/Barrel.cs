using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private TextMeshPro healthText;
    [SerializeField] private float forceValue;

    private void Start()
    {
        healthText.text = health.ToString();
    }

    public void DecreaseHealth()
    {
        health--;
        healthText.text = health.ToString();
        if (health <= 0)
        {
            DestoryItself();
        }
    }

    private void DestoryItself()
    {
        GameManager.instance.SpawnExplosionEffect(transform);
        Vibration.Vibrate(100);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.FinishTheGame();
            // finish the game
        }
        else if (other.CompareTag("BulletSpawner"))
        {
            PistolController.instance.RemoveSpawnerBullet(other.GetComponent<BulletSpawner>());
            List<Transform> meshes = other.GetComponent<BulletSpawner>().meshList;
            foreach (Transform mesh in meshes)
            {
                mesh.SetParent(null);
                CubeCut.Cut(mesh.transform);
            }
        }
    }
}