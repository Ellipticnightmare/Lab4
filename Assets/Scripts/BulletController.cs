using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public ActorController thisHolder;
    public GameManager gameMgr;

    private void Update()
    {
        transform.position += transform.up * Time.deltaTime * 10;
    }

    public void Setup(ActorController actor)
    {
        thisHolder = actor;
        transform.rotation = thisHolder.transform.rotation;
        gameMgr = thisHolder.GetComponent<GameManager>();
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("base"))
        {
            gameMgr.GameOver();
        }
        Debug.Log("bullet hit");
        thisHolder.firedBullet = null;
        Destroy(this.gameObject);
    }

    public void OnBecameInvisible() {
         Destroy(gameObject);
     }
}
