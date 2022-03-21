using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public ActorController thisHolder;
    public void Setup(ActorController actor)
    {
        thisHolder = actor;
    }
    public void OnTriggerEnter(Collider other)
    {
        thisHolder.firedBullet = null;
        Destroy(this.gameObject);
    }
}