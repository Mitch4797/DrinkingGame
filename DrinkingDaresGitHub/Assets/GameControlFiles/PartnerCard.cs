using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Security.Permissions;

public class PartnerCard : MonoBehaviour
{
    //Attributes
    int cardnum = GameMaster.GMI.getSelectedCard();
    public int partnerPlayerNum = 0;

    //TextFeils to Generate:
    public Text CardType;
    public Text CardTask;
    public Text CardPoints;
    public Text currentPlayer;
    public Text completed;
    public Text[] playerBanners = new Text[6];

    //Complete/failed
    public void selectParetner(int NP)
    {
        partnerPlayerNum = NP;
        completed.text = "Dare Complete with Player: " + partnerPlayerNum;
    }

    public void taskcomplete()
    {
        GameMaster.GMI.PlayerInformation[GameMaster.GMI.getCurrentTurn() - 1].addscore(GameMaster.GMI.drawnCards[cardnum].getPoints(), partnerPlayerNum - 1);
        GameMaster.GMI.PlayerInformation[partnerPlayerNum - 1].addscore( (GameMaster.GMI.drawnCards[cardnum].getPoints())/2, GameMaster.GMI.getCurrentTurn() - 1 ); //Partner gets 1/2 points
        GameMaster.GMI.nextTurn();
        SceneManager.LoadScene("MainGame");
    }
    public void taskfailed()
    {
        GameMaster.GMI.nextTurn();
        SceneManager.LoadScene("MainGame");
    }

    // Start is called before the first frame update
    void Start()
    {
        currentPlayer.text = "Current Player - " + GameMaster.GMI.getCurrentTurn();
        CardType.text = "Type: " + GameMaster.GMI.drawnCards[cardnum].getTypeString();
        CardPoints.text = "Points: " + GameMaster.GMI.drawnCards[cardnum].getPoints();
        CardTask.text = GameMaster.GMI.drawnCards[cardnum].getTask();

        //Make Point Banners.
        for(int i = 0; i < 6; i++)
        {
            playerBanners[i].text = "Player " + (i+1) + " for " + GameMaster.GMI.PlayerInformation[GameMaster.GMI.getCurrentTurn() - 1].getScore(GameMaster.GMI.drawnCards[cardnum].getPoints(), i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Was a partner selected.

        //Update Completed with

    }
}