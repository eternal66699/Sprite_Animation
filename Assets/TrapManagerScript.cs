using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManagerScript : MonoBehaviour
{
    public Animator anim;
    public int trapDamage;
    public bool isPlayerOnTop;
    public PlayerMovements player;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPlayerOnTop= true;
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("IsActive", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerOnTop = false;
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("IsActive", false);
        }
    }

    public void playerDamage()
    {
        if (isPlayerOnTop)
        {
            player.healthPoints -= trapDamage;
        }
    }
}
