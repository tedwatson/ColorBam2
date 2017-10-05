using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour {

	public GameObject gunModel;
	public GameObject bullet;
    public GameObject bulletSpawnPoint;
    public Material[] materials;

    private Renderer rend;

    public void fireGun()
    {
        // instantiate a new bullet at the spawn point and give it the same color
        Instantiate(bullet, bulletSpawnPoint.transform.position, transform.rotation).GetComponent<Renderer>().material = rend.material;
        Material m = rend.material;
        while (m.color == rend.material.color)
        {
            m = getRandomMaterial();
        }
        rend.material = m;
    }

    private void Start()
    {
        rend = gunModel.GetComponent<Renderer>();

        // Start with a random color
        rend.material = getRandomMaterial();
    }

    private Material getRandomMaterial()
    {
        // Pick a random material from the array
        return materials[Random.Range(0, materials.Length)];
    }
}
