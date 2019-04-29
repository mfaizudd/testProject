using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigid;
    private Animator _anim;
    private Transform playerRig;

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
        playerRig = transform.GetChild(0);
    }

    private void FixedUpdate()
    {
        Move();

        Debug.DrawRay(transform.position, Vector2.down * 2.4f, Color.red);
        Attack();
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

    // Jump
    public void Jump()
    {
        Debug.DrawRay(transform.position, Vector2.down * 2.4f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 2.4f, groundLayer);
        if (hit.collider != null)
        {
            _rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    // Attack
    private void Attack()
    {
        if(Input.GetButtonUp("Attack"))
        {
            //AnimateAttack();
            //Time.timeScale = 0;
            //attackPanel.SetActive(true);
        }
    }

    private void AnimateAttack()
    {
        _anim.SetTrigger("Attack");
    }
}
