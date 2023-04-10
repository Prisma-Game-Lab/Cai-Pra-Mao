using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.GetComponent<PlayerCombat>().Die();
    }
}
