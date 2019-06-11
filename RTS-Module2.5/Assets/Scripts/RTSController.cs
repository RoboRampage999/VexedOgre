using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSController : MonoBehaviour
{

    public Transform prefab;
    // public Vector3 spawnPos;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, 100, LayerMask.NameToLayer("Terrain")))
            {
                if (hit.collider.tag == "SpawnArea")
                {
                    //spawnPos = hit.point;
                    Instantiate(prefab, hit.point, Quaternion.identity);
                }

                //Debug.Log(hit.point);
            }

        }


    }
}
