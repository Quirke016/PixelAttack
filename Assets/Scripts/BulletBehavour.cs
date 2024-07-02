using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavour : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5;
    Rigidbody2D rb2D;
    HealthManager hM;

    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(DestroyButtel());
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        GameObject.Find("Player").gameObject.GetComponent<HealthManager>();
        rb2D.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D()
    {
        
            GameObject player;
            player = GameObject.Find("Player");
            hM = player.gameObject.GetComponent<HealthManager>();
            hM.Damage();
            Debug.Log("Crash");
            GameObject.Destroy(gameObject);
        
    }
    IEnumerator DestroyButtel()
    {
        yield return new WaitForSeconds(3.5f);

        Destroy(gameObject);
    }
}
