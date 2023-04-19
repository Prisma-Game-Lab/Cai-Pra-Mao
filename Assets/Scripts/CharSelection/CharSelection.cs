using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class CharSelection : MonoBehaviour
{
    public Button readyButton;
    public GameObject[] selectors;
    public Transform[] portraits;
    public CharStats[] characters;
    public Sprite[] charSprites;
    public Image[] bigImage;
    public TMP_Text[] charNames;
    private bool[] playerReady;

    // Start is called before the first frame update
    void Start()
    {
        readyButton.interactable = false;
        playerReady = new bool[2];
        selectors[0].gameObject.transform.position = portraits[0].position;
        selectors[1].gameObject.transform.position = portraits[1].position;
        

        for (int i = 0; i < 2; i++)
        {
            playerReady[i] = false;
        }
    }

    public void OnChangeUpP1(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && !playerReady[0])
        {
            if (selectors[0].gameObject.transform.position == portraits[0].position)
            {
                selectors[0].gameObject.transform.position = portraits[1].position;
                bigImage[0].sprite = charSprites[1];
                charNames[0].text = "Toni Galinho";
            }
            else if (selectors[0].gameObject.transform.position == portraits[1].position)
            {
                selectors[0].gameObject.transform.position = portraits[2].position;
                bigImage[0].sprite = charSprites[2];
                charNames[0].text = "Papelzito";
            }
            else
            {
                selectors[0].gameObject.transform.position = portraits[0].position;
                bigImage[0].sprite = charSprites[0];
                charNames[0].text = "Vector, a Lontra";
            }
        }
    }

    public void OnChangeUpP2(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && !playerReady[1])
        {
            if (selectors[1].gameObject.transform.position == portraits[0].position)
            {
                selectors[1].gameObject.transform.position = portraits[1].position;
                bigImage[1].sprite = charSprites[1];
                charNames[1].text = "Toni Galinho";
            }
            else if (selectors[1].gameObject.transform.position == portraits[1].position)
            {
                selectors[1].gameObject.transform.position = portraits[2].position;
                bigImage[1].sprite = charSprites[2];
                charNames[1].text = "Papelzito";
            }
            else
            {
                selectors[1].gameObject.transform.position = portraits[0].position;
                bigImage[1].sprite = charSprites[0];
                charNames[1].text = "Vector, a Lontra";
            }

        }
    }

    public void Confirm(int player)
    {
        playerReady[player] = true;
        int selected;

        if (selectors[player].gameObject.transform.position == portraits[0].position)
        {
            selected = 0;
        }
        else
        {
            selected = 1;
        }

        if (player == 0)
        {
            SelectedCharacters.instance.p1Character = characters[selected];
            selectors[player].GetComponent<Image>().color = new Color(0f / 255f, 165f / 255f, 213f / 255f);
        }
        else if (player == 1)
        {
            SelectedCharacters.instance.p2Character = characters[selected];
            selectors[player].GetComponent<Image>().color = new Color(141f / 255f, 30f / 255f, 255f / 255f);
        }

        if (CheckIfPlayersReady())
        {
            readyButton.interactable = true;
        }
    }


    public void ReturnSelection(int player)
    {
        playerReady[player] = false;

        if (player == 0)
        {
            SelectedCharacters.instance.p1Character = null;
            selectors[player].GetComponent<Image>().color = new Color(0f / 255f, 255f / 255f, 213f / 255f);
        }
        else if (player == 1)
        {
            SelectedCharacters.instance.p2Character = null;
            selectors[player].GetComponent<Image>().color = new Color(242f / 255f, 119f / 255f, 225f / 255f);
        }

        if (!CheckIfPlayersReady())
        {
            readyButton.interactable = false;
        }
    }

    public bool CheckIfPlayersReady()
    {
        for (int i = 0; i < 2; i++)
        {
            if (!playerReady[i])
                return false;
        }

        return true;
    }
}
