using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [Header("Player Objects")]
    [SerializeField]
    private GameObject playerObj, gunObj;

    [SerializeField]
    private Transform gunPosition, target;

    [Header("Player Cam")]
    [SerializeField]
    private Camera cam;

    [Header("UI Properties")]
    [SerializeField]
    private GameObject timer, health, crosshair, deathScreen;

    private void Start()
    {
        timer = GameObject.Find("Timer");
        health = GameObject.Find("HealthBar");
        crosshair = GameObject.Find("Crosshair");
        deathScreen = GameObject.Find("DeathScreen");

        OnDeath();
    }

    private void Update()
    {
        Vector3 targetDir = target.position - cam.transform.position;
        cam.transform.rotation = Quaternion.RotateTowards(cam.transform.rotation, Quaternion.LookRotation(targetDir), 2f);
    }

    void OnDeath()
    {
        timer.SetActive(false); 
        health.SetActive(false);
        crosshair.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        GameObject goPlayer = Instantiate(playerObj, transform.position, transform.rotation);
        GameObject goPistol = Instantiate(gunObj, gunPosition.position, gunPosition.rotation);

        goPlayer.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
        goPistol.GetComponent<Rigidbody>().AddForce(transform.forward * 500);

        target = goPlayer.transform;

        StartCoroutine(DeathScreen());
    }

    IEnumerator DeathScreen()
    {
        yield return new WaitForSeconds(2f);

        deathScreen.GetComponent<Animator>().Play("DeathScreenAwake");

        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene(0);
    }
}
