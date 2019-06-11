using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HeldObject : MonoBehaviour {

    [HideInInspector]
    public Controller parent;
    public string name;
    public bool Held = false;
    public bool WeaponMode = false;

}
