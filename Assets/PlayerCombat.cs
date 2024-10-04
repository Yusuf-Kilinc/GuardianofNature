using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attacPoint;
    public LayerMask EnemyLayers;
    public float attackRange = 0.5f;
    public int attackDamage = 40; 
    public void DamageEnemy()
    {
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attacPoint.position, attackRange, EnemyLayers);
        foreach (Collider2D enemy in hitEnemys)
        {
            //Debug.Log("ZararVerdi." + enemy.name);

            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);

        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attacPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attacPoint.position, attackRange);
    }
}