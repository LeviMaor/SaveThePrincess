using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    
    public float stoppingDistance;
    private Transform playerToAttack;

   

    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    
    private bool movingLeft;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;

    private void Awake()
    {
        playerToAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
   
    private void Update()
    {
        
        
            if (Vector2.Distance(transform.position, playerToAttack.position) > stoppingDistance)
            {
                      transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * Direction() ,
                       transform.localScale.y, transform.localScale.z);
                        anim.SetBool("moving", true);
                        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x , transform.position.y), new Vector2(playerToAttack.position.x, transform.position.y), speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("moving", false);
            transform.position = new Vector2(transform.position.x, transform.position.y);
        }
        

       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            anim.SetBool("moving", false);
             transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y,transform.localScale.z);
        }
    }
    private int Direction()
    {
        if (transform.position.x > playerToAttack.position.x)
            return -1;
        else
            return 1;
    }
}
