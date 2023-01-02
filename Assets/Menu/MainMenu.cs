using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene(0);
    }
    

    // Update is called once per frame
    /*void FixedUpdate()
    {
        call highscore
    }*/
}
