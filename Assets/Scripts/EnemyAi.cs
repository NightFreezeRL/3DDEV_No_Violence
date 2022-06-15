
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] Animator anim1;
    Animator hmm;
    public NavMeshAgent agent;
    SignCode signup;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public Transform enemyPos;
    public Transform playerPos;
    //Patroling
    public Vector3 walkPoint;
    public float walkPointRange;


    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public bool playerSignRaised;
    public bool enemyPatrol = true;
    private void Awake()
    {
        

        hmm = anim1.GetComponent<Animator>();
        player = GameObject.Find("PlayerObj").transform;
        agent = GetComponent<NavMeshAgent>();
        signup = GameObject.Find("PlayerObj").GetComponent<SignCode>();
        playerPos = player;
        enemyPos = transform;
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        playerSignRaised = signup.IsUP;

        if(!playerInAttackRange && !playerInSightRange){
            SearchWalkPoint();
            Patroling();
        }
        if (playerInSightRange && !playerInAttackRange) {
            ChasePlayer();
        }
        if (playerInAttackRange && playerInSightRange) {
            AttackPlayer();
        }
        if(playerSignRaised){
            agent.ResetPath();
            anim1.SetBool("Walk", false);
        }
    }

    private void Patroling()
    {
        agent.SetDestination(walkPoint);
        anim1.SetBool("Walk", true);
    
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
    }

    private void ChasePlayer()
    {
        transform.LookAt(player);
        agent.SetDestination(player.position);
        anim1.SetBool("Walk", true);
    }

    private void AttackPlayer()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
