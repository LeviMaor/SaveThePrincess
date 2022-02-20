using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private float previousSpeed;
    [SerializeField] private float dashFactor;
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        previousSpeed = playerMovement.speed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            previousSpeed = playerMovement.speed;
            playerMovement.speed *= dashFactor;
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            playerMovement.speed = previousSpeed;
        }
    }

}
