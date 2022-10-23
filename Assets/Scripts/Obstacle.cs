using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float forceValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().AddForce(0, 0, forceValue, ForceMode.Impulse);
        }   
        else if (other.CompareTag("BulletSpawner"))
        {
            other.GetComponent<Rigidbody>().AddForce(0, 0, forceValue, ForceMode.Impulse);
            PistolController.instance.RemoveSpawnerBullet(other.GetComponent<BulletSpawner>());
            List<Transform> meshes = other.GetComponent<BulletSpawner>().meshList;
            foreach (Transform mesh in meshes)
            {
                mesh.SetParent(null);
                CubeCut.Cut(mesh.transform, transform.position);
            }
            
        }

    }
}