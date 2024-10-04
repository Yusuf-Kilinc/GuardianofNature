using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public Vector2 pos1;
    public Vector2 pos2;
    public float leftRightSpeed;
    private float oldPosition;
    public bool Walk;
    public Animator anim;

    public float distance;
    private Transform target;
    public float FallwSpeed;
    float asasasa;
    public void Start()
    {
        Physics2D.queriesStartInColliders = false;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    
    public void Update()
    {
        EnemyMove();
        EnemyAa();
    }

    public void EnemyMove()
    {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * leftRightSpeed, 1.0f));
        //Walk = true;
        anim.SetInteger("AnimState", 2);

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
        RaycastHit2D hitenemy = Physics2D.Raycast(transform.position, -transform.right, distance);

        if (hitenemy.collider != null)
        {
            Debug.DrawLine(transform.position, hitenemy.point, Color.red);
            anim.SetTrigger("Attack");

        }
        else
        {
            Debug.DrawLine(transform.position, transform.position - transform.right * distance, Color.green);
            anim.SetInteger("AnimState", 2);

        }
    }
    
    public void EnemyFollow()
    {
        Vector3 targetPosition = new Vector3(target.position.x, gameObject.transform.position.y, target.position.x);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, FallwSpeed * Time.deltaTime);
    }

}
