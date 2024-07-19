using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class SaveDataManager : MonoBehaviour
{
    public Text bestPlayer;
    private int MaxScore;

    [System.Serializable]
    public class SaveData
    {

        public int point;
        public string playerName;
    }
    public static void SaveScore()
    {

        SaveData data = new SaveData();

        GameManager gameManager = GameManager.Instance;
        data.point = gameManager.MaxScore;
        data.playerName = gameManager.bestPlayer;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public static void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {

            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            if (GameManager.Instance == null)
            {

                FindObjectOfType<SaveDataManager>().bestPlayer.text = data.playerName + ": " + data.point;
               
            }
            else
            {
                GameManager gameManager = GameManager.Instance;
                gameManager.MaxScore = data.point;
                gameManager.bestPlayer = data.playerName;
              
            }



        }

    }
}
