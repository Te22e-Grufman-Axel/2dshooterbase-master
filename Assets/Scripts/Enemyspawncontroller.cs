using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemyspawncontroller : MonoBehaviour
{

    [SerializeField]
    GameObject EnemyPrefab;
    [SerializeField]
    GameObject Enemy2Prefab;
    [SerializeField]
    GameObject BossPrefab;


    float leveltimer = 0;

    [SerializeField]                                   //variablar
    float timebetweenlevels = 30;

    float timer = 0;

    [SerializeField]
    float timebetweenenemys1 = 1.5f;
    [SerializeField]
    float timebetweenenemys2 = 5;
    [SerializeField]
    float timebetweenboss = 10;


    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        leveltimer += Time.deltaTime;

        if (leveltimer < timebetweenlevels)                      //om den ska skapa en level 1 fiende
        {

            if (timer > timebetweenenemys1)
            {

                Instantiate(EnemyPrefab);
                timer = 0;
            }
        }
        else if (leveltimer > timebetweenlevels && leveltimer < 2 * timebetweenlevels)
        {
            if (timer > timebetweenenemys2)
            {

                Instantiate(Enemy2Prefab);                                //om den ska skapa en level 2 fiende
                timer = 0;
            }
        }
        else if (leveltimer > 2 * timebetweenlevels && leveltimer < 4* timebetweenlevels) 
        {
            if (timer > timebetweenboss)
            {

                Instantiate(BossPrefab);                      //om den ska skapa en boss

                timer = 0;
            }
        }
        else if (leveltimer > 4 * timebetweenlevels)
        {                      //så att den skapar en boss väldigt offta
            for (int i = 0; i < 20; i++)
            {
                Instantiate(BossPrefab);
            }



        }
    }
}
