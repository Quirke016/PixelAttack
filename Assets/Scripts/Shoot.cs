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
    [SerializeField] bool godMode = false;
    [SerializeField] AudioSource laser;
    
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
            laser.Play();
            Shoot();
            canShoot = false;
            canShootNotice.color = Color.red;
            canShootNotice.text = "Reloading...";
        }

        void Shoot()
        {
            Instantiate(bullet, playerShootPos, orientation.transform.rotation);
            
            Debug.Log("Shot bullet!");
            StartCoroutine(CanShoot());
        }
    }

    IEnumerator CanShoot()
    {

        float time = 1.7f;

        if (godMode)
        {
            time = 0.1f;
        }

        yield return new WaitForSeconds(time);

        canShoot = true;
        canShootNotice.color = Color.green;
        canShootNotice.text = "Ready To Fire!";
    }
}
