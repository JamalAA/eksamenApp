using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float playerHealth = 100;


   

    private float dmg = 15;

    public GameObject playerHealthText;
    public static GameObject GameOverText;

  


    // Update is called once per frame
    void Update()
    {
        
        playerHealthText.GetComponent<Text>().text = "Your Health is: " + playerHealth;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("monsterFire") && playerHealth > 0)
        {
            DamageControl();



        }
        if (other.CompareTag("monsterFire") && playerHealth < 0)
        {
            PickUp();
        }


    }

    
     void PickUp()
    {
        //
        //GameOverText.GetComponent<Text>().text = "Game Over";
        SceneManager.LoadScene("Level1");
        KillMonster.resetMonsterHealth();
        Debug.Log("det virker");
    }

    void DamageControl()
    {
        //Instantiate(pickupEffectDamage, transform.position, transform.rotation);
        playerHealth -= dmg;

    }
}
