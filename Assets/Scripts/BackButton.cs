using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (SceneManager.GetActiveScene().name != "Menu")
            {
                SceneManager.LoadScene("Menu");
            }
            if (SceneManager.GetActiveScene().name == "Menu")
            {
                Application.Quit();
            }
        }
    }
}
