using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // redirect to the main scene
    public void onPlayButton()
    {
        SceneManager.LoadScene(1);
    }

}
 