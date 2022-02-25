using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveWall2 : MonoBehaviour
{

    GameObject[] enemies;


    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length <=3)
        {
            gameObject.SetActive(false);
        }
    }


}
