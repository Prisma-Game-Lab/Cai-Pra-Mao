using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCharacters : MonoBehaviour
{
    public static SelectedCharacters instance;
    public CharStats p1Character;
    public CharStats p2Character;

    public int p1DashCount;
    public int p1Attacks;
    public int p2DashCount;
    public int p2Attacks;
    public string matchTime;

    public int winnerAttacks;
    public int winnerDashes;
    public CharStats winner;
    public CharStats loser;


    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
        ResetStats();
    }

    public void ResetStats()
    {
        p1Attacks = 0;
        p2Attacks = 0;
        p2DashCount = 0;
        p2DashCount = 0;
        matchTime = "";
    }

    public void SetWinner(int winnerIndex)
    {
        if (winnerIndex == 1)
        {
            winnerAttacks = p1Attacks;
            winnerDashes = p1DashCount;
            winner = p1Character;
            loser = p2Character;
        }
        else
        {
            winnerAttacks = p2Attacks;
            winnerDashes = p2DashCount;
            winner = p2Character;
            loser = p1Character;
        }
    }
}
