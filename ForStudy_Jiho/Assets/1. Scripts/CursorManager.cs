using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [Header("Ŀ�� �̹���")]
    [SerializeField, Tooltip("0 �� <color=red>����Ʈ</color>, 1 �� <color=red>Ŭ��</color>")]
    Texture2D[] cursors;

    private void Update()
    {
        Texture2D cursor = null;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            cursor = cursors[1];
        }
        else
        {
            cursor = cursors[0];
        }
        Cursor.SetCursor(cursor, new Vector2(cursor.width * 0.5f, cursor.height * 0.5f), CursorMode.Auto);
    }



}
