using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;

public class Deck : MonoBehaviour
{
    //MAKE THIS OBJECT A SINGLETON
    public static Deck GDI { get; private set; }
    private void Awake() //Prevents Multiple from being created
    {
        if (GDI == null)
        {
            GDI = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    //Atribites
    public card[] orderedDeck = new card[300];
    public card[] gameDeck = new card[300];
    int fillsize = 0;
    int drawpoint;
    public TextAsset cardDeckTxt;

    //Methods
    public void addCard(int Ty, int R, int D, string T)
    {
        card newCard = new card(Ty, R, D, T);
        orderedDeck[fillsize] = newCard;
        fillsize++;
    }

    //Compile orderedDeck
    public void makeDeck(bool[] type, bool[] rating)            /////////////Need work here
    {
        string text = cardDeckTxt.text;
        string[] lines = text.Split(System.Environment.NewLine.ToCharArray());

            foreach(string line in lines)
            {
                UnityEngine.Debug.Log(line);                    /////////Debug Line
                string[] values = new string[5];
                values = line.Split(';');

                string V0 = values[0];
                string V1 = values[1];
                string V2 = values[2];
                string V3 = values[3];


                if (type[int.Parse(V0)] && rating[int.Parse(V1)])
                {
                    addCard(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), values[3]);
                }
            }

        makeGameDeck();

    }

    //Compile gameDeck
    public void makeGameDeck()
    {
        for(int i = 0; i < fillsize; i ++)
        {
            gameDeck[i] = orderedDeck[i];
        }
        shuffleDeck();
    }

    //Shuffle Deck
    public void shuffleDeck()
    {
        card temp;
        for (int i = 0; i < fillsize; i++)
        {
            int randomInt = UnityEngine.Random.Range(0, fillsize);
            temp = gameDeck[randomInt];
            gameDeck[randomInt] = gameDeck[i];
            gameDeck[i] = temp;
        }
    }

    //Give player a card from 
    public card drawCard()
    {
        drawpoint++;
        if(fillsize - drawpoint <= 5) //See if deck needs ot shuffle again.
        {
            drawpoint = 0;
            shuffleDeck();
        }
        return gameDeck[drawpoint];
    }

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
