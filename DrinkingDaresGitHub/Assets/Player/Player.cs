using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player
{
    //Attributes
    int Num;
    int score;
    int[] partnerPrevention = new int[6];
    //string color;

    public Player(int num)
    {
        Num = num;
        score = 0;
    }
    
    //Getter and Setter
    public int getscore()
    {
        return score;
    }

    public int getNum()
    {
        return Num;
    }

    //partner prevention score solver
    public int getScore(int totalPoints, int partnerPlayer)
    {
        int divideFactor = 1;
        for(int i = 0; i < GameMaster.GMI.getPartnerPreventionValue(); i++)
        {
            if(partnerPrevention[i] == partnerPlayer)
            {
                divideFactor++;
            }
        }
        int pointsToReturn = totalPoints/divideFactor;
        return pointsToReturn;
    }

    public void shiftPP(int player)
    {
        for (int i = partnerPrevention.Length - 1; i > 0; i--)
        {
            partnerPrevention[i] = partnerPrevention[i - 1];
        }
        partnerPrevention[0] = player;
    }

    //Add to score
    public void addscore(int points)
    {
        score += points;
        GameMaster.GMI.checkVictory();
    }

    //overload for partner prevention score
    public void addscore(int points, int partnerPlayer)
    {
        int pointsToAdd = getScore(points, partnerPlayer);
        shiftPP(partnerPlayer);
        score += pointsToAdd;
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
