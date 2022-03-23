using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : ActorController
{
    enemyState EnemyState = enemyState.Chase;
    public int score;
    public Transform targPos;
    float updateTarg;
    NavMeshPath path;
    NavMeshAgent agent;
    [Range(1, 10)]
    public float speed = 2.25f;
    [Range(1, 10)]
    public float rotSpeed = 5;
    public GameObject art;
    private void Start()
    {
        path = new NavMeshPath();
        EnemyState = GetRandomEnum<enemyState>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        if (EnemyState == enemyState.Attack)
            targPos = GameObject.FindGameObjectWithTag("baseTarget").transform;
        else
            targPos = GameObject.FindGameObjectWithTag("Player").transform;
        agent.speed = speed;
        agent.angularSpeed = rotSpeed + 80;
    }
    private void Update()
    {
        switch (EnemyState)
        {
            case enemyState.Chase:
                if (updateTarg >= 0)
                    updateTarg -= Time.deltaTime;
                else
                {
                    updateTarg = 5;
                    moveChase();
                }
                break;
            case enemyState.Hunt:
                moveHunt();
                break;
            case enemyState.Attack:
                moveAttack();
                break;
        }

        var lookPos = targPos.position - art.transform.position;
        Quaternion lookRot = Quaternion.LookRotation(lookPos);
        float eulerZ = lookRot.eulerAngles.z;
        Quaternion rotation = Quaternion.Euler(0, 0, eulerZ);
        art.transform.rotation = rotation;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            GameManager.HitEnemy(score, this.gameObject.name);
            Destroy(this.gameObject);
        }
    }
    #region Chasing Logic //Moving after player until they are spotted, then swapping to Hunting
    void moveChase()
    {
        agent.SetDestination(targPos.position);
        if (canSeeTarget())
            EnemyState = enemyState.Hunt;
    }
    #endregion
    #region Hunting Logic //Actively pursuing the player and trying to kill them
    void moveHunt()
    {
        agent.SetDestination(targPos.position);
        if (agent.remainingDistance <= 20 && canSeeTarget())
            fireBullet(firePoint);
    }
    #endregion
    #region Attacking Logic //Moving directly after Headquarters
    void moveAttack()
    {
        agent.SetDestination(targPos.position);
        if (agent.remainingDistance <= 20 && canSeeTarget())
            fireBullet(firePoint);
    }
    #endregion
    public override void fireBullet(Transform firePoint)
    {
        if (firedBullet == null)
            base.fireBullet(firePoint);
    }
    bool canSeeTarget()
    {
        bool output = false;
        RaycastHit hit;
        Vector3 fromPosition = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 toPosition = new Vector3(targPos.transform.position.x, 0, transform.position.z);
        Vector3 direction = toPosition - fromPosition;

        if (Physics.Raycast(fromPosition, direction, out hit))
            output = true;
        return output;
    }
    #region EnumLogic
    public enum enemyState
    {
        Chase,
        Hunt,
        Attack
    };
    static T GetRandomEnum<T>()
    {
        System.Array A = System.Enum.GetValues(typeof(T));
        T V = (T)A.GetValue(UnityEngine.Random.Range(0, A.Length));
        return V;
    }
    #endregion
}