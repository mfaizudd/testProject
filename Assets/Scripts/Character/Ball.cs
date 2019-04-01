using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour, IDamageable
{
    private Rigidbody2D _rigid;
    private TextMesh hpText;

    [SerializeField]
    private float jumpForce = 6;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private float health;

    public float Health
    {
        get { return health; }
        set
        {
            hpText.text = value.ToString();
            health = value;
        }
    }


    private void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        hpText = GetComponentInChildren<TextMesh>();
        hpText.text = health.ToString();
    }

    private void FixedUpdate()
    {
        Jump();
    }

    private void Jump()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundLayer);
        if (hit.collider != null)
        {
            _rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public void Damage(float damage)
    {
        Health = Mathf.Abs(Health-damage);
        if(Health==0)
        {
            Destroy(gameObject);
        }
    }
}
