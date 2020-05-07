using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField]
    private Sword sword;

    public void SetDamage(int value)
    {
        sword.Damaging = true;
        sword.DamageValue = value;
        StartCoroutine(DisableDamaging());
    }

    IEnumerator DisableDamaging()
    {
        yield return new WaitForSeconds(.25f);
        sword.Damaging = false;
    }
}
