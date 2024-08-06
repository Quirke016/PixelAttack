using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timer;
    float timerTime = 60;
    public SceneSwitch sS;

    public void Update()
    {
        timerTime -= Time.deltaTime;
        timer.text = ((int)timerTime).ToString();

        if (timerTime <= 0.1f)
        {
            sS.ToWinScreen();
        }

        bool triggeronce = true;
        if (timerTime <= 59 && timerTime >= 9 && triggeronce)
        {
            StartCoroutine(Flash());
            triggeronce = false;
        }
    }

    IEnumerator Flash()
    {
        yield return new WaitForSeconds(0.2f);
        timer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        timer.color = Color.yellow;
        yield return new WaitForSeconds(0.2f);
        timer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        timer.color = Color.white;
            StartCoroutine(Flash());
        

    }
}
