using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrail : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject trail;
    Follow f;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        trail = other.gameObject;
        f = trail.GetComponent<Follow>();
        if (other == trail) 
        {
            StartCoroutine(StartTrail());
          f.canFollow = false;
        }
    }
    
    IEnumerator StartTrail()
    {

        yield return new WaitForSeconds(1.1f);

        Destroy(trail);
        Instantiate(trail, player.transform);
    }
}
