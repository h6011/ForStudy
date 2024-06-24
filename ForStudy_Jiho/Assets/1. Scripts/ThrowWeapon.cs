using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowWeapon : MonoBehaviour
{

    Rigidbody2D rigid;

    /// <summary>
    /// ���ư� ���� ��
    /// </summary>
    Vector2 force;

    /// <summary>
    /// �������� ���ư������� ����
    /// </summary>
    bool right;

    /// <summary>
    /// ���ư��� ������ ������ �ϱ� ���� bool
    /// </summary>
    bool isDone;






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
        if (isDone) return;
        transform.Rotate(new Vector3(0, 0, right ? -360f : 360f) * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDone = true;
    }

    

    public void SetForce(Vector2 _force, bool _isRight)
    {
        force = _force;
        right = _isRight;
    }

}
