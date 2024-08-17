using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    [SerializeField] float leftConstr = Screen.width;
    [SerializeField] float rightConstr = Screen.width;
    [SerializeField] float topConstr = Screen.height;
    [SerializeField] float bottomConstr = Screen.height;
    [SerializeField] float buffer = 0.1f;
    [SerializeField] Camera mainCam;
    [SerializeField] float distanceZ;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        distanceZ = Mathf.Abs(mainCam.transform.position.z + transform.position.z);
        leftConstr = mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, distanceZ)).x;
        rightConstr = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, distanceZ)).x;
        bottomConstr = mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, distanceZ)).y;
        topConstr = mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height, distanceZ)).y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x < leftConstr - buffer)
        {   
            transform.position = new Vector3(rightConstr - 0.10f, transform.position.y, transform.position.z);
        }

        if (transform.position.x > rightConstr)
        {
            transform.position = new Vector3(leftConstr, transform.position.y, transform.position.z);
        }

        if (transform.position.y < bottomConstr - buffer)
        {
            transform.position = new Vector3(transform.position.x, topConstr + buffer, transform.position.z);
        }

        if (transform.position.y > topConstr + buffer)
        {
            transform.position = new Vector3(transform.position.x, bottomConstr - buffer, transform.position.z);
        }









    }
}
