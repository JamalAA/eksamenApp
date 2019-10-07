using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterA : MonoBehaviour
{



    public Rigidbody Monsterprojectile;
    public Transform MonsterSpawnpoint;
    public Transform MonsterSpawnpointB;
    public Transform MonsterSpawnpointC;


    public GameObject player;
    bool fireNow = false;
    float coolDown = 2;
    // Update is called once per frame

    private Transform Spawnpoint;

    public GameObject pickupEffectDeath;
    public GameObject pickupEffectDamage;

    public int maxSpeed;
    public float monsterHealth = 100.0f;
    public float monsterHealthB = 100.0f;
    public float monsterHealthC = 100.0f;
    //public GameObject move;
    private float dmg = 15;
    public GameObject MonsterHealthText;
    public GameObject dmgText;
  


    // Update is called once per frame
    void Update()
    {

        //move.transform.Rotate(Vector3.up, maxSpeed * Time.deltaTime);
        MonsterHealthText.GetComponent<Text>().text = "Monster health is: " + monsterHealth;
        dmgText.GetComponent<Text>().text = "Your damage is: " + dmg;

        coolDown -= Time.deltaTime;
        if (fireNow && coolDown <= 0)
        {
            Shoot();
            coolDown = 2;
        }
        if (monsterHealth < 100)
        {
            fireNow = true;
            Spawnpoint = MonsterSpawnpoint;
        }
  

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fire") && monsterHealth > 0)
        {
            DamageControl();


        }
        if (other.CompareTag("Fire") && monsterHealth < 0)
        {
            PickUp();
        }

  

    }


    void PickUp()
    {

        Instantiate(pickupEffectDeath, transform.position, transform.rotation);
        MonsterHealthText.GetComponent<Text>().text = "Monster health is: " + 0;
        Destroy(gameObject);
        monsterHealth = 100;
        Debug.Log("det virker");
    }

    void DamageControl()
    {
        Instantiate(pickupEffectDamage, transform.position, transform.rotation);
        monsterHealth -= dmg;

    }


    void Shoot()
    {
        Rigidbody clone;
        clone = (Rigidbody)Instantiate(Monsterprojectile, Spawnpoint.position, Monsterprojectile.rotation);

        Vector3 shoot = (player.transform.position - clone.position).normalized;
        clone.AddForce(shoot * 500.0f);
        Destroy(clone.gameObject, 5f);
        print("shoot");
    }




}
