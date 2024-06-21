using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [Header("커서 이미지")]
    [SerializeField, Tooltip("0 은 <color=red>디폴트</color>, 1 은 <color=red>클릭</color>")]
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
