using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameStarter : MonoBehaviour
{
    
    //Attributes of GameController settings
    public int numPlayers = 1;
    int maxPlayers = 6;

    //Game control
    public bool[] types = { false, false, false }; //Add False to add another deck. See Word Doc for what deck is each number
    public bool[] rating = { false, false, false }; 
    public Button startbutton;

    //Texts that need to display
    public Text numPlayersTXT;
    public Text maxScore;
    public Text PPN;


    //Set CurrentPlayers
    public void addPlayer()
    {
        if ((numPlayers + 1) <= maxPlayers)
        {
            numPlayers++;
        }
    }

    public void removePlayer()
    {

        if ((numPlayers - 1) > 0)
        {
            numPlayers--;
        }

    }

    public void changetype(int num)
    {
        if (types[num] == false)
        {
            types[num] = true;
        }
        else
            types[num] = false;
    }

    public void changerating(int num)
    {
        if (rating[num] == false)
        {
            rating[num] = true;
        }
        else
            rating[num] = false;
    }

    public void setMaxScore(float n)
    {
        GameMaster.GMI.setMaxScore(Convert.ToInt32(n));
    }
    public void getPPN(float n)
    {
        GameMaster.GMI.setPartnerPreventionValue(Convert.ToInt32(n));
    }

    public Boolean checkValidSettings()
    {
        Boolean onetype = false;
        Boolean onerating = false;
        for (int i = 0; i < types.Length; i++)
        {
            if(types[i] == true)
            {
                onetype = true;
            }
        }
        for (int j = 0; j < rating.Length; j++)
        {
            if(rating[j] == true)
            {
                onerating = true;
            }
        }

        if(onerating && onetype)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void startGame()
    {
        //initilize GMI
        GameMaster.GMI.setNP(numPlayers);

        //Initilize GDI
        Deck.GDI.makeDeck(types, rating);

        //Load Correct Scene
        SceneManager.LoadScene("MainGame");

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //UpdateAllText
        numPlayersTXT.text = "Players: " + numPlayers;
        maxScore.text = "Play to: " + GameMaster.GMI.getMaxScore();
        PPN.text = "Partner Prevention: " + GameMaster.GMI.getPartnerPreventionValue();

        //currentPlayerTXT.text = "Player: " + currentPlayer;

        //Update if game can start.
        if (checkValidSettings())
        {
            startbutton.interactable = true;
        }
        else
        {
            startbutton.interactable = false;
        }

    }

}
