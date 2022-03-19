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
}