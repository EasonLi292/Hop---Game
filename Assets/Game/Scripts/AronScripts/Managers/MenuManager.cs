using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene("Game");
    }

    public void LoadMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}