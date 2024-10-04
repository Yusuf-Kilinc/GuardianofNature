using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public Vector2 pos1;
    public Vector2 pos2;
    public float leftrightspeed;
    private float oldPosition;

    public float distance;

    private Transform target;
    public float followspeed;
    public LayerMask playerLayer;

    private Animator anim;

    float distanceToPlayer;

    public Transform attacPoint;
    public LayerMask EnemyLayers;
    public float attackRange = 0.5f;
    public int attackDamage = 40;

    public GameObject AttackSensoreCont;

    void Start()
    {
        Physics2D.queriesStartInColliders = false;

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, target.position);

        EnemyAa();
    }

    void EnemyMove()
    {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * leftrightspeed, 1.0f));

        if (transform.position.x > oldPosition)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        if (transform.position.x < oldPosition)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        oldPosition = transform.position.x;

    }

    void EnemyAa()
    {
        Vector3 rayOrigin = transform.position + new Vector3(0, 1.0f, 0); // Karakterin ortasýndan baþlatma
        RaycastHit2D hitEnemy = Physics2D.Raycast(rayOrigin, -transform.right, distance, playerLayer);
        if (hitEnemy.collider != null)
        {
            Debug.DrawLine(rayOrigin, hitEnemy.point, Color.red);  // Çizgi kýrmýzý
            EnemyFollow();

            if (distanceToPlayer < 2.0f)
            {
                anim.SetBool("Attack", true);
                Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attacPoint.position, attackRange, EnemyLayers);
                foreach (Collider2D enemy in hitEnemys)
                {
                    //Debug.Log("ZararVerdi." + enemy.name);

                    enemy.GetComponent<HealthSystem>().TakeDamage(attackDamage);

                }
            }
        }
        else
        {
            Debug.DrawLine(rayOrigin, rayOrigin - transform.right * distance, Color.green);  // Çizgi yeþil
            anim.SetBool("Attack", false);
            EnemyMove();
        }
    }

    void EnemyFollow()
    {
        Vector3 targetPosition = new Vector3(target.position.x, gameObject.transform.position.y, target.position.x);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, followspeed * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        if (attacPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attacPoint.position, attackRange);
    }

    public void AttacksensoreTrue()
    {
        AttackSensoreCont.SetActive(true);
    }
    public void AttacksensoreFalse()
    {
        AttackSensoreCont.SetActive(false);
    }

}
