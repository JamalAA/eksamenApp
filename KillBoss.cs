using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KillBoss : MonoBehaviour
{
    public GameObject pickupEffectDeath;
    public GameObject pickupEffectDamage;

    
    public static float Health = 300;
    private float dmg = 35;
    public GameObject MonsterHealth;
    public GameObject dmgText;
   

   


    // Update is called once per frame
    void Update()
    {
       
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
        if (other.CompareTag("Fire") && Health < 0)
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
