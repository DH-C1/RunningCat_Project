using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public float healthDrainRate = 1f;      //      초당 1씩 체력 까이는 코드
    private float healthTimer = 0f;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        healthTimer += Time.deltaTime;
        if (healthTimer >= 1f)
        {

        }
    }
}
