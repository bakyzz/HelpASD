using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class randomnr : MonoBehaviour
{
    [SerializeField] private int number1, number2, number3;
    public int magic;
    public TMP_Text text1, text2, text3, textsemn;
    public GameObject o1, o2, o3, o4;

    public void Start()
    {
        text1 = o1.GetComponentInChildren<TMP_Text>();
        text2 = o2.GetComponentInChildren<TMP_Text>();
        text3 = o3.GetComponentInChildren<TMP_Text>();

        textsemn = o4.GetComponent<TMP_Text>();

        RandomNR();
    }
    public void RandomNR()
    {
        magic = Random.Range(0, 100);
        number1 = Random.Range(2, 95);
        text1.text = number1.ToString();
        int x;
        if (number1 > 100 - number1) x= 100 - number1;
        else x = number1;

        number2 = Random.Range(0,x-1);
        text2.text = number2.ToString();
        int nr;
        if (magic <= 50)
        {
            nr = number2 + number1;
          
            number3 = Random.Range(nr -1, nr + 2);
            textsemn.text = "+";
            text3.text = number3.ToString();
        }
        else
        {
            nr = number1 - number2;
            number3 = Random.Range(nr - 1, nr + 2);
            textsemn.text = "-";
            text3.text = number3.ToString();
        }
        
    }

    public int get(int a)
        {
        if(a==0) return magic;
        if (a==1) return number1;
        if(a==2) return number2;
        if (a==3) return number3;
        return 0;
        }
      
   
   
}
