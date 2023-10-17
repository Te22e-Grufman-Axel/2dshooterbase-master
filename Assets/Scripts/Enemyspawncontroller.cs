using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemyspawncontroller : MonoBehaviour
{

    [SerializeField]
    GameObject EnemyPrefab;

float timer = 0;

    [SerializeField]
float timebetweenenemys = 1.5f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

      timer += Time.deltaTime;

if (timer > timebetweenenemys)
{

        Instantiate(EnemyPrefab);
        timer=0;
}
    }
}
