using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    Camera mainCam;


    private void Start()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        checkAim();
    }


    private void checkAim()
    {
        Vector2 mouseWorldPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
    }



}
