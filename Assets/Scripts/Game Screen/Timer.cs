using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public int seconds = 0;
    public int minutes = 0;
    string numberFormat = "00.##";

    public TextMeshProUGUI currentTimeText;

    public static Timer Instance;

    void Start()
    {
        Instance = this;
        StartCoroutine(CountSeconds());
    }

    IEnumerator CountSeconds()
    {
        yield return new WaitForSeconds(1);
        seconds++;
        if (seconds == 60)
        {
            minutes++;
            seconds = 0;
        }
        
        currentTimeText.text = "Time: " + minutes.ToString(numberFormat) + ":" + seconds.ToString(numberFormat);
        StartCoroutine(CountSeconds());
    }

    public void StopTimer()
    {
        StopAllCoroutines();
    }
}
