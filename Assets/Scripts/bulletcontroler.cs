using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltController : MonoBehaviour
{


  // Update is called once per frame
  void Update()
  {
    float speed = 8;

    Vector2 movement = new Vector2(0, speed) * Time.deltaTime;

    transform.Translate(movement);

    if (transform.position.y > Camera.main.orthographicSize + 1)
    {
      GameObject.Destroy(this.gameObject);
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    Debug.Log(other.gameObject.tag);

    if (other.gameObject.tag == "Enemy")
    {
      Destroy(this.gameObject);
    }
  }



}