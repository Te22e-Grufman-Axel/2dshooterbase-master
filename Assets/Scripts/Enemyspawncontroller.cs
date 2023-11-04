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

    [SerializeField]
    float timebetweenlevels = 30;

    float timer = 0;

    [SerializeField]
    float timebetweenenemys1 = 1.5f;
    [SerializeField]
    float timebetweenenemys2 = 5;
    [SerializeField]
    float timebetweenboss = 20;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        leveltimer += Time.deltaTime;

        if (leveltimer < timebetweenlevels)
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

                Instantiate(Enemy2Prefab);
                timer = 0;
            }
        }
        else if (leveltimer > 2 * timebetweenlevels)
        {
            if (timer > timebetweenboss)
            {

                Instantiate(BossPrefab);
                timer = 0;
            }
        }
    }
}
