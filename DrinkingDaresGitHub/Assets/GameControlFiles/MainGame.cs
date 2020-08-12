using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;

public class MainGame : MonoBehaviour
{
    //UI for player info
    public Text currentPlayer;
    public Text[] playerBanners = new Text[6];

    //UI for Cards
    public Text Card1Type;
    public Text Card1Points;
    public Text Card2Type;
    public Text Card2Points;

    //Card Selection
    public void selectCard(int i)
    {
        GameMaster.GMI.selectedCard = i;
        selectSceneType(GameMaster.GMI.drawnCards[i].gettype());
    }

    //Load corrected Scene
    public void selectSceneType(int T)
    {
        if (T == 0 || T == 2)
        {
            SceneManager.LoadScene("SingleCard");
        }
        if (T == 1)
        {
            SceneManager.LoadScene("PartnerCard");
        }
        else
        {

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //CheckForVictory
        GameMaster.GMI.checkVictory();

        //Set Tasks for game master and set tasks Text
        GameMaster.GMI.drawCards();
        currentPlayer.text = "Current Player - " + GameMaster.GMI.getCurrentTurn();
        Card1Type.text = "Type: " + GameMaster.GMI.drawnCards[0].getTypeString();
        Card2Type.text = "Type: " + GameMaster.GMI.drawnCards[1].getTypeString();
        Card1Points.text = "Points: " + GameMaster.GMI.drawnCards[0].getPoints();
        Card2Points.text = "Points: " + GameMaster.GMI.drawnCards[1].getPoints();

        //Make Player Text with points
        for(int i = 0; i <6; i++)
        {
            playerBanners[i].text = "Player " + (i+1) + " - " + GameMaster.GMI.PlayerInformation[i].getscore();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
