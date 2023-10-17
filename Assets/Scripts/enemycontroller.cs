using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class enemycontroller : MonoBehaviour
{
[SerializeField]
GameObject Explosionprefab;
[SerializeField]
int currenthp;


    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-5f, 5f);
        Vector2 pos = new Vector2(x, Camera.main.orthographicSize + 1);

        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 4;
        Vector2 movement = new Vector2(0, speed) * Time.deltaTime * -1;

        transform.Translate(movement);

        if (transform.position.y < -Camera.main.orthographicSize - 1)
        {
            GameObject.Destroy(this.gameObject);
            currenthp -= 10;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            GameObject explosion = Instantiate(Explosionprefab, transform.position, Quaternion.identity);
            Destroy (explosion, 0.4f);
        }
    }




}