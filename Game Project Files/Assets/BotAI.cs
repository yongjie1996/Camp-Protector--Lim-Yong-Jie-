using System.Collections;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class BotAI : MonoBehaviour
{
    public enum AISTATE { CHASE = 0, ATTACK = 1 };

    public AISTATE CurrentState
    {
        get { return _CurrentState; }
        set
        {
            StopAllCoroutines();
            _CurrentState = value;
            switch (_CurrentState)
            {
                case AISTATE.CHASE:
                    StartCoroutine(StateChase());
                    break;
                case AISTATE.ATTACK:
                    StartCoroutine(StateAttack());
                    break;
            }
        }
    }
    private AISTATE _CurrentState = AISTATE.CHASE;

    private LevelInformation levelInfo;
    private NavMeshAgent nma = null;
    private Transform Player = null;
    private Health playerHealth = null;
    public float AttackRange = 2;
    public float ChaseRange = 3;
    public float AttackRate;
    public float AttackDamage;
    public float NormalSpeed = 3.5f;

    private void Awake()
    {
        levelInfo = GameObject.FindGameObjectWithTag("LevelInformation").GetComponent<LevelInformation>();
        if (gameObject.tag == "Goblin")
        {
            AttackDamage = levelInfo.goblinAttackCalculate();
        }
        if (gameObject.tag == "Wolf")
        {
            AttackDamage = levelInfo.wolfAttackCalculate();
        }
        nma = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("CampHitBox").transform;
        playerHealth = Player.GetComponent<Health>();
    }

    private void OnEnable()
    {
        CurrentState = AISTATE.CHASE;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public IEnumerator StateChase()
    {
        CancelInvoke();
        GetComponent<Animation>()["run"].wrapMode = WrapMode.Loop;
        GetComponent<Animation>()["attack01"].wrapMode = WrapMode.Once;
        GetComponent<Animation>().CrossFade("run");
        nma.SetDestination(Player.position);
        while (CurrentState == AISTATE.CHASE)
        {
            Collider[] findPlayer = Physics.OverlapSphere(gameObject.transform.position, 20f);
            foreach (Collider coll in findPlayer)
            {
                if (coll.gameObject.tag == "Player")
                {
                    Player = GameObject.FindGameObjectWithTag("Player").transform;
                    playerHealth = Player.GetComponent<Health>();
                }
            }
            nma.SetDestination(Player.position);
            float Range = Vector3.Distance(transform.position, Player.position);
            float MaxRange = AttackRange;

            if (Range < MaxRange)
            {
                CurrentState = AISTATE.ATTACK;
                yield break;
            }
            yield return null;
        }
    }

    public IEnumerator StateAttack()
    {
        GetComponent<Animation>()["run"].wrapMode = WrapMode.Once;
        GetComponent<Animation>()["attack01"].wrapMode = WrapMode.Once;
        InvokeRepeating("PlayAttack", 0f, AttackRate);
        nma.SetDestination(transform.position);
        if (Player.tag == "CampHitBox")
        {
            InvokeRepeating("CampDamage", 0f, AttackRate);
        }
        else if (Player.tag == "Player")
        {
            InvokeRepeating("PlayerDamage", 0.8f, AttackRate);
        }
        while (CurrentState == AISTATE.ATTACK)
        {
            nma.SetDestination(transform.position);
            Vector3 Dir = (Player.position - transform.position).normalized;
            Dir.y = 0;
            transform.rotation = Quaternion.LookRotation(Dir, Vector3.up);

            //Check distance
            float Range = Vector3.Distance(transform.position, Player.position);
            float MaxRange = AttackRange;

            if (Range > MaxRange)
            {
                CurrentState = AISTATE.CHASE;
                yield break;
            }

            yield return null;
        }
    }

    public void PlayAttack()
    {
        GetComponent<Animation>().CrossFade("attack01");
    }

    public void PlayDamage()
    {
        CancelInvoke();
        GetComponent<Animation>()["run"].wrapMode = WrapMode.Once;
        GetComponent<Animation>()["damage"].wrapMode = WrapMode.Once;
        GetComponent<Animation>().CrossFade("damage");
        stopBot();
        Invoke("loopRun", 0.8f);
    }

    public void PlayDead()
    {
        CancelInvoke();
        GetComponent<Animation>()["run"].wrapMode = WrapMode.Once;
        NavMeshAgent ourenemy = GetComponent<NavMeshAgent>();
        ourenemy.speed = 0;
        GetComponent<Animation>().Play("dead");
    }

    public void loopRun()
    {
        GetComponent<Animation>()["run"].wrapMode = WrapMode.Loop;
        GetComponent<Animation>().CrossFade("run");
        moveBot();
    }

    public void stopBot()
    {
        NavMeshAgent ourenemy = GetComponent<NavMeshAgent>();
        ourenemy.speed = 0;
    }

    public void moveBot()
    {
        NavMeshAgent ourenemy = GetComponent<NavMeshAgent>();
        ourenemy.speed = NormalSpeed;
    }

    public void CampDamage()
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(AttackDamage);
        }        
    }

    public void PlayerDamage()
    {
        float PlayerDistance;
        if (playerHealth != null)
        {
            PlayerDistance = CheckPlayerDistance();
            if (PlayerDistance <= AttackRange)
            {
                playerHealth.TakeDamage(AttackDamage);
            }            
        }
    }

    public float CheckPlayerDistance()
    {
        Transform PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        float dist = Vector3.Distance(PlayerTransform.position, transform.position);
        return dist;
    }
}