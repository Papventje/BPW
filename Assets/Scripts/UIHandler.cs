using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    [SerializeField]
    private Text timerText, pickupText;

    [SerializeField]
    private float timeLeft;

    private float minutes;
    private float seconds;

    public int partsPickedUp;

    public bool timer;

    private void Start()
    {
        timer = true;
    }

    private void Update()
    {
        Timer();

        pickupText.text = "Parts \n" + partsPickedUp + "/30";
    }

    void Timer()
    {
        if (timer)
            timeLeft -= Time.deltaTime;

        minutes = Mathf.Floor(timeLeft / 60);
        seconds = timeLeft % 60;
        if (seconds > 59)
            seconds = 59;

        if (minutes < 0)
        {
            minutes = 0;
            seconds = 0;
        }

        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);

        if(timeLeft < 0)
        {
            EndScreen(3);
        }
    }

    public void EndScreen(int index)
    {
        SceneManager.LoadScene(index);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
