using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TEAM
{
    white, black
}

public class TurnManager 
{
    public static TEAM currentTeamTurn = 0;

    public static void NextTeam()
    {
        currentTeamTurn = currentTeamTurn.Next();
    }
}
