using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class consumables : MonoBehaviour
{
    public bool speed, health;
    public int speedboost, healthboost, duration;
    private int baseMovespeed;
    public MovementAnimation player;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (speed) 
        {
            player.moveSpeed += speedboost;
            StartCoroutine(BackToBaseSpeed());
        }
        if (health)
        {
            player.healthpoints= healthboost;
        }
    }

    IEnumerator BackToBaseSpeed() 
    {
        yield return new WaitForSeconds(duration);
        player.moveSpeed = baseMovespeed;
    }
    // Update is called once per frame
    private void Start()
    {
        baseMovespeed = player.moveSpeed;
    }
    void Update()
    {
        
    }
}
