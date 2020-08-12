using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class card
{
    //attributes
    public int type;
    int rating;
    int difficulty;
    string task;
    int points;

    //Constructors

    public card()
    {
        type = 0;
        rating = 0;
        difficulty = 0;
        task = "No Task Selected";
        points = 0;
    }

    public card(int Ty, int rat, int diff, string T)
    {
        type = Ty;
        rating = rat;
        difficulty = diff;
        task = T;
        points = (rat + 1) * diff;
    }

    //Methods
    public int gettype()
    {
        return type;
    }

    public void setRating(int toset)
    {
        rating = toset;
    }

    public int getrating()
    {
        return rating;
    }

    public void setdifficulty(int toset)
    {
        difficulty = toset;
    }

    public int getdifficulty()
    {
        return difficulty;
    }

    public void setCard(string toset)
    {
        task = toset;
    }

    public string getTask()
    {
        return task;
    }

    public int getPoints()
    {
        return points;
    }

    public card coppyBO(card tocoppy)
    {
        card toReturn = new card(tocoppy.gettype(), tocoppy.getrating(), tocoppy.getdifficulty(), tocoppy.getTask());
        return toReturn;
    }

    public string getTypeString()
    {
        if (type == 0)
        {
            return "Dare";
        }
        if (type == 1)
        {
            return "Partner Dare";
        }
        if (type == 2)
        {
            return "Question";
        }
        else
        {
            return "Error in Type";
        }
    }


}
