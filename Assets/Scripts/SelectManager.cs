using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    public int numberOfUsers = 2;

    public List<CharacterBase> characterList = new List<CharacterBase>();

    [System.Serializable]
    public class CharacterBase
    {
        public string charId;
        public GameObject prefab;
    }

    public CharacterBase returnCharacterWithID(string id)
    {
        CharacterBase retVal = null;

        for(int i = 0; i < characterList.Count; i++)
        {
            if(string.Equals(characterList[i].charId,id))
            {
                retVal = characterList[i];
                break;
            }
        }
        return retVal;
    }
}
