using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class enemycontroller : MonoBehaviour
{
[SerializeField]
GameObject Explosionprefab;

GameObject player;

[SerializeField]
int currenthp;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Ship");

        float x = Random.Range(-7f, 7f);
        Vector2 pos = new Vector2(x, Camera.main.orthographicSize + 1);                        //vart den spawnar

        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 4;
        Vector2 movement = new Vector2(0, speed) * Time.deltaTime * -1;

        transform.Translate(movement);

        if (transform.position.y < -Camera.main.orthographicSize - 1)                          //Rörelse och så den försvinnar och du förlorar hp om den kommer igenom
        {
            GameObject.Destroy(this.gameObject);
            player.GetComponent<ShipController>().currenthp -= 15;
            player.GetComponent<ShipController>().updatehpslider();

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            GameObject explosion = Instantiate(Explosionprefab, transform.position, Quaternion.identity);                                         //så den försviner om du skuter den
            Destroy (explosion, 0.4f);
        }
    }




}
