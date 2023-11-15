using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bosscontroler : MonoBehaviour
{
    GameObject player;

    [SerializeField]                            //variablar
    GameObject Explosionprefab;

    int bosshp = 3;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Ship");

        float x = Random.Range(-10f, 10f);                                           //spawna bossen
        Vector2 pos = new Vector2(x, Camera.main.orthographicSize + 5);

        transform.position = pos;
    }
    // Update is called once per frame
    void Update()
    {
        float speed = 2;
        Vector2 movement = new Vector2(0, speed) * Time.deltaTime;

        transform.Translate(movement);

        if (transform.position.y < -Camera.main.orthographicSize - 1)                               //bossen rör sig och förstörs om den kommer för långt ner
        {
            GameObject.Destroy(this.gameObject);
            player.GetComponent<ShipController>().currenthp -= 50;
            player.GetComponent<ShipController>().updatehpslider();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Player")
        {
            bosshp--;
            if (bosshp <= 0)
            {
                Destroy(this.gameObject);                                //dödar bossen om man skuter den 3 gånger
                GameObject explosion = Instantiate(Explosionprefab, transform.position, Quaternion.identity);
                Destroy(explosion, 0.4f);
            }
        }
    }
}
