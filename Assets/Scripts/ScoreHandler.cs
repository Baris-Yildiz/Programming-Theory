using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreHandler : MonoBehaviour
{
    public static ScoreHandler Instance;
    public TimeScore record;

    public class TimeScore
    {
        public float time;
    }

    public void SaveScore(TimeScore timeScore) 
    {
        string json = JsonUtility.ToJson(timeScore);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadScore() 
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            record = JsonUtility.FromJson<TimeScore>(json);
        }
    }
}
