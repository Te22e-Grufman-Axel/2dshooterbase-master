using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerupspawner : MonoBehaviour
{

    [SerializeField]
    GameObject vanlighjärta;
    [SerializeField]
    GameObject guldhjärta;
    [SerializeField]
    GameObject Speedbost;


    int typavpowerup = 1;                           //variablar

    float timmer = 0;
    int timebetweenPowerups = 30;





    // Update is called once per frame
    void Update()
    {
        timmer += Time.deltaTime;
        typavpowerup = Random.Range(1, 4);
        if (timmer > timebetweenPowerups)
        {

            if (typavpowerup == 1)
            {
                Instantiate(vanlighjärta);
                timmer = 0;
            }
            if (typavpowerup == 2)                                    //så den väljer en random powerup och spawnar den
            {
                Instantiate(guldhjärta);
                timmer = 0;
            }
            if (typavpowerup == 3)
            {
                Instantiate(Speedbost);
                timmer = 0;
            }
        }
    }
}