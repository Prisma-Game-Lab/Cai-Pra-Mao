using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharStats", menuName = "ScriptableObjects/CharStats", order = 1)]
public class CharStats : ScriptableObject
{
    public string name;

    [Header("Normal Attack")]
    public int n_minDamage;
    public int n_maxDamage;
    public int n_knockbackDistance;
    public float n_antecipation;
    public float n_freeze;
    public float n_recover;

    [Header("Special Attack")]
    public int s_minDamage;
    public int s_maxDamage;
    public int s_knockbackDistance;
    public float s_antecipation;
    public float s_freeze;
    public float s_recover;
}
