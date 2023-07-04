using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    public int moveSpeed;
    public Rigidbody2D rigidbody;
    public Vector2 movementInput;
    public Animator anim;
    // Start is called before the first frame update
    public int CoinCount;
    public int healthPoints;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Speed"))
        {
            Transform col = collision.transform;
            collision.transform.position = new Vector2(999, 999);
        }
        if (collision.CompareTag("Coins"))
        {
            CoinCount++;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Health"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = movementInput * moveSpeed;
    }

    private void LastUpdate()
    {

    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }
}
