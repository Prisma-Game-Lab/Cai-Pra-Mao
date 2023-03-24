using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SmashCSS : MonoBehaviour {

    private GridLayoutGroup gridLayout;
    [HideInInspector]
    public Vector2 slotArtworkSize;


    public static SmashCSS instance;
    [Header("Characters List")]
    public List<Character> characters = new List<Character>();
    [Space]
    [Header("Public References")]
    public GameObject charCellPrefab;
    public GameObject gridBgPrefab;
    public Transform playerSlotsContainer;
    [Space]
    [Header("Current Confirmed Character")]
    public Character confirmedCharacter;

    private void Awake()
    {
        instance = this;
    }

    void Start () {

        gridLayout = GetComponent<GridLayoutGroup>();
        GetComponent<RectTransform>().sizeDelta = new Vector2(gridLayout.cellSize.x * 5, gridLayout.cellSize.y * 2);
        RectTransform gridBG = Instantiate(gridBgPrefab, transform.parent).GetComponent<RectTransform>();
        gridBG.transform.SetSiblingIndex(transform.GetSiblingIndex());
        gridBG.sizeDelta = GetComponent<RectTransform>().sizeDelta;

        slotArtworkSize = playerSlotsContainer.GetChild(0).Find("artwork").GetComponent<RectTransform>().sizeDelta;

        foreach(Character character in characters)
        {
            SpawnCharacterCell(character);
        }

	}

    private void SpawnCharacterCell(Character character)
    {
        GameObject charCell = Instantiate(charCellPrefab, transform);

        charCell.name = character.characterName;

        Image artwork = charCell.transform.Find("artwork").GetComponent<Image>();
        TextMeshProUGUI name = charCell.transform.Find("nameRect").GetComponentInChildren<TextMeshProUGUI>();

        artwork.sprite = character.characterSprite;
        name.text = character.characterName;

        artwork.GetComponent<RectTransform>().pivot = uiPivot(artwork.sprite);
        artwork.GetComponent<RectTransform>().sizeDelta *= character.zoom;
    }

    public void ConfirmCharacter(int player, Character character)
    {
        if (confirmedCharacter == null)
        {
            confirmedCharacter = character;
        }
    }

    public Vector2 uiPivot (Sprite sprite)
    {
        Vector2 pixelSize = new Vector2(sprite.texture.width, sprite.texture.height);
        Vector2 pixelPivot = sprite.pivot;
        return new Vector2(pixelPivot.x / pixelSize.x, pixelPivot.y / pixelSize.y);
    }

}