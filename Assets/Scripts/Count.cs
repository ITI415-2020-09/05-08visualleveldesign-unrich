using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Count : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    private int count;
    public TextMeshProUGUI CountText;
    public GameObject WinTextObject;
    public GameObject FailTextObject;
    public TextMeshProUGUI TimerText;

    // Start is called before the first frame update
    void Start()
    {
        SetCountText();
        WinTextObject.SetActive(false);
        FailTextObject.SetActive(false);
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
            WinTextObject.SetActive(true);
        }
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
    }

    void Update()
    {
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            Debug.Log("Time has run out!");
            timeRemaining = 0;
            timerIsRunning = false;
        }
    }
}
