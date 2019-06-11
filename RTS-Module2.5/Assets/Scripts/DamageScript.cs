using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class DamageScript : MonoBehaviour
{

    public GameObject Gib1;
    public GameObject Gib2;
    public GameObject Gib3;
    public GameObject Gib4;
    
    [HideInInspector]
    public Controller parent;
    public string name;
    int finalDamage = 0;
    int health = 0;

    //Weapon types: Light, Medium, Heavy, ConsistentHeavy, Super, Samurai

    void Start()
    {
	    Gib1 = GameObject.Find("Gib1");
     	Gib2 = GameObject.Find("Gib2");
      	Gib3 = GameObject.Find("Gib3");
      	Gib4 = GameObject.Find("Gib4");

        if (name == "Grunt")
        {
            health = 3;
        }
        else if (name == "Knight")
        {
            health = 5;
        }
        else if (name == "Officer")
        {
            health = 10;
        }
        else if (name == "Kamakazi")
        {
            health = 1;
        }
    }
    
    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Enemy")
        {
            if (collision.gameObject.GetComponent<HeldObject>().Held == true)
            {
                switch (collision.gameObject.tag)
                {
                    case "Light":
                        finalDamage = Random.Range(1, 3);
                        this.health -= finalDamage;
                        Debug.Log("Weapon Type: " + collision.gameObject.tag + ". Final Damage: " + finalDamage);
                        break;
                    case "Medium":
                        finalDamage = Random.Range(2, 5);
                        this.health -= finalDamage;
                        Debug.Log("Weapon Type: " + collision.gameObject.tag + ". Final Damage: " + finalDamage);
                        break;
                    case "Heavy":
                        finalDamage = Random.Range(3, 7);
                        this.health -= finalDamage;
                        Debug.Log("Weapon Type: " + collision.gameObject.tag + ". Final Damage: " + finalDamage);
                        break;
                    case "ConsistentHeavy":
                        finalDamage = Random.Range(5, 6);
                        this.health -= finalDamage;
                        Debug.Log("Weapon Type: " + collision.gameObject.tag + ". Final Damage: " + finalDamage);
                        break;
                    case "Super":
                        finalDamage = Random.Range(5, 15);
                        this.health -= finalDamage;
                        Debug.Log("Weapon Type: " + collision.gameObject.tag + ". Final Damage: " + finalDamage);
                        break;
                    case "Samurai":
                        finalDamage = Random.Range(4, 9);
                        this.health -= finalDamage;
                        Debug.Log("Weapon Type: " + collision.gameObject.tag + ". Final Damage: " + finalDamage);
                        break;
                    case "Floor":
                        break;
                    case "EdibleLight":
                        finalDamage = Random.Range(1, 3);
                        this.health -= finalDamage;
                        break;
                    default:
                        Debug.Log("Weapon Type: " + collision.gameObject.tag + ". Final Damage: " + finalDamage);
                        break;

                }
            }

            if (health <= 0)
            {
                Vector3 tamps;
                tamps = this.transform.position;
                tamps.y += 2;
                Instantiate(Gib1, tamps, Quaternion.identity);
                Instantiate(Gib2, tamps, Quaternion.identity);
                Instantiate(Gib3, tamps, Quaternion.identity);
                Instantiate(Gib4, tamps, Quaternion.identity);
                this.gameObject.SetActive(false);
            }
            else
            {
                this.GetComponent<AIMain>().goal = this.GetComponent<AIMain>().SpawnPos;
            }

            if (this.GetComponent<AIMain>().goal = this.GetComponent<AIMain>().SpawnPos)
            {
                int temp = Random.Range(0, 2000);

                if (temp < 1)
                {
                    this.GetComponent<AIMain>().goal = GameObject.Find("Controller (right)").GetComponentInParent<Transform>();
                }
            }
        }
    }
}
