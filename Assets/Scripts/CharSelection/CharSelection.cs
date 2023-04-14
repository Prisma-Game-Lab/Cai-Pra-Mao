using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CharSelection : MonoBehaviour
{
    public Button readyButton;
    public GameObject[] selectors;
    public Transform[] portraits;
    public CharStats[] characters;
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
            }
            else
            {
                selectors[0].gameObject.transform.position = portraits[0].position;
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
            }
            else
            {
                selectors[1].gameObject.transform.position = portraits[0].position;
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
            selectors[player].GetComponent<Image>().color = Color.blue;
        }
        else if (player == 1)
        {
            SelectedCharacters.instance.p2Character = characters[selected];
            selectors[player].GetComponent<Image>().color = Color.cyan;
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
            selectors[player].GetComponent<Image>().color = Color.red;
        }
        else if (player == 1)
        {
            SelectedCharacters.instance.p2Character = null;
            selectors[player].GetComponent<Image>().color = Color.green;
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
