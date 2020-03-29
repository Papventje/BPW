using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    private GameObject canvas;

    [SerializeField]
    private AudioClip clip;

    private void Update()
    {
        transform.Rotate(0, 1, 0);
    }

    private void Start()
    {
        canvas = GameObject.Find("Canvas");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(clip, transform.position, .2f);
            canvas.GetComponent<UIHandler>().partsPickedUp++;
            Destroy(gameObject);
        }
    }
}
