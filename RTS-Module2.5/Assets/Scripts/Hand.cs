using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller))]
public class Hand : MonoBehaviour
{

    GameObject heldObject;
    Controller controller;
    Rigidbody simulator;

    public bool leftHand = false;


    // Use this for initialization
    void Start()
    {
        simulator = new GameObject().AddComponent<Rigidbody>();
        simulator.name = "simulator";
        simulator.transform.parent = transform.parent;

        controller = GetComponent<Controller>();


    }

    // Update is called once per frame
    void Update()
    {
        if (heldObject)
        {
            simulator.velocity = (transform.position - simulator.position) * 50f;

            //On controller trigger release
            if (controller.controller.GetPressUp(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
            {
                heldObject.transform.parent = null;
                //Turn on Gravity
                heldObject.GetComponent<Rigidbody>().isKinematic = false;
                //Gives velocity of hand
                heldObject.GetComponent<Rigidbody>().velocity = simulator.velocity;
                heldObject.GetComponent<HeldObject>().Held = false;
                heldObject.GetComponent<HeldObject>().parent = null;
                heldObject = null;
            }
        }
        else
        {
            //On controller trigger press
            if (controller.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
            {
                this.transform.Find("HandText").gameObject.SetActive(false);
                //Gets all possible collidable objects within 0.1
                Collider[] cols = Physics.OverlapSphere(transform.position, 0.1f);

                foreach (Collider col in cols)
                {
                    //If the controller holds nothing, the object is holdable and the hold object is not already being held
                    if ((heldObject == null) && (col.GetComponent<HeldObject>()) && (col.GetComponent<HeldObject>().parent == null))
                    {
                        Vector3 temp;
                        heldObject = col.gameObject;
                        heldObject.transform.parent = transform;

                        switch (heldObject.GetComponent<HeldObject>().name)
                        {
                            case "Shield":
                                if (leftHand)
                                {
                                    temp.x = 0.2f;
                                    temp.y = 0.0f;
                                    temp.z = -0.2f;
                                    heldObject.transform.localPosition = temp;
                                    heldObject.transform.localRotation = (Quaternion.identity * Quaternion.Euler(90.0f, -90.0f, 1.0f));
                                }
                                else
                                {
                                    temp.x = -0.2f;
                                    temp.y = 0.0f;
                                    temp.z = -0.2f;
                                    heldObject.transform.localPosition = temp;
                                    heldObject.transform.localRotation = (Quaternion.identity * Quaternion.Euler(90.0f, 90.0f, 1.0f));
                                }
                                break;
                            case "Katana":
                                temp.x = 0.0f;
                                temp.y = 0.0f;
                                temp.z = -0.2f;
                                heldObject.transform.localPosition = temp;
                                heldObject.transform.localRotation = (Quaternion.identity * Quaternion.Euler(270.0f, 180.0f, 0.0f));
                                break;
                            case "Battleaxe":
                                temp.x = 0.0f;
                                temp.y = -0.02f;
                                temp.z = -0.1f;
                                heldObject.transform.localPosition = temp;
                                heldObject.transform.localRotation = (Quaternion.identity * Quaternion.Euler(90.0f, 1.0f, 1.0f));
                                break;
                            case "BigBoii":
                                temp.x = 0.0f;
                                temp.y = -0.02f;
                                temp.z = -0.45f;
                                heldObject.transform.localPosition = temp;
                                heldObject.transform.localRotation = (Quaternion.identity * Quaternion.Euler(90.0f, 1.0f, 1.0f));
                                break;
                            case "Spear":
                                if (heldObject.GetComponent<HeldObject>().WeaponMode == false)
                                {
                                    temp.x = 0.0f;
                                    temp.y = 0.0f;
                                    temp.z =  0.25f;
                                    heldObject.transform.localPosition = temp;
                                    heldObject.transform.localRotation = (Quaternion.identity * Quaternion.Euler(270.0f, 1.0f, 1.0f));
                                }
                                else
                                {
                                    temp.x = 0.0f;
                                    temp.y = -0.02f;
                                    temp.z = -0.1f;
                                    heldObject.transform.localPosition = temp;
                                    heldObject.transform.localRotation = (Quaternion.identity * Quaternion.Euler(90.0f, 1.0f, 1.0f));
                                }
                                break;
                            case "Gib":
                                temp.x = 0.0f;
                                temp.y = -0.02f;
                                temp.z = 0.1f;
                                heldObject.transform.localPosition = temp;
                                heldObject.transform.localRotation = (Quaternion.identity * Quaternion.Euler(90.0f, 1.0f, 1.0f));
                                break;
                            default:
                                temp.x = 0.0f;
                                temp.y = -0.02f;
                                temp.z = -0.1f;
                                heldObject.transform.localPosition = temp;
                                heldObject.transform.localRotation = (Quaternion.identity * Quaternion.Euler(90.0f, 1.0f, 1.0f));
                                break;
                        }

                        heldObject.GetComponent<HeldObject>().parent = controller;
                        heldObject.GetComponent<HeldObject>().Held = true;
                        //Turn off gravity
                        heldObject.GetComponent<Rigidbody>().isKinematic = true;
                    }
                }
            }
        }

        if (controller.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip))
        {
            if ((heldObject.GetComponent<HeldObject>().name == "Spear") || (heldObject.GetComponent<HeldObject>().name == "Switchblade"))
            {
                heldObject.GetComponent<HeldObject>().WeaponMode = !heldObject.GetComponent<HeldObject>().WeaponMode;
            }
        }

        if (heldObject)
        {
            if (heldObject.GetComponent<HeldObject>().WeaponMode == false)
            {
                this.transform.Find("WeaponModeText").gameObject.SetActive(false);
            }
            else
            {
                this.transform.Find("WeaponModeText").gameObject.SetActive(true);
            }
        }
    }
}
