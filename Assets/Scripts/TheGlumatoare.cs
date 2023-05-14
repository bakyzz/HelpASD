using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TheGlumatoare : MonoBehaviour
{
    public string[] glume;
    public TMP_Text text;
   
       
    private void Start()
    {
        glume[0] = "Want to hear a joke?";
        text.text = glume[0];

    }

    public void Gluma()
    {
        int nr = Random.Range(1, 10);
       
       

        text.text = glume[nr];

    }

}
