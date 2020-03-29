using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    public GameObject cube;

    [SerializeField]
    private float spawnerMinRangeX;

    [SerializeField]
    private float spawnerMaxRangeX;

    [SerializeField]
    private float spawnerMinRangeY;

    [SerializeField]
    private float spawnerMaxRangeY;

    [SerializeField]
    private float spawnerMinRangeZ;

    [SerializeField]
    private float spawnerMaxRangeZ;

    [SerializeField]
    private float spawnTimer;

    [SerializeField]
    private Vector3 startRotation;


    private void Start()
    {
        InvokeRepeating("SpawnObjects", spawnTimer, spawnTimer);
    }

    void SpawnObjects()
    {
        Vector3 position = new Vector3(Random.Range(spawnerMinRangeX, spawnerMaxRangeX), Random.Range(spawnerMinRangeY, spawnerMaxRangeY), Random.Range(spawnerMinRangeZ, spawnerMaxRangeZ));
        Debug.Log(position);
        GameObject obj = Instantiate(cube, position, gameObject.transform.rotation);
        //obj.transform.parent = transform;
        obj.transform.Rotate(startRotation);
    }
}
