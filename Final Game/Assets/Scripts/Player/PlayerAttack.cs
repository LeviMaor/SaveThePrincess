
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{   
   [SerializeField] private float fireAttackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    private Animator anim;
    private PlayerMovement playerMovement;
   
    private float fireCooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && fireCooldownTimer > fireAttackCooldown && playerMovement.canAttack())
        {
            FireBallAttack();
        }

       
        fireCooldownTimer += Time.deltaTime;
       
    }

    private void FireBallAttack()
    {
        anim.SetTrigger("fire");
        fireCooldownTimer = 0;

        //Pool fireballsd
        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

 

    private int FindFireball()
    {
        for(int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
            {
                return i;
            }

        }
        return 0;
    }


}
