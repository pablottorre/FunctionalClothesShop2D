using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    [Header("PlayerModel")]
    [SerializeField] ModelPlayer _mp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _mp.Move(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
    }
}
