
using UnityEngine;

public class MeleAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    public Animator anim;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public float attackDamamge;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()

       
    {

         if (Input.GetKeyDown(KeyCode.X) && cooldownTimer > attackCooldown && playerMovement.canAttack())
        {
            SwordAttack();
        }
        cooldownTimer += Time.deltaTime;
    }

    void SwordAttack()
    {
        anim.SetTrigger("attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().TakeDamage(attackDamamge);
        }
        cooldownTimer = 0;
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
