using UnityEngine;

public class NinjaFireballHolder : MonoBehaviour
{
   [SerializeField] private Transform enemy;

    private void Update()
    {
        transform.localScale = enemy.localScale;
    }
}
