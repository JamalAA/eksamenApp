using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KillMonster : MonoBehaviour
{
    public GameObject pickupEffectDeath;
    public GameObject pickupEffectDamage;

    public int maxSpeed;
    public float MonsterH;
    public static float Health = 100;
    public GameObject move;
    private float dmg = 15;
    public GameObject MonsterHealth;
    public GameObject dmgText;
    //public GameObject scoreText;

    public static int scoreValue;

    void Awake()
    {
        Health = MonsterH;
    }
    
    // Update is called once per frame
    void Update()
    {
        
        move.transform.Rotate(Vector3.up, maxSpeed * Time.deltaTime);
        MonsterHealth.GetComponent<Text>().text = "Monster health is: " + Health;
        dmgText.GetComponent<Text>().text = "Your damage is: " + dmg;
        //PlayerAttack.updateMonsterHealth(Health);
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fire") && Health > 0)
        {
            DamageControl();


        }
        if (other.CompareTag("Fire") &&  Health < 0)
        {
            PickUp();
        }

        
    }


    void PickUp()
    {

        Instantiate(pickupEffectDeath, transform.position, transform.rotation);
        MonsterHealth.GetComponent<Text>().text = "Monster health is: " + 0;
        Destroy(gameObject);
        Debug.Log("det virker");
    }

    void DamageControl()
    {
        Instantiate(pickupEffectDamage, transform.position, transform.rotation);
        Health -= dmg;

    }

    public static void resetMonsterHealth()
    {
        Health = 100;
    }
}
