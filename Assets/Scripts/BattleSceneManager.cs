using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BattleSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject p1Prefab;
    [SerializeField] private GameObject p2Prefab;

    // Start is called before the first frame update
    void Start()
    {
        var p1 = PlayerInput.Instantiate(p1Prefab, controlScheme: "Player1", pairWithDevice: Keyboard.current);
        var p2 = PlayerInput.Instantiate(p2Prefab, controlScheme: "Player2", pairWithDevice: Keyboard.current);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
