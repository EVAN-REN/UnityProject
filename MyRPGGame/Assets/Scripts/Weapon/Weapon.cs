using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class Weapon : MonoBehaviour
{
    public AnimatorController animatorController;
    protected GameObject player;
    public int attackValue = 40;
    public virtual void Attack(){}

    // protected Collider col;
}
