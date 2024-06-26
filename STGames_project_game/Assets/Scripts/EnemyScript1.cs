using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript1 : MonoBehaviour
{
    public Rigidbody2D rbEnm;
    void Start()
    {
        rbEnm = GetComponent<Rigidbody2D>();
        gameObject.tag = "Enemy";
    }


    void Update()
    {
        
    }
}
