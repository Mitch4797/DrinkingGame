using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameMaster : MonoBehaviour
{
    //MAKE THIS OBJECT A SINGLETON
    public static GameMaster GMI { get; private set; }
    private void Awake() //Prevents Multiple from being created
    {
        if (GMI == null)
        {
            GMI = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Attributes of game manager
    public int numOfPlayers = 1;
    public int maxScore = 150;
    public int partnerPreventionNum = 1;

    //Setters for the GameStarter
    public void setNP(int num)
    {
        numOfPlayers = num;
    }
    public int getNP()
    {
        return numOfPlayers;
    }
    public void setMaxScore(int m)
    {
        maxScore = m;
    }
    public int getMaxScore()
    {
        return maxScore;
    }
    public int getPartnerPreventionValue()
    {
        return partnerPreventionNum; 
    }
    public void setPartnerPreventionValue(int PPN)
    {
        partnerPreventionNum = PPN;
    }

    //Check if Player has won.
    public void checkVictory()
    {
        bool winner = false;
        if (PlayerInformation[currentTurn].getscore() >= maxScore)
        {
            winningPlayer = currentTurn;
            winner = true;
        }
        else
        {
            for (int i = 0; i < numOfPlayers; i++)
            {
                if (PlayerInformation[i].getscore() >= maxScore)
                {
                    winningPlayer = i;
                    winner = true;
                }
            }
        }
        if(winner == true)
        {
            SceneManager.LoadScene("WinningScreen");
        }
    }

    //Player and Turn Information
    public Player[] PlayerInformation;
    public int winningPlayer;
    public int currentTurn; //Refrecned to playerInformation Array

    public int getWinningPayer()
    {
        return winningPlayer;
    }

    //Attributes for a turn
    public card[] drawnCards;
    public int selectedCard;

    //Player Turn Methods
    public void nextTurn()
    {
        if( (currentTurn +1) < numOfPlayers)
        {
            currentTurn++;
        }
        else
        {
            currentTurn = 0;
        }
    }
    public int getCurrentTurn()
    {
        return currentTurn + 1;
    }


    //Card Methods
    public void drawCards()
    {
        drawnCards[0] = Deck.GDI.drawCard();
        drawnCards[1] = Deck.GDI.drawCard();
    }

    public int getSelectedCard()
    {
        return selectedCard;
    }
    

    // Start is called before the first frame update
    void Start()
    {
        //Initilize data
        PlayerInformation = new Player[6];
        for (int i = 0; i < 6; i++)
        {
            PlayerInformation[i] = new Player(i + 1);
        }
        currentTurn = 0;

        drawnCards = new card[2];
    }

    // Update is called once per frame
    void Update()
    {
        //Check If someone has won.


    }

}

