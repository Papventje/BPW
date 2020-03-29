using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssembleTurret : MonoBehaviour
{
    [SerializeField]
    private GameObject buildText, notEnoughPartsText;

    [SerializeField]
    private GameObject preBuilt, built;

    [SerializeField]
    private GameObject particle, bullet;

    [SerializeField]
    private Transform particlePosition;

    private UIHandler canvasHandler;

    bool turretBuilt = false;
    bool turretSound = false;

    private void Start()
    {
        built.SetActive(false);
        buildText.SetActive(false);
        notEnoughPartsText.SetActive(false);

        canvasHandler = GameObject.Find("Canvas").GetComponent<UIHandler>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && canvasHandler.partsPickedUp >= 30)
            buildText.SetActive(true);

        if (other.gameObject.tag == "Player" && canvasHandler.partsPickedUp < 30)
            notEnoughPartsText.SetActive(true);

        if (!turretBuilt)
        {
            if (Input.GetKeyDown(KeyCode.E) && canvasHandler.partsPickedUp >= 30)
            {
                preBuilt.SetActive(false);

                Instantiate(particle, particlePosition.position, particlePosition.rotation);

                built.SetActive(true);
                turretBuilt = true;
                turretSound = true;
                canvasHandler.timer = false;
            }
        }
        if (turretBuilt)
        {
            buildText.GetComponent<Text>().text = "Launcher Complete!";
            if (turretSound)
            {
                StartCoroutine(LaunchTurret());
                turretSound = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            buildText.SetActive(false);
            notEnoughPartsText.SetActive(false);
        }
    }

    IEnumerator LaunchTurret()
    {
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(1.5f);

        GameObject go = Instantiate(bullet, particlePosition.position, particlePosition.rotation);
        go.transform.Rotate(-90, 0, 0);

        yield return new WaitForSeconds(10f);

        canvasHandler.EndScreen(2);

    }
}
