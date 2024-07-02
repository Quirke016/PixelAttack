using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject bullet;
    Vector3 playerShootPos;
    [SerializeField] GameObject playerShootPosGameObject;
    [SerializeField] GameObject orientation;
    bool canShoot;
    [SerializeField] TextMeshProUGUI canShootNotice;

    private void Start()
    {
        player = gameObject;
        canShoot = true;
    }

    void Update()
    {
        playerShootPos = playerShootPosGameObject.transform.position;
        //playerRot = transform.rotation;

        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            Shoot();
            canShoot = false;
            canShootNotice.text = "Reloading...";
        }

        void Shoot()
        {
            Instantiate(bullet, playerShootPos, orientation.transform.rotation);
            Debug.Log("BANG!");
            StartCoroutine(CanShoot());
        }
    }

    IEnumerator CanShoot()
    {
        yield return new WaitForSeconds(1.7f);

        canShoot = true;

        canShootNotice.text = "Ready To Fire!";
    }
}
