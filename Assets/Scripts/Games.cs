using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Games : MonoBehaviour
{
    public void Start()
    {
        
    }

    public void Play (string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void Exit(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
