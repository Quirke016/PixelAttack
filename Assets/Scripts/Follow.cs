using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Follow : MonoBehaviour
{
    public GameObject leader;
    public GameObject follower;
    public bool canFollow;

    // Start is called before the first frame update
    void Awake()
    {
        canFollow = true;
        GameObject player = GameObject.Find("Player");
        leader = player;
        follower = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (canFollow)
        follower.transform.position = leader.transform.position;
    }
}
