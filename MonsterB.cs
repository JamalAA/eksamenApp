using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterB : MonoBehaviour
{


    public Rigidbody MonsterprojectileB;
    public Transform MonsterSpawnpointB;


    public GameObject player;
    bool fireNowB = false;
    float coolDownB = 2;
    // Update is called once per frame



    public GameObject pickupEffectDeathB;
    public GameObject pickupEffectDamageB;

    public int maxSpeedB;
    float monsterHealthB = 100;
    //public GameObject move;
    private float dmgB = 15;
    public GameObject MonsterHealthTextB;
    public GameObject dmgTextB;



    // Update is called once per frame
    void Update()
    {
        print("monsterb :"+monsterHealthB);
        //move.transform.Rotate(Vector3.up, maxSpeed * Time.deltaTime);
        MonsterHealthTextB.GetComponent<Text>().text = "Monster health is: " + monsterHealthB;
        dmgTextB.GetComponent<Text>().text = "Your damage is: " + dmgB;

        coolDownB -= Time.deltaTime;
        if (fireNowB && coolDownB <= 0)
        {
            Shoot();
            coolDownB = 2;
        }
        if (monsterHealthB < 100)
        {
            fireNowB = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fire") && monsterHealthB > 0)
        {
            DamageControl();


        }
        if (other.CompareTag("Fire") && monsterHealthB < 0)
        {
            PickUp();
        }


    }


    void PickUp()
    {

        Instantiate(pickupEffectDeathB, transform.position, transform.rotation);
        MonsterHealthTextB.GetComponent<Text>().text = "Monster health is: " + 0;
        Destroy(gameObject);
        monsterHealthB = 100;
        Debug.Log("det virker");
    }

    void DamageControl()
    {
        Instantiate(pickupEffectDamageB, transform.position, transform.rotation);
        monsterHealthB -= dmgB;

    }


    void Shoot()
    {
        Rigidbody clone;
        clone = (Rigidbody)Instantiate(MonsterprojectileB, MonsterSpawnpointB.position, MonsterprojectileB.rotation);

        Vector3 shoot = (player.transform.position - clone.position).normalized;
        clone.AddForce(shoot * 500.0f);

        print("shoot");
    }


}
