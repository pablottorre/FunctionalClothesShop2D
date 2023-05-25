using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelPlayer : MonoBehaviour
{
    [Header("player Stats")]
    [SerializeField] private float _moveSpeed;

    public void Move(float horizontal, float vertical)
    {
        transform.position += new Vector3(horizontal, vertical, 0) * _moveSpeed * Time.deltaTime;
    }
}
