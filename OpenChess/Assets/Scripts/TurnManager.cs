using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public Team currentTeam;

    static TurnManager t;

    public Player [] players;

    private void Start()
    {
        t = GetComponent<TurnManager>();
    }

    public static void NextTeam()
    {
        t.currentTeam = t.currentTeam.Next();
        if (GameManager.instance.playingAgainstAI)
        {
            for (int i = 0; i<t.players.Length; i++)
            {
                if (t.currentTeam == t.players[i].currentTeam)
                {
                    t.players[i].Invoke("Play", 0.2f);
                }
            }
        }
    }   

    public static Team GetCurrentTeam()
    {
        return t.currentTeam;
    }
}


