using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Menu : MonoBehaviour
{
    private KeepName keep;
    public InputField input;
    public Text BestScore;
    // redirect to the main scene
    public void onPlayButton()
    {
        KeepName.Instance.name = KeepName.Instance.inputfield.text;
        SceneManager.LoadScene(1);
    }
    void Start()
    {

        SaveDataManager.LoadScore();

        KeepName.Instance.inputfield.text = input.text;


    }
    public void Exit()
    {
        SaveDataManager.SaveScore();

#if UNITY_EDITOR

        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }

}
