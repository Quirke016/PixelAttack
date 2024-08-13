using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidBehavour : MonoBehaviour
{
    [SerializeField] float rotSpeed;
    [SerializeField] float size;
    [SerializeField] float speed;
    Rigidbody2D rb2D;
    HealthManager hM;
    Score s;
    [SerializeField] AudioSource explosionAudio;
    [SerializeField] AudioSource AsteroidExplosionAudio;

    #region Type


    [SerializeField] bool regular;
        [SerializeField] bool splitter;
        [SerializeField] bool explosive;
        [SerializeField] bool health;
        [SerializeField] bool alive;
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

        s = GameObject.Find("ScoreManager").GetComponent<Score>();
        explosionAudio = GameObject.Find("explosionAudio").GetComponent<AudioSource>();

        AsteroidExplosionAudio = GameObject.Find("AsteroidExplosionAudio").GetComponent<AudioSource>();

        gameObject.transform.localScale += new Vector3(size, size, 0);
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(GO());

        if (alive)
        {
            StartCoroutine(LivingCooldown());
        }
    }

    IEnumerator GO()
    {
        yield return new WaitForSeconds(0.5f);

        if (!mine)
        {
            rb2D.AddForce(transform.up * speed, ForceMode2D.Impulse);
        }
    }
    

    void Update()
    {
        if (alive)
        {
            speed = Random.Range(0.5f, 1f);
        }
        transform.Rotate(0f, 0f, rotSpeed * Time.deltaTime);
    }

    IEnumerator LivingCooldown()
    {
        float randTime = Random.Range(1f, 5f);

        yield return new WaitForSeconds(randTime);

        rotSpeed = Random.Range(-200f, 200f);
        rb2D.AddForce(transform.up * speed, ForceMode2D.Impulse);
        StartCoroutine(LivingCooldown());

    }

    public void Shot()
    {
        Debug.Log("SHOT!");
        GameObject.Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (splitter == false &&  explosive == false && health == false)
        {
            if (col.tag == "Player")
            {

                GameObject player;
                player = GameObject.Find("Player");
                hM = player.gameObject.GetComponent<HealthManager>();
                hM.Damage();
                Debug.Log("Crash");
                GameObject.Destroy(gameObject);
                s.score--;
            }

            if (col.tag == "Bullet")
            {
                AsteroidExplosionAudio.Play();
                Destroy(col.gameObject);
                GameObject.Destroy(gameObject);
                s.score += 2;
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
                s.score--;
            }

            if (col.tag == "Bullet")
            {
                AsteroidExplosionAudio.Play();
                Instantiate(asteroid, this.transform.position, Quaternion.identity);
                Instantiate(asteroid, this.transform.position, Quaternion.identity);
                Instantiate(asteroid, this.transform.position, Quaternion.identity);
                Instantiate(asteroid, this.transform.position, Quaternion.identity);
                Instantiate(asteroid, this.transform.position, Quaternion.identity);
                Instantiate(asteroid, this.transform.position, Quaternion.identity);
                Instantiate(asteroid, this.transform.position, Quaternion.identity);
                Instantiate(asteroid, this.transform.position, Quaternion.identity);
                Instantiate(asteroid, this.transform.position, Quaternion.identity);
                GameObject.Destroy(gameObject);
                s.score += 9;
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
                s.score--;
            }

            else if (col.tag == "Bullet")
            {
                explosionAudio.Play();
                Instantiate(explosion, this.transform.position, Quaternion.identity);
                GameObject.Destroy(gameObject);
                s.score++;
            }
        }

        if (health == true)
        {
            if (col.tag == "Player")
            {
                GameObject player;
                player = GameObject.Find("Player");
                hM = player.gameObject.GetComponent<HealthManager>();
                hM.Heal();
                Debug.Log("Healed");
                GameObject.Destroy(gameObject);
                s.score--;
            }

            if (col.tag == "Bullet")
            {
                AsteroidExplosionAudio.Play();
                Destroy(col.gameObject);
                GameObject.Destroy(gameObject);
                s.score -= 5;
            }
        }

    }
}
