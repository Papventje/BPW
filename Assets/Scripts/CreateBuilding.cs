using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreateBuilding : MonoBehaviour
{
    private int x, y, z;

    private int startingPoint = 0;

    [SerializeField]
    private NavMeshSurface surface;

    [SerializeField]
    private int buildingCount;
    [SerializeField]
    private int buildingOffset;
    [SerializeField]
    private int maxBuildLength;
    [SerializeField]
    private int buildingPartHeight;


    public GameObject obj;

    private void Start()
    {
        for (int i = 0; i < buildingCount; i++)
        {
            for (int j = 0; j < Random.Range(3, 6); j++)
            {
                GameObject go = Instantiate(obj, new Vector3(x, y, z), gameObject.transform.rotation) as GameObject;
                go.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                go.transform.parent = transform;
                y += buildingPartHeight;
            }
            y = 0;
            x += buildingOffset;
            if (x >= maxBuildLength) {
                z += buildingOffset;
                x = 0;
            }
        }

        surface.BuildNavMesh();
    }
}
