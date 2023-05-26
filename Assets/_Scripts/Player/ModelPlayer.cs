using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelPlayer : MonoBehaviour
{
    [Header("player Stats")]
    [SerializeField] private float _moveSpeed;
    private Rigidbody2D _rb;
    [SerializeField] Animator _anim;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float horizontal, float vertical)
    {
        if (horizontal != 0 || vertical != 0)
        {
            _anim.SetBool("isWalking", true);
            _anim.SetFloat("DirX",horizontal);
        }
        else
        {
            _anim.SetBool("isWalking", false);
        }

        Vector2 moveDir = new Vector2(horizontal, vertical);
        moveDir = moveDir.normalized * _moveSpeed * Time.deltaTime;
        _rb.velocity = moveDir;        
    }

}
