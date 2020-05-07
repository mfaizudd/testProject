using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AttackManager))]
public class Player : MonoBehaviour
{
    private Rigidbody2D _rigid;
    private Animator _anim;
    private Transform playerRig;
    private AttackManager _attack;

    // Props
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float jumpForce = 6f;
    [SerializeField]
    private GameObject attackPanel;
    [SerializeField]
    private LayerMask groundLayer;

    private void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();
        _attack = GetComponent<AttackManager>();
        playerRig = transform.GetChild(0);
    }

    private void FixedUpdate()
    {
        Move();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 2.4f, groundLayer);
        if (hit.collider != null && _anim.GetBool("IsJump") && _rigid.velocity.y <=0)
        {
            _anim.SetBool("IsJump", false);
        }
        Debug.DrawRay(transform.position, Vector2.down * 2.4f, Color.red);
    }


    // Movement
    private void Move()
    {
        float move = Input.GetAxisRaw("Horizontal");
        _rigid.velocity = new Vector2(move * speed, _rigid.velocity.y);
        AnimateMove(Mathf.Abs(move));

        if(move < 0)
        {
            playerRig.localScale = new Vector3(-1, playerRig.localScale.y);
            playerRig.transform.position = new Vector3(transform.position.x-0.75f, playerRig.transform.position.y);
        }
        else if (move > 0)
        {
            playerRig.localScale = new Vector3(1, playerRig.localScale.y);
            playerRig.transform.position = new Vector3(transform.position.x+0.75f, playerRig.transform.position.y);
        }
    }

    private void AnimateMove(float move)
    {
        _anim.SetFloat("Move", move * Time.deltaTime);
    }

    public void Jump()
    {
        Debug.DrawRay(transform.position, Vector2.down * 2.4f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 2.4f, groundLayer);
        if (hit.collider != null)
        {
            _rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _anim.SetBool("IsJump", true);
            _anim.SetTrigger("Jump");
        }
    }
    
    public void Slash()
    {
        _anim.SetTrigger("Slash");
        _attack.SetDamage(5);
    }

    public void Punch()
    {
        _anim.SetTrigger("Punch");
        _attack.SetDamage(3);
    }
}
