using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VictoryScreen : MonoBehaviour
{
    public Sprite toni;
    public Sprite vector;

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
            if (loserCharacter.name == "Vector")
            {
                loserImage.sprite = vector;
            }
            else
            {
                //loserImage.sprite = Picote;
            }
            
        }
        else if (winnerCharacter.name == "Vector")
        {
            winnerName.text = "Vector, a Lontra";
            winnerImage.sprite = vector;
            if (loserCharacter.name == "Toni")
            {
                loserImage.sprite = toni;
            }
            else
            {
                //loserImage.sprite = Picote;
            }
        }
        else
        {
            if (loserCharacter.name == "Toni")
            {
                loserImage.sprite = toni;
            }
            else
            {
                loserImage.sprite = vector;
            }
        }

        stats.text = "Tempo de partida: " + matchTime + "\nGolpes dados: " + winnerAttacks.ToString() + "\nEsquivas: " + winnerDodges.ToString();
    }
}
