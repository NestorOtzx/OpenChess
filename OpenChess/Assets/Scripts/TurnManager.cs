using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public Team currentTeam;

    static TurnManager t;

    private void Start()
    {
        t = GetComponent<TurnManager>();
    }

    public static void NextTeam()
    {
        t.currentTeam = t.currentTeam.Next();
    }   

    public static Team GetTeam()
    {
        return t.currentTeam;
    }
}


