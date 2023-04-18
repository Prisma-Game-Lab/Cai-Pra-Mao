using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject p1HP;
    public GameObject p1HPShadow;
    public GameObject p1Sprite;
    public GameObject p1Lives;


    public GameObject p2HP;
    public GameObject p2HPShadow;
    public GameObject p2Sprite;
    public GameObject p2Lives;

    public GameObject timer;

    public Sprite galinho;
    public Sprite lontra;


    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        SetDamage(1, "0");
        SetDamage(2, "0");
        elapsedTime = 0;

        var players = FindObjectsOfType<PlayerCombat>();

        foreach (PlayerCombat combat in players)
        {
            if (combat.character.name == "Toni")
            {
                SetSprites(combat.playerIndex, galinho);
            }
            else if (combat.character.name == "Vector")
            {
                SetSprites(combat.playerIndex, lontra);
            }
        }
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateTimer(elapsedTime);
    }

    public void SetSprites(int playerIndex, Sprite _sprite)
    {
        if (playerIndex == 1)
        {
            p1Sprite.GetComponent<Image>().sprite = _sprite;
        }
        else if (playerIndex == 2)
        {
            p2Sprite.GetComponent<Image>().sprite = _sprite;
        }
    }

    public void SetDamage(int playerIndex, string value)
    {
        if (playerIndex == 1)
        {
            p1HP.GetComponent<TMP_Text>().text = value + "%";
            p1HPShadow.GetComponent<TMP_Text>().text = value + "%";
        }
        else if (playerIndex == 2)
        {
            p2HP.GetComponent<TMP_Text>().text = value + "%";
            p2HPShadow.GetComponent<TMP_Text>().text = value + "%";
        }
    }

    public void SetLives(int playerIndex, int currentLives)
    {
        string _text = "";
        if (currentLives == 3)
        {
            _text = ". . .";
        }
        else if (currentLives == 2)
        {
            _text = ". .";
        }
        else if (currentLives == 1)
        {
            _text = ".";
        }

        if (playerIndex == 1)
        {
            p1Lives.GetComponent<TMP_Text>().text = _text;
        }
        else if (playerIndex == 2)
        {
            p2Lives.GetComponent<TMP_Text>().text = _text;
        }
    }

    public void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float hours = Mathf.FloorToInt(currentTime / 60);
        float minutes = Mathf.FloorToInt(currentTime % 60);

        string minutesText;

        if (minutes < 10)
        {
            minutesText = "0" + minutes.ToString();
        }
        else
        {
            minutesText = minutes.ToString();
        }

        timer.GetComponent<TMP_Text>().text = hours.ToString() + ":" + minutesText;
        SelectedCharacters.instance.matchTime = timer.GetComponent<TMP_Text>().text;
    }
}
