using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;
    public float time;

    private void Update()
    {
        time += Time.deltaTime;
    }
}
