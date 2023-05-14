using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManagerColorG : MonoBehaviour
{
    public Image[] images;
    int[] ArrayOfNum = {0, 1, 2, 3, 4, 5, 6, 7 };

    Dictionary<string, Color> colours;
    public Color colorToPick;

    public int scoreTxt;
    public Text pickTxt;
    public Text ScoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        colours = new Dictionary<string, Color>();
        colours.Add("Blue", Color.blue);
        colours.Add("Cyan", Color.cyan);
        colours.Add("Gray", Color.gray);
        colours.Add("Green", Color.green);
        colours.Add("Magenta", Color.magenta);
        colours.Add("Red", Color.red);
        colours.Add("White", Color.white);
        colours.Add("Yellow", Color.yellow);

        images = GetComponentsInChildren<Image>();
        setupColours();
        setupText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setupColours()
    {
        images = GetComponentsInChildren<Image>();

        //shuffle the array
        ArrayOfNum = ArrayOfNum.OrderBy(i => Random.Range(0, images.Length)).ToArray();

        int newNum = 0;
        foreach (Image img in images)
        {
            img.color = setColour(ArrayOfNum[newNum]);
            newNum++;
        }
    }

    public void setupText()
    {
        int rand = Random.Range(0, colours.Count);
        pickTxt.text = "Choose " + colours.ElementAt(rand).Key;
        colorToPick = colours.ElementAt(rand).Value;
        pickTxt.color = setColour(Random.Range(0, 7));
        ScoreTxt.text = "Score: " + scoreTxt;
    }

    public Color setColour(int numInArray)
    {
        switch (numInArray)
        {
            case 0:
                return Color.blue;
            case 1:
                return Color.cyan;
            case 2:
                return Color.gray;
            case 3:
                return Color.green;
            case 4:
                return Color.magenta;
            case 5:
                return Color.red;
            case 6:
                return Color.white;
            case 7:
                return Color.yellow;
            default:
                return Color.clear;
        }
    }

    public void checkColour(Image image)
    {
        if(image.color==colorToPick)
        {
            setupColours();
            setupText();
            scoreTxt++;
            ScoreTxt.text = "Score: " + scoreTxt;
        }
    }
}
