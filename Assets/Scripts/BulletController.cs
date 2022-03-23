using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public ActorController thisHolder;

    private void Update()
    {
        transform.position += transform.up * Time.deltaTime * 10;
    }

    public void Setup(ActorController actor)
    {
        thisHolder = actor;
        transform.rotation = thisHolder.transform.rotation;
    }
    public void OnTriggerEnter(Collider other)
    {
        thisHolder.firedBullet = null;
        Destroy(this.gameObject);
    }
}
