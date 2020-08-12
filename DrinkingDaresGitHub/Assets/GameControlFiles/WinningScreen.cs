using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class WinningScreen : MonoBehaviour
{
    public Text winPlayer;

    //RestartGame
    public void backToGameCreation()
    {
        SceneManager.LoadScene("GameCreation");
    }

    // Start is called before the first frame update
    void Start()
    {
        winPlayer.text = "Player: " + ( GameMaster.GMI.getWinningPayer() + 1 ) +" !!!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
