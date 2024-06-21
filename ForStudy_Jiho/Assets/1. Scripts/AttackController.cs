using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    Camera mainCam;
    [SerializeField] Transform trsHand;
    [SerializeField] GameObject objThrowWeapon;
    [SerializeField] Transform trsWeapon;

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        checkAim();
    }

    private bool isPlayerWatchingLeft()
    {
        if (transform.localScale.x > 0) { return true; }
        else { return false; }
    }

    private void checkAim()
    {
        Vector2 mouseWorldPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos = transform.position;
        Vector2 fixedPos = mouseWorldPos - playerPos;



        float angle = Quaternion.FromToRotation(Vector3.left * transform.localScale.x, fixedPos).eulerAngles.z;
        trsHand.rotation = Quaternion.Euler(0, 0, angle);

    }

    private void checkCreate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            createWeapon();
        }
    }

    private void createWeapon()
    {
        GameObject go = Instantiate(objThrowWeapon);
    }


}
