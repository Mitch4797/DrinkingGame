using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

    //Methods
    public void addCard(int Ty, int R, int D, string T)
    {
        card newCard = new card(Ty, R, D, T);
        orderedDeck[fillsize] = newCard;
        fillsize++;
    }

    //Compile orderedDeck
    public void makeDeck(bool[] type, bool[] rating)
    {
        string deckLocation = "Assets/TasksFiles/CardDeck.txt";

        using(var reader = new StreamReader(deckLocation))
        {
            while(!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                if (type[int.Parse(values[0])] && rating[int.Parse(values[1])])
                {
                    addCard(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), values[3]);
                }

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
