using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] GameObject hp1;
    [SerializeField] GameObject hp2;
    [SerializeField] GameObject hp3;
    bool hp1Active = true;
    bool hp2Active = true;
    bool hp3Active = true;
    bool finalhp = false;

    [SerializeField] bool godMode = false; //for testing

    public SceneSwitch sS;
    [SerializeField] GameObject player;
    [SerializeField] AudioSource hitAudio;
    private void Start()
    {
        hp1Active = true;
        hp2Active = true;
        hp3Active = true;
        finalhp = false;

    }


    public void Damage()
    {
        Debug.Log("Ouch");
        hitAudio.Play();
        if (hp1Active && hp2Active && hp3Active)
        {
            if (!godMode)
            {
                hp3.SetActive(false);
                hp3Active = false;
            }
            else
            {
                Debug.Log("In God Mode, HIT!");
            }
        }

        else if (hp1Active && hp2Active && !hp3Active)
        {
            hp2.SetActive(false);
            hp2Active = false;
        }

        else if (hp1Active && !hp2Active && !hp3Active)
        {
            hp1.SetActive(false);
            hp1Active = false;
            finalhp = true;
        }

        else if (finalhp)
        {
            sS.ToDieScreen();
            hp1Active = true;
            hp2Active = true;
            hp3Active = true;
            finalhp = false;
        }
    }

    public void Heal()
    {
        Debug.Log("Yummy!");
        hitAudio.Play(); // make this heal audio
        if (!hp1Active && !hp2Active && !hp3Active)
        {
                hp1.SetActive(true);
                hp1Active = true;
                finalhp = false;
        }

        else if (hp1Active && !hp2Active && !hp3Active)
        {
            hp2.SetActive(true);
            hp2Active = true;
        }

        else if (hp1Active && hp2Active && !hp3Active)
        {
            hp3.SetActive(true);
            hp3Active = true;

        }

        else if (hp1Active && hp2Active && hp3Active)
        {
            Debug.Log("Your At Full HP you Dummy!");
        }

     }
}
