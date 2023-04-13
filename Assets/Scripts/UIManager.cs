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



    // Start is called before the first frame update
    void Start()
    {
        SetDamage(1, "0");
        SetDamage(2, "0");
    }

    public void SetSprites(int playerIndex, Sprite sprite)
    {
        if (playerIndex == 1)
        {
            p1Sprite.GetComponent<Image>().sprite = sprite;
        }
        else if (playerIndex == 2)
        {
            p2Sprite.GetComponent<Image>().sprite = sprite;
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
}
