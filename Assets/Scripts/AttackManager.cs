using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField]
    private Sword sword;
	//wkwk
    public void SetDamage(int value)
    {
        sword.Damaging = true;
        sword.DamageValue = value;
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
