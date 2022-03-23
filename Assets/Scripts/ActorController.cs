using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour
{
    public BulletController firedBullet;
    public GameObject bulletFab;
    public Transform firePoint;
    public virtual void fireBullet(Transform firePoint)
    {
        GameObject newBullet = Instantiate(bulletFab, firePoint.position, firePoint.rotation);
        firedBullet = newBullet.GetComponent<BulletController>();
        firedBullet.Setup(this);
    }
}