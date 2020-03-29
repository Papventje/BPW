using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject hatch;

    [SerializeField]
    private GameObject player;

    private bool pressedOnce = true;

    void Launch(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().isKinematic = false;

        obj.GetComponent<Rigidbody>().AddForce(transform.up * 300);
        obj.GetComponent<Rigidbody>().AddForce(-transform.forward * 400);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && pressedOnce)
        {
            StartCoroutine(Eject());
            pressedOnce = false;
        }
    }

    IEnumerator Eject()
    {
        Launch(hatch);

        yield return new WaitForSeconds(1f);

        Launch(player);

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(1);
    }
}
