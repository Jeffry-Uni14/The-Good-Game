using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    

    
    
    bool jump = false;
    public float jumpForce = 5f;
    public float moveSpeed = 5f;
    float moveInput = 0;
    private Vector3 velocity;

    public Rigidbody2D rb;
    public bool grounded;
    private int count = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            jump = true;
        }
        moveInput = Input.GetAxis("Horizontal");

        
    }

    //physics and olcity
    void FixedUpdate()
    {
        if (jump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); //addforce applies physics force onto the player through the vector
            jump = false;
        }
        //transform.position += vector3.right * moveSpeed * deltaTime;  //multiplty by delta - Jonas Tyroller Delta Time
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            winTextObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
    }
}


