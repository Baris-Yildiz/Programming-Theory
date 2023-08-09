using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreHandler
{

    public class TimeScore
    {
        public float seconds;
        public float minutes;

        public TimeScore(float minutes, float seconds)
        {
            this.seconds = seconds;
            this.minutes = minutes;
        }
    }

    public static void SaveScore(TimeScore timeScore) 
    {
        string json = JsonUtility.ToJson(timeScore);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public static TimeScore LoadScore() 
    {
        string path = Application.persistentDataPath + "/savefile.json";
        TimeScore record = null;

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            record = JsonUtility.FromJson<TimeScore>(json);
        }

        return record;
    }
}
