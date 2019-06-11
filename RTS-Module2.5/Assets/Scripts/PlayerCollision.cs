using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerCollision : MonoBehaviour {

    int PlayerHealth = 300;

    void Start()
    {

    }

	// Update is called once per frame
	void Update()
    {
		
        if (PlayerHealth <= 0)
        {
            //death
            Debug.Log("Rip Vr Player");
        }

	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            PlayerHealth -= 10;
        }

        if ((collision.gameObject.GetComponent<HeldObject>().name == "GibTorso") || (collision.gameObject.GetComponent<HeldObject>().name == "Gib"))
        {
            collision.gameObject.SetActive(false);
            PlayerHealth += 5;
        }
    }
}
