using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.Serialization;

public class Semn : MonoBehaviour
{
    private int nr1, nr2, nr3, semn;
    public GameObject o, b1, b2, b3,NUMAR,NUMARMAX,GJ;
    public int nr = 0, maxnr = 0;
    public TMP_Text numar, numarmax;

    public AudioSource audioData;
    public void Start()
    {
        
       numar = NUMAR.GetComponent<TMP_Text>();
       numarmax = NUMARMAX.GetComponent<TMP_Text>();
        numar.text = nr.ToString();
        numarmax.text = maxnr.ToString();
    }

    private void Daca()
    {
        if (nr > maxnr) maxnr = nr;
        numarmax.text = maxnr.ToString();
    }
    
    private void butCul()
    {
        nr++;
        numar.text=nr.ToString();
        Daca();
        b1.GetComponent<Image>().color = Color.white;
        b2.GetComponent<Image>().color = Color.white;
        b3.GetComponent<Image>().color = Color.white;
       
    }

   
   IEnumerator verde()
    {
        GJ.SetActive(true);
        audioData.Play(0);
        yield return new WaitForSecondsRealtime(2.5f);
        GJ.SetActive(false);
        o.GetComponent<randomnr>().RandomNR();
        butCul();
    }



    public void adevar(int caz)
    {
        nr1 = o.GetComponent<randomnr>().get(1);
        nr2 = o.GetComponent<randomnr>().get(2);
        nr3 = o.GetComponent<randomnr>().get(3);
        semn = o.GetComponent<randomnr>().get(0);

        if (semn <= 50)
        {

            if (caz == 0)
            {

                {
                    if (nr1 + nr2 < nr3)

                    {
                        b1.GetComponent<Image>().color = Color.green;
                        StartCoroutine(verde());
                        

                    }

                    else
                    {

                        nr = 0;
                        b1.GetComponent<Image>().color = Color.red;
                    }
                }
            }
            else if (caz == 1)
            {
                if (nr1 + nr2 == nr3)

                {
                    b2.GetComponent<Image>().color = Color.green;
                    StartCoroutine(verde());
                  
                }
                else
                {
                    nr = 0;
                    b2.GetComponent<Image>().color = Color.red;
                }

            }
            else
            {
                if (nr1 + nr2 > nr3)
                {
                    b3.GetComponent<Image>().color = Color.green;
                    StartCoroutine(verde());
                  
                }
                else
                {
                    nr = 0;
                    b3.GetComponent<Image>().color = Color.red;
                }
            }
        }
        else
        {
            if (caz == 0)
            {

                {
                    if (nr1 - nr2 < nr3)

                    {
                        b1.GetComponent<Image>().color = Color.green;
                        StartCoroutine(verde());
                        
                    }

                    else
                    {
                        nr = 0;
                        b1.GetComponent<Image>().color = Color.red;
                    }
                }
            }
            else if (caz == 1)
            {
                if (nr1 - nr2 == nr3)

                {
                    b2.GetComponent<Image>().color = Color.green;
                    StartCoroutine(verde());
                   
                }
                else
                {
                    nr = 0;
                    b2.GetComponent<Image>().color = Color.red;
                }
            }
            else
            {
                if (nr1 - nr2 > nr3)
                {
                    b3.GetComponent<Image>().color = Color.green;
                    StartCoroutine(verde());
                  
                }
                else
                {
                    nr = 0;
                    b3.GetComponent<Image>().color = Color.red;
                }
            }
        }
    }
}
