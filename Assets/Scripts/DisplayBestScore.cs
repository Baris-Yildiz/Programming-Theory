using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayBestScore : MonoBehaviour
{
    public TextMeshProUGUI bestTimeText;
    string numberFormat = "00.##";
    // Start is called before the first frame update
    public void Start()
    {
        ScoreHandler.TimeScore record = ScoreHandler.LoadScore();

        if (record != null)
        {
            bestTimeText.text = "Best Time: " + record.minutes.ToString(numberFormat) 
                + ":" + record.seconds.ToString(numberFormat);
        }
    }
}
