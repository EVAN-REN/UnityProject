using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavelinWeapon : Weapon
{
    public GameObject bulletPrefab;
    public float bulletSpeed;
    private GameObject bullet;
    private void Start() {
        Initialize();
    }

    public override void Attack()
    {
        if(bullet != null && bullet.activeSelf){
            bullet.SetActive(false);
            GameObject bulletGo = GameObject.Instantiate(bulletPrefab, transform.position,transform.rotation);
            bulletGo.GetComponent<Rigidbody>().velocity = bulletSpeed * transform.forward;
            bulletGo.transform.parent = null;
            Destroy(bulletGo, 10f);
            Invoke("SpawnBullet", 0.5f);
        }else{
            return;
        }
        
    }

    private void Initialize(){
        bullet = GameObject.Instantiate(bulletPrefab, transform.position,transform.rotation);
        bullet.transform.parent = transform;
        bullet.GetComponent<Collider>().isTrigger = true;

        if(tag == Tag.ITERACTABLE){
            Destroy(bullet.GetComponent<JavelinBullet>());

            bullet.tag = Tag.ITERACTABLE;
            PickableObject po =  bullet.AddComponent<PickableObject>();
            po.itemSO = GetComponent<PickableObject>().itemSO;
            bullet.GetComponent<Collider>().isTrigger = false;

            Rigidbody rgb = bullet.GetComponent<Rigidbody>();
            rgb.useGravity = true;
            rgb.constraints = ~RigidbodyConstraints.FreezeAll;

            bullet.transform.parent = null;
            Destroy(gameObject);
        }
    }

    private void SpawnBullet(){
        bullet.SetActive(true);   
    }
}
