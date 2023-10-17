using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    int maxhp = 100;
    int currenthp;



    [SerializeField]
    float speed = 5; // rutor per sekund

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform gunPosition;

    float shotTimer = 0;

    [SerializeField]
    float timeBetweenShots = 0.5f;

    [SerializeField]
    Slider healtslider;

    [SerializeField]
    TMP_Text HealtText;

    private void Awake()
    {
        currenthp = maxhp;
        updatehpslider();
    }
    // Update is called once per frame
    void Update()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX, moveY);
        movement = movement.normalized * speed * Time.deltaTime;

        transform.Translate(movement);
        updatehpslider();
        // Skjutakod
        shotTimer += Time.deltaTime;

        if (Input.GetAxisRaw("Jump") > 0 && shotTimer > timeBetweenShots)
        {
            Instantiate(bulletPrefab, gunPosition.position, Quaternion.identity);
            shotTimer = 0;

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            currenthp -= 10;
            updatehpslider();


            if (currenthp <= 0)
            {
                SceneManager.LoadScene(2);
            }
        }
    }
    public void updatehpslider()
    {
        healtslider.maxValue = maxhp;
        healtslider.value = currenthp;

        HealtText.text = currenthp + "/" + maxhp;
    }
}