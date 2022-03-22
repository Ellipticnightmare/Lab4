using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : ActorController
{
    public int score;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            GameManager.HitEnemy(score);
            Destroy(this.gameObject);
        }
    }
}