using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    Camera mainCam;
    [SerializeField] Transform trsHand;
    [SerializeField] GameObject objThrowWeapon;
    [SerializeField] Transform trsWeapon;
    [SerializeField] Transform trsDynamic;

    [SerializeField] Vector2 throwForce = new Vector2(10f, 0f); 


    private void Start()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        checkAim();
        checkCreate();
    }

    private bool isPlayerWatchingLeft()
    {
        if (transform.localScale.x > 0) { return true; }
        else { return false; }
    }

    private float GetrWatchingLeftAxisRaw()
    {
        return transform.localScale.x;
    }

    private void checkAim()
    {
        Vector2 mouseWorldPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos = transform.position;
        Vector2 fixedPos = mouseWorldPos - playerPos;



        float angle = Quaternion.FromToRotation(Vector3.left * GetrWatchingLeftAxisRaw(), fixedPos).eulerAngles.z;
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
        GameObject go = Instantiate(objThrowWeapon, trsWeapon.position, trsWeapon.rotation, trsDynamic);
        ThrowWeapon goSc = go.GetComponent<ThrowWeapon>();
        bool isRight = GetrWatchingLeftAxisRaw() < 0;
        goSc.SetForce(trsWeapon.rotation * throwForce * -GetrWatchingLeftAxisRaw(), isRight);

    }


}
