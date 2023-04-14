using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCharacters : MonoBehaviour
{
    public static SelectedCharacters instance;
    public CharStats p1Character;
    public CharStats p2Character;

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
    }
}
