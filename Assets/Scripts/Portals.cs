using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> portals = new List<GameObject>();

    [SerializeField]
    private GameObject obj;

    [SerializeField]
    private float respawnTime;

    private void Start()
    {
        foreach(Transform child in transform)
        {
            portals.Add(child.gameObject);
        }

        InvokeRepeating("Spawn", respawnTime, respawnTime);
    }

    void Spawn()
    {
        GameObject currentPortal = portals[Random.Range(0, portals.Count)];
        GameObject go = Instantiate(obj, currentPortal.transform.position, currentPortal.transform.rotation);
        go.GetComponent<Rigidbody>().AddForce(currentPortal.transform.forward * 300);
    }
}
