using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guldhjärtascript : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Ship");

        float x = Random.Range(-7f, 7f);
        Vector2 pos = new Vector2(x, Camera.main.orthographicSize + 2);                         //vart den spawnar

        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 1;
        Vector2 movement = new Vector2(0, speed) * Time.deltaTime * -1;

        transform.Translate(movement);

        if (transform.position.y < -Camera.main.orthographicSize - 2)                                  //så den rör sig neråt och försviner om den kommer för långt ner
        {
            GameObject.Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")                 //så den försviner om den rör spelaren
        {
            Destroy(this.gameObject);
        }
    }
}