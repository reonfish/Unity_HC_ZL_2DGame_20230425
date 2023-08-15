using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float attack;
    public void Awake() 
    {
        Destroy(gameObject, 4);
    }
}
