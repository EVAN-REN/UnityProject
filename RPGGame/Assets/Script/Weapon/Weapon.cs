using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float attackValue;

    public virtual void Attack(){
        print("Attack");
    }
}
