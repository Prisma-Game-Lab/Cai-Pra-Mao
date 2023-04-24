using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VictoryScreen : MonoBehaviour
{
    public Sprite toni;
    public Sprite vector;
    public Sprite picote;


    public TMP_Text winnerName;
    public TMP_Text stats;
    public Image winnerImage;
    public Image loserImage;


    // Start is called before the first frame update
    void Start()
    {
        SetupScreen(
            SelectedCharacters.instance.matchTime,
            SelectedCharacters.instance.winnerAttacks,
            SelectedCharacters.instance.winnerDashes,
            SelectedCharacters.instance.winner,
            SelectedCharacters.instance.loser
        );
    }

    private void SetupScreen(string matchTime, int winnerAttacks, int winnerDodges, CharStats winnerCharacter, CharStats loserCharacter)
    {
        if (winnerCharacter.name == "Toni")
        {
            winnerName.text = "Toni Galinho";
            winnerImage.sprite = toni;
        }
        else if (winnerCharacter.name == "Vector")
        {
            winnerName.text = "Vector, a Lontra";
            winnerImage.sprite = vector;
        }
        else
        {
            winnerName.text = "Picote";
            winnerImage.sprite = picote;
        }

        if (loserCharacter.name == "Vector")
        {
            loserImage.sprite = vector;
        }
        else if (loserCharacter.name == "Toni")
        {
            loserImage.sprite = toni;
        }
        else
        {
            loserImage.sprite = picote;
        }

        stats.text = "Tempo de partida: " + matchTime + "\nGolpes dados: " + winnerAttacks.ToString() + "\nEsquivas: " + winnerDodges.ToString();
    }
}
