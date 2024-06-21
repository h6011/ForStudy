using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowWeapon : MonoBehaviour
{

    Rigidbody2D rigid;
    /// <summary>
    /// 날아갈 물리 힘
    /// </summary>
    Vector2 force;
    bool right;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rigid.AddForce(force, ForceMode2D.Impulse);
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, right ? -360f : 360f) * Time.deltaTime);
    }


}
