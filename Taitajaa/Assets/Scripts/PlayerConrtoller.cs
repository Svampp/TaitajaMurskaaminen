using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("Movement")]
    public CharacterController controller;
    public float speed = 12f;
    public bool ableToMove = true;
    public float jumpHeight = 3f;
    public bool jumpAllowed;

    [Header("Gravity")]
    [SerializeField] float gravity = -9.81f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    Vector3 velocity;

    [Header("Stats")]
    [SerializeField] float health = 100;
    float maxHealth = 100f;
    [SerializeField] int coins = 0;
    public bool inMarketArea = true;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] GameObject buyGuide;

    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        Movement();
        UI();

        if (health <= 0)
        {
            GameManager.instance.Restart();
        }
        if (Input.GetKey(KeyCode.R))
        {
            GameManager.instance.Restart();
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            GameManager.instance.BackToMenu();
        }

        
    }

    void Movement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Gets the player input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        // Transforms the player input to Vector3
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Checks if spacebar is pressed, player is on the ground and jump is allowed
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && jumpAllowed)
        {
            // If all are true player jumps
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Applyes gravity to player
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void UI()
    {
        coinsText.text = $"Coins: {coins}";

        buyGuide.SetActive(inMarketArea);

        if (inMarketArea && Input.GetKey(KeyCode.E))
        {
            maxHealth += 10;
            health = maxHealth;
            coins--;
        }
        
    }

    public void TakeDamage(float damage)
    {
        health -= damage * Time.deltaTime;
    }
    public void ResetHealth()
    {
        health = maxHealth;
    }

    public void Increasecoins(int amount)
    {
        coins += amount;
    }
}
