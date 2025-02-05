using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterMovement : MonoBehaviour
{
    
    private Rigidbody2D rigidBody;
    private float movementSpeed;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;
    public static int score;
    public TextMeshProUGUI coinText;


    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        movementSpeed = 7;
        movement = new Vector2(0.0f, 0.0f).normalized;
        score = 0;
        coinText.text = "x " + score;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        coinText.text = "x " + score;
        if (rigidBody) {
           
            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            float moveVertical = Input.GetAxisRaw("Vertical");
            movement = new Vector2(moveHorizontal, moveVertical).normalized;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene(2);
        }

    }


    void FixedUpdate()
    {
        if(movement.x == 1f && movement.y == 0f) {
            spriteRenderer.sprite = rightSprite;
        }
        if(movement.x == -1f && movement.y == 0f) {
            spriteRenderer.sprite = leftSprite;
        }
        if(movement.x == 0f && movement.y == 1f) {
            spriteRenderer.sprite = upSprite;
        }
        if(movement.x == 0f && movement.y == -1f) {
            spriteRenderer.sprite = downSprite;
        }

        Vector2 newPosition = rigidBody.position + movement * movementSpeed * Time.fixedDeltaTime;

        if(newPosition.y > 19){
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, 19);
        }
        if(newPosition.y < -19){
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, -19);
        }
        if(newPosition.x > 17.5f){
            gameObject.transform.position = new Vector2(17.5f, gameObject.transform.position.y);
        }
        if(newPosition.x < -18.5f){
            gameObject.transform.position = new Vector2(-18.5f, gameObject.transform.position.y);
        }

        rigidBody.MovePosition(newPosition);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.tag == "Enemy")
        {
            SceneManager.LoadScene(2);
        }
        else if (collision.collider.tag == "Coin") {
            score += 1;
            Destroy(collision.collider.gameObject);
        }
    }
}
