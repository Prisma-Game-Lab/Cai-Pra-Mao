using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectScreenManager : MonoBehaviour
{
    public int numberOfPlayers = 1;
    public List<PlayerInterfaces> plInterfaces = new List<PlayerInterfaces>();
    public PotraitInfo[] potraitPrefabs;
    public int maxX;
    public int maxY;
    PotraitInfo[,] charGrid;

    public GameObject potraitCanvas;

    bool loadLevel;
    public bool bothPlayersSelected;

    CharacterManager charManager;

    [System.Serializable]
    public class PlayerInterfaces
    {
        public PotraitInfo activePotrait;
        public PotraitInfo previewPotrait;
        public GameObject selector;
        public Transform charVisPos;
        public GameObject createdCharacter;

        public int activeX;
        public int activeY;

        public bool hitInputOnce;
        public float timerToReset;

        public PlayerBase playerBase;
    }

        void Start()
        {
            charManager = CharacterManager.GetInstance();
            numberOfPlayers = charManager.numberOfUsers;

            charGrid = new PotraitInfo[maxX,maxY];

            int x = 0;
            int y = 0;

            potraitPrefabs = potraitCanvas.GetComponentsInChildren<PotraitInfo>();


            for (int i = 0; i < potraitPrefabs.Length; i++)
            {
                potraitPrefabs[i].posX += x;
                potraitPrefabs[i].posY += y;

                charGrid[x,y] = potraitPrefabs[i];

                if (x < maxX - 1)
                {
                    x++;
                }
                else
                {
                    x = 0;
                    y++;
                }
            }
        }

        void Update()
        {
            if (!loadLevel)
            {
                for (int i = 0; i < plInterfaces.Count; i++)
                {
                    if (i < numberOfPlayers)
                    {
                        if (Input.GetButtonUp(plInterfaces[i].charManager.players[i].inputId)) //usou o space para confirmar a selecao do personagem
                        {
                            plInterfaces[i].playerBase.hasCharacter = false;

                        }
                        if (!charManager.players[i].hasCharacter)
                        {
                            plInterfaces[i].playerBase = charManager.players[i];

                            HandleSelectorPosition(plInterfaces[i]);
                            HandleSelectScreenInput(plInterfaces[i], charManager.players[i].inputId);

                        }
                    }
                    else
                    {
                        charManager.players[i].hasCharacter = true;
                    }
                }
            }
            if(bothPlayersSelected)
            {
                Debug.Log("carregando");
                StartCoroutine("LoadLevel");
                loadLevel = true;
            }
            else
            {
                if(charManager.players[0].hasCharacter
                    && charManager.players[1].hasCharacter)
                {
                    bothPlayersSelected = false;
                }
            }
        }
        void HandleSelectScreenInput(PlayerInterfaces pl, string playerId)
        {
            #region Grid Navigation

            float vertical = Input.GetAxis("Vertical" + playerId);

            if (vertical != 0)
            {
                if (vertical > 0)
                {
                    pl.activeY = (pl.activeY > 0) ? pl.activeY - 1 : maxY - 1;
                }
                else
                {
                    pl.activeY = (pl.activeY < maxY -1) ? pl.activeY + 1 : 0;
                }
                pl.hitInputOnce = true;
            }
            float horizontal = Input.GetAxis("Horizontal" + playerId);

            if (horizontal != 0)
            {
                if (!pl.hitInputOnce)
                {
                    if (horizontal > 0)
                    {
                        pl.activeX = (pl.activeX > 0) ? pl.activeX - 1 : maxX - 1;
                    }
                    else
                    {
                        pl.activeX = (pl.activeX < maxX -1) ? pl.activeX + 1 : 0;
                    }
                    pl.timerToReset = 0;
                    pl.hitInputOnce = true;

                } 
                if (vertical == 0 && horizontal == 0)
                {
                    hitInputOnce = false;
                }  
                if (pl.hitInputOnce)
                {
                    pl.timerToReset += Time.deltaTime;

                    if (pl.timerToReset > 0.8f)
                    {
                        pl.hitInputOnce = false;
                        pl.timerToReset = 0;
                    }
                }
           }
           #endregion
        }   
        void HandleSelectorPosition(PlayerInterfaces p1)
        {
            p1.selector.SetActive(true);

            p1.activePotrait = charGrid[p1.activeX, p1.activeY];

            Vector2 selectorPosition = pl.activePotrait.transform.localPosition;
            selectorPosition = selectorPosition + new Vector2(potraitCanvas.transform.localPosition.x
                , potraitCanvas.transform.localPosition.y);
            
            pl.selector.transform.localPosition = selectorPosition;
        }
        

}
