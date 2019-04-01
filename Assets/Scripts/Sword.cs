using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public bool Damaging { get; set; } = false;
    public float DamageValue { get; set; } = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable hit = other.GetComponent<IDamageable>();
        if(hit!=null && Damaging)
        {
            hit.Damage(DamageValue);
            Debug.Log(DamageValue);
        }
        Damaging = false;
    }

}
