using UnityEngine.UI;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    GameObject[] enemies;
    public Text enemyCounter;
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCounter.text = "Enemies:" + enemies.Length.ToString();
    }

    
}
