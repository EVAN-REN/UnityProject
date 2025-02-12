using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavelinBullet : MonoBehaviour
{
    private Rigidbody rgb;
    private Collider col;
    public int atkValue = 30;
    private void Start()
    {
        rgb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }
    private void OnCollisionEnter(Collision other) {
        if(other.collider.tag == Tag.PLAYER){
            return;
        }
        rgb.velocity = Vector3.zero;
        rgb.isKinematic = true;
        col.enabled = false;

        transform.parent = other.gameObject.transform;

        Destroy(this.gameObject, 3f);

        if(other.gameObject.tag == Tag.ENEMY){
            other.gameObject.GetComponent<Enemy>().TakeDamage(atkValue);
        }
    }
}
