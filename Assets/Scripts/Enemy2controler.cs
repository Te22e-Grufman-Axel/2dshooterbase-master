using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy2controler : MonoBehaviour
{
    GameObject player;

    [SerializeField]
    GameObject Explosionprefab;

    int enemy2hp = 2;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Ship");

        float x = Random.Range(-10f, 10f);                                             //vart den spawnar
        Vector2 pos = new Vector2(x, Camera.main.orthographicSize + 2);

        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 4;
        Vector2 movement = new Vector2(0, speed) * Time.deltaTime * -1;

        transform.Translate(movement);

        if (transform.position.y < -Camera.main.orthographicSize - 1)                                          //rörelse och så den försviner om den kommer igenm och du förlorar hå
        {
            GameObject.Destroy(this.gameObject);
            player.GetComponent<ShipController>().currenthp -= 25;
            player.GetComponent<ShipController>().updatehpslider();

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Player")
        {
            enemy2hp--;
            if (enemy2hp <= 0)
            {
                Destroy(this.gameObject);                                            //Så att den dör om man skuter den 2 gånger
                GameObject explosion = Instantiate(Explosionprefab, transform.position, Quaternion.identity);
                Destroy(explosion, 0.4f);
            }
        }
    }
}
