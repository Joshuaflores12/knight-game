using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class trap_manager : MonoBehaviour
{ 
     public Animator anim;
     public MovementAnimation player;
     public int trapDamage;
    public bool isPlayeronTop;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPlayeronTop = true;
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("is active", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayeronTop = false;
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("is active", false);
        }

    }


    public void PlayerDamage() 
    {   if (isPlayeronTop)
        {
            player.healthpoints -= trapDamage;
        }
        
    }



}
