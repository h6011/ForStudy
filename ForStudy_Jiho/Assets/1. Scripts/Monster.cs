using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Rigidbody2D rigid;
    private BoxCollider2D checkGroundColl;

    Vector2 moveDir = new Vector2(1f, 0f);



    [Header("Ω∫≈»")]
    [SerializeField] float moveSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        checkGroundColl = GetComponentInChildren<BoxCollider2D>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        int intGroundLayer = LayerMask.GetMask("Ground");
        bool isCliff = checkGroundColl.IsTouchingLayers(intGroundLayer);

        if (isCliff == false)
        {
            Vector3 savedLocalScale = transform.localScale;
            savedLocalScale.x *= -1;
            transform.localScale = savedLocalScale;

            moveDir.x *= -1;
        }

        rigid.velocity = new Vector2(moveDir.x * moveSpeed, rigid.velocity.y);
    }

}
