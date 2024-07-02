using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavour : MonoBehaviour
{
    [SerializeField] float rotSpeed;
    [SerializeField] float size;
    [SerializeField] float speed;
    Rigidbody2D rb2D;
    HealthManager hM;

    #region Type
    [SerializeField] bool regular;
    [SerializeField] bool splitter;
    [SerializeField] bool explosive;
    [SerializeField] bool shooting;
    [SerializeField] bool alive;
    [SerializeField] bool oblong;
    [SerializeField] bool mine;

    [SerializeField] GameObject explosion;

    [SerializeField] GameObject asteroid;

    #endregion


    // Start is called before the first frame update
    void Awake()
    {
        rotSpeed = Random.Range(-200f, 200f);
        speed = Random.Range(0.5f, 5f);
        size = Random.Range(0.5f, 3f);

        

        gameObject.transform.localScale += new Vector3(size, size, 0);
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(GO());
    }

    IEnumerator GO()
    {
        yield return new WaitForSeconds(1.5f);

        rb2D.AddForce(transform.up * speed, ForceMode2D.Impulse);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, rotSpeed * Time.deltaTime);
    }

    public void Shot()
    {
        Debug.Log("SHOT!");
        GameObject.Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (splitter == false &&  explosive == false)
        {
            if (col.tag == "Player")
            {
                GameObject player;
                player = GameObject.Find("Player");
                hM = player.gameObject.GetComponent<HealthManager>();
                hM.Damage();
                Debug.Log("Crash");
                GameObject.Destroy(gameObject);
            }

            if (col.tag == "Bullet")
            {
                Destroy(col.gameObject);
                GameObject.Destroy(gameObject);
            }
        }

        if (splitter == true)
        {
            if (col.tag == "Player")
            {
                GameObject player;
                player = GameObject.Find("Player");
                hM = player.gameObject.GetComponent<HealthManager>();
                hM.Damage();
                Debug.Log("Crash");
                GameObject.Destroy(gameObject);
            }

            if (col.tag == "Bullet")
            {
                 Instantiate(asteroid, this.transform.position, Quaternion.identity);
                 Instantiate(asteroid, this.transform.position, Quaternion.identity);
                 Instantiate(asteroid, this.transform.position, Quaternion.identity);
                 GameObject.Destroy(gameObject);
            }   

        }

        if (explosive == true)
        {
            if (col.tag == "Player")
            {
                GameObject player;
                player = GameObject.Find("Player");
                hM = player.gameObject.GetComponent<HealthManager>();
                hM.Damage();
                Debug.Log("Crash");
                GameObject.Destroy(gameObject);
            }

            if (col.tag == "Bullet")
            {
                explosion.SetActive(true);
                speed = 0f;
                StartCoroutine(DestroyExplosion());
            }
        }

    }

    IEnumerator DestroyExplosion()
    {
        yield return new WaitForSeconds(1f);
        GameObject.Destroy(gameObject);
    }
}
