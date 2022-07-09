using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayMode : MonoBehaviour
{
    public Player player;
    public AIPlayer cpu;

    //Se ejecuta despues del Awake de GameManager
    void Awake()
    {
        SetModeToPlay();
    }

    private void SetModeToPlay()
    {
        TEAM[] teams = TeamManager.GetAllTeams();

        switch (GameManager.instance.adversaryMode)
        {
            case playMode.Player_Vs_Player:

                for (int i = 0; i < teams.Length; i++)
                {
                    player.team.Add(teams[i]);
                }

                break;
            case playMode.Player_Vs_Cpu:

                TEAM playerTeam = teams[Random.Range(0, teams.Length - 1)];
                player.team.Add(playerTeam);

                for (int i = 0; i < teams.Length; i++)
                {
                    if (teams[i] != playerTeam)
                    {
                        cpu.team.Add(teams[i]);
                    }
                }
                break;
            case playMode.Cpu_Vs_Cpu:
                for (int i = 0; i < teams.Length; i++)
                {
                    cpu.team.Add(teams[i]);
                }

                break;
        }
    }


}
