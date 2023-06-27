using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rigidbody;
    public Vector2 movementInput;
    public Animator anim;
    // Start is called before the first frame update
    public int CoinCount;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    anim.SetTrigger("Backward Animation");
        //}

        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    anim.SetTrigger("Forward Animation");
        //}

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    anim.SetTrigger("Left Animation");
        //}

        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    anim.SetTrigger("Right Animation");
        //}

        //if (Input.GetKeyUp(KeyCode.W))
        //{
        //    anim.SetTrigger("Backward Animation Pause");
        //}

        //if (Input.GetKeyUp(KeyCode.S))
        //{
        //    anim.SetTrigger("Forward Animation Pause");
        //}

        //if (Input.GetKeyUp(KeyCode.A))
        //{
        //    anim.SetTrigger("Left Animation Pause");
        //}

        //if (Input.GetKeyUp(KeyCode.D))
        //{
        //    anim.SetTrigger("Right Animation Pause");
        //}
        anim.SetFloat("Horizontal", movementInput.x);
        anim.SetFloat("Vertical", movementInput.y);
        anim.SetFloat("Speed", movementInput.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = movementInput * moveSpeed;
    }

    private void LastUpdate()
    {

    }

    private void OnMove (InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coins"))
        {
            Destroy(collision.gameObject);
            CoinCount++;
        }
    }
}
