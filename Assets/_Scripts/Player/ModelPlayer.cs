using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelPlayer : MonoBehaviour
{
    [Header("player Stats")]
    [SerializeField] private float _moveSpeed;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        UpdateManager.instance.OnUpdateDelegate += OnUpdateDelegate;
    }


    private void OnUpdateDelegate()
    {

    }

    public void Move(float horizontal, float vertical)
    {
        Vector2 moveDir = new Vector2(horizontal, vertical);
        moveDir = moveDir.normalized * _moveSpeed * Time.deltaTime;
        _rb.velocity = moveDir;        
    }

}
