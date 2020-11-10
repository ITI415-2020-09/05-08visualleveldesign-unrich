using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class Count : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    private int count;
    public TextMeshProUGUI CountText;
    public GameObject WinText;
    public GameObject FailText;
    public TextMeshProUGUI TimerText;
    public AudioMixerSnapshot BackGroundSnapshot;
    public AudioMixerSnapshot InteriorsSnapshot;

    // Start is called before the first frame update
    void Start()
    {
        SetCountText();
        WinText.SetActive(false);
        FailText.SetActive(false);
        count = 0;
        timerIsRunning = true;
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void SetCountText()
    {
        CountText.text = "Count: " + count.ToString();
        if(count >= 12)
        {
            WinText.SetActive(true);
        }
    }
    void SetFailText()
    {
        FailText.GetComponent<Text>().text = "You get " + count + "/12 Pickups." + " If you did not get all Pickups and Time runs out, then you lose. Otherwish, you win.";
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUP"))
        {
            Destroy(other.gameObject);
            //other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (other.CompareTag("InteriorsZone"))
        {
            InteriorsSnapshot.TransitionTo(0.5f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("InteriorsZone"))
        {
            BackGroundSnapshot.TransitionTo(0.5f);
        }
    }

    void Update()
    {
        SetFailText();
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            timeRemaining = 0;
            timerIsRunning = false;
        }
        if(timeRemaining == 0)
        {
            FailText.SetActive(true);
        }
    }
}
