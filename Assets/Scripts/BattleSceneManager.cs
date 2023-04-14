using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BattleSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject p1Prefab;
    [SerializeField] private GameObject p2Prefab;
    public CharStats p1Char;
    public CharStats p2Char;
    public UIManager uiManager;


    // Start is called before the first frame update
    void Awake()
    {
        // AudioManager.instance.StopAllSounds();
        // AudioManager.instance.Play("Music_Menu");
        p1Char = SelectedCharacters.instance.p1Character;
        p2Char = SelectedCharacters.instance.p2Character;

        var p1 = PlayerInput.Instantiate(p1Prefab, controlScheme: "Player1", pairWithDevice: Keyboard.current);
        var p2 = PlayerInput.Instantiate(p2Prefab, controlScheme: "Player2", pairWithDevice: Keyboard.current);
        p1.GetComponent<PlayerCombat>().character = p1Char;
        p1.GetComponent<Animator>().runtimeAnimatorController = p1Char.animatorController;
        p2.GetComponent<PlayerCombat>().character = p2Char;
        p2.GetComponent<Animator>().runtimeAnimatorController = p2Char.animatorController;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndBattle(string winnerName)
    {
        if (winnerName == "Toni")
        {
            SceneManager.LoadScene("Vitoria_Galinho");
        }
        else if (winnerName == "Vector")
        {
            SceneManager.LoadScene("Vitoria_Lontra");
        }
    }

    public void RespawnPlayer(GameObject player, int playerIndex)
    {
        if (playerIndex == 1)
        {
            player.transform.position = p1Prefab.transform.position;
        }
        else if (playerIndex == 2)
        {
            player.transform.position = p2Prefab.transform.position;
        }
    }
}
