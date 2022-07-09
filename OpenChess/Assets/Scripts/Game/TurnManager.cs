using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TEAM
{
    white, black
}

public class TeamManager 
{
    public static TEAM currentTeamTurn = 0;

    public static void NextTeamTurn()
    {
        currentTeamTurn = currentTeamTurn.Next();
    }

    public static TEAM[] GetAllTeams()
    {
        return (TEAM[])System.Enum.GetValues(typeof(TEAM));
    }

}
