using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Security.Permissions;

public class SingleCard : MonoBehaviour
{
    //TextFeils to Generate:
    public Text CardType;
    public Text CardTask;
    public Text CardPoints;
    public Text currentPlayer;

    //Complete/failed

    public void taskcomplete()
    {
        GameMaster.GMI.PlayerInformation[GameMaster.GMI.getCurrentTurn() - 1].addscore(GameMaster.GMI.drawnCards[GameMaster.GMI.getSelectedCard()].getPoints());
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
        CardType.text = "Type: " + GameMaster.GMI.drawnCards[GameMaster.GMI.getSelectedCard()].getTypeString();
        CardPoints.text = "Points: " + GameMaster.GMI.drawnCards[GameMaster.GMI.getSelectedCard()].getPoints();
        CardTask.text = GameMaster.GMI.drawnCards[GameMaster.GMI.getSelectedCard()].getTask();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
