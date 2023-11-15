using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    int maxhp = 100;
    public int currenthp;

    string Speedbost = "";

    [SerializeField]
    float speed = 7.5f; // rutor per sekund

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

    [SerializeField]
    float speedtimmer = 0;
    private void Awake()
    {
        currenthp = maxhp;
        updatehpslider();
    }
    // Update is called once per frame
    void Update()
    {
        if (currenthp <= 0)
        {
            SceneManager.LoadScene(2);             //om man dör så byts scenen
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX, moveY);                     //rörelse
        movement = movement.normalized * speed * Time.deltaTime;

        transform.Translate(movement);
        updatehpslider();


        shotTimer += Time.deltaTime;

        if (Input.GetAxisRaw("Jump") > 0 && shotTimer > timeBetweenShots)                           // Skjutakod
        {
            Instantiate(bulletPrefab, gunPosition.position, Quaternion.identity);
            shotTimer = 0;
        }

        if (Speedbost == "True")
        {
            speedtimmer += Time.deltaTime;
            if (speedtimmer <= 30)
            {
                speed = 20;                           //speedbost kod
            }
            else if (speedtimmer > 30)
            {
                speed = 7.5f;
                speedtimmer = 0;
                Speedbost = "false";
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            currenthp -= 10;
            updatehpslider();                             //om man kolideran med en level 1 fiende
        }
        else if (other.gameObject.tag == "Enemy2")
        {
            currenthp -= 20;
            updatehpslider();                            //om man kolideran med en level 2 fiende
        }
        else if (other.gameObject.tag == "Boss")
        {
            currenthp -= 40;                            //om man kolideran med en boss
            updatehpslider();
        }
        else if (other.gameObject.tag == "Vanlig hjärta")
        {
            if (currenthp + 30 > maxhp)
            {
                currenthp = maxhp;
            }
            else if (currenthp + 30 < maxhp)                            //om man kolideran med en vanligt hjärta
            {
                currenthp = currenthp + 30;
            }
            updatehpslider();
        }
        else if (other.gameObject.tag == "Guldhjärta")
        {
            maxhp = maxhp + 30;
            if (currenthp + 60 > maxhp)
            {
                currenthp = maxhp;
            }
            else if (currenthp + 60 < maxhp)                            //om man kolideran med en guld hjärta
            {
                currenthp = currenthp + 60;
            }
            updatehpslider();
        }
        else if (other.gameObject.tag == "Speedbost")                            //om man kolideran med en speedbost
        {
            Speedbost = "True";
        }
    }

    public void updatehpslider()
    {
        healtslider.maxValue = maxhp;                   //kod för att uppdatera
        healtslider.value = currenthp;

        HealtText.text = currenthp + "/" + maxhp;
    }
}
