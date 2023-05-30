using UnityEngine;
using UnityEngine.AI;

public class JosephStalin : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public Rigidbody rb;
    public float jumpForce;
    public float dashForce;

    public float health;
    //gun related variables begin here
    public int damage;
    public float timeBetweenShooting, spread, range, timeBetweenShots;
    public int bulletsPerTap;

    bool shooting, readyToShoot;

    //public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    public GameObject muzzleFlash;
    public ParticleSystem flash;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //Jumping
    public float playerHeight;
    bool grounded;
    public bool readyToJump;
    public float jumpInterval;
    float time;
    Vector3 dash;


    private void Awake()
    {
        grounded = true;
        time = 0f;
        Debug.Log("STALIN HATH AWOKEN");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        readyToShoot = true;
        readyToJump = true;
        //first jumpInterval is when the function first calls, second jumpInterval is the actual regular time interval between jumps
        InvokeRepeating("Jump", jumpInterval, jumpInterval);
    }

    private void Update()
    {




        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        // Debug.Log(playerInSightRange+" THIS IS THE BOOL OF WHETHER PLAYER IN SIGHT RANGE");
        // Debug.Log(playerInSightRange + " THIS IS THE BOOL OF WHETHER PLAYER IN ATTACK RANGE");

        if (!playerInSightRange && !playerInAttackRange)
        {
            //   Debug.Log("PATROLLING REQUIREMNTS MET");
            Patroling();
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            //   Debug.Log("CHASING REQUIREMNTS MET");
            ChasePlayer();
        }
        if (playerInAttackRange && playerInSightRange)
        {
            //  Debug.Log("ATTACKING REQUIREMNTS MET");
            AttackPlayer();
        }



    }

    private void Patroling()
    {

        // Debug.Log("PATROLLING");
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        Debug.Log("CHASING");
        agent.SetDestination(player.position);
    }

    private void Jump()
    {


        Debug.Log("JUMP FUNCTION ACCESSED");

        if (agent.enabled)
        {

            agent.SetDestination(transform.position);
            // disable the agent
            agent.updatePosition = false;
            agent.updateRotation = false;
            agent.isStopped = true;
        }
        // make the jump
        rb.isKinematic = false;
        rb.useGravity = true;

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        rb.AddForce(transform.forward * dashForce, ForceMode.Impulse);

        //  grounded = false;

    }
    private void AttackPlayer()
    {
        Debug.Log("ATTACKING");
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //Attack code here
            float x = Random.Range(-spread, spread);
            float y = Random.Range(-spread, spread);

            Vector3 direction = attackPoint.transform.forward + new Vector3(x, y, 0);

            if (Physics.Raycast(attackPoint.transform.position, direction, out rayHit, range))
            {

                Target target = rayHit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }
            }

            flash.Play();
            //Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            //rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            //rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            //End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    public void jumpReset()
    {
        if (agent.enabled)
        {
            agent.updatePosition = true;
            agent.updateRotation = true;
            agent.isStopped = false;
        }
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            jumpReset();
        }
    }
}
