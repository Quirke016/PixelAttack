using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    float waitTime;


    #region type

    [SerializeField] GameObject regular;
    [SerializeField] GameObject splitter;
    [SerializeField] GameObject explosive;
    [SerializeField] GameObject shooting;
    [SerializeField] GameObject alive;
    [SerializeField] GameObject oblong;
    [SerializeField] GameObject mine;

    #endregion

    private void Start()
    {
        StartCoroutine(SpawnAsteroid());
    }



    public IEnumerator SpawnAsteroid()
    {
        waitTime = Random.Range(1.2f, 5.5f);
        int type;


        GameObject asteroid = regular;

        float coinToss;
        coinToss = Random.Range(0f, 2f);
        if (coinToss > 1f)
        { 
            asteroid = regular;
        }

        if (coinToss < 1f)
        {

            type = Random.Range(1, 7);
            if (type == 1)
            {
                asteroid = explosive;
            }

            if (type == 2)
            {
                asteroid = splitter;
            }

            if (type == 3)
            {
                asteroid = mine;
            }

            if (type == 4)
            {
                asteroid = shooting;
            }
            if (type == 5)
            {
                asteroid = alive;
            }

            if (type == 6)
            {
                asteroid = oblong;
            }
        }
        




        yield return new WaitForSeconds(waitTime);

        Vector2 randomPositionOnScreen = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
        Instantiate(asteroid, randomPositionOnScreen, Quaternion.identity);

        StartCoroutine(SpawnAsteroid());
    }
}
