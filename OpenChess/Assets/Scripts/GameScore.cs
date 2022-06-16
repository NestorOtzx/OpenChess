using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameScore : MonoBehaviour
{
    public static Dictionary<Team, int> pointsByTeam = new Dictionary<Team, int>();

    private void Awake()
    {
        pointsByTeam.Clear();

        foreach (Team team in Enum.GetValues(typeof(Team)))
        {
            pointsByTeam.Add(team, 0);
        }
    }

}
