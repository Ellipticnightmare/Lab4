using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public ActorController thisHolder;
    public GameManager gameMgr;
    [Range(1, 20)]
    public int bulletLifeTime;
    float lifeTime;
    private void Start()
    {
        lifeTime = bulletLifeTime;
    }
    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 10;
        if (lifeTime >= 0)
            lifeTime -= Time.deltaTime;
        else
            DestroyBullet();
    }

    public void Setup(ActorController actor)
    {
        thisHolder = actor;
        transform.rotation = thisHolder.transform.rotation;
        gameMgr = thisHolder.GetComponent<GameManager>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("base"))
            gameMgr.GameOver();
        DestroyBullet();
    }
    public void DestroyBullet()
    {
        thisHolder.firedBullet = null;
        Destroy(this.gameObject);
    }

    public void OnBecameInvisible() {
        DestroyBullet();
     }
}
