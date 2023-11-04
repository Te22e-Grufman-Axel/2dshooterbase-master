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


    int typavpowerup = 1;

    float timmer = 0;
    int timebetweenPowerups = 30;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timmer += Time.deltaTime;
        typavpowerup = Random.Range(1, 5);
        if (timmer > timebetweenPowerups)
        {

            if (typavpowerup == 1)
            {
                Instantiate(vanlighjärta);
                timmer = 0;
            }
            if (typavpowerup == 2)
            {
                Instantiate(guldhjärta);
                timmer = 0;
            }
            if (typavpowerup == 3)
            {
                Instantiate(Speedbost);
                timmer = 0;
            }
            // if (typavpowerup == 4)
            // {

            // }
            // if (typavpowerup == 5)
            // {

            // }
        }
    }
}