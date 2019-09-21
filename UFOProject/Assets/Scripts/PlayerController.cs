using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    private int count;
    private int lives;
    public Text countText;
    public Text lifeText;
    public Text winText;
    private int lvl;
    private bool lost;
    private bool won;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        lives = 3;
        lost = false;
        won = false;
        lvl = 1;
        SetCountText();
        SetLifeText();
        winText.text = "";
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement*speed);
        /*if (Input.GetKey("escape"))
        {
            Application.Quit();
        }*/

        if (count == 12 && lvl == 1)
        {
            lvl = 2;
            transform.position = new Vector2(50.0f, 50.0f); 
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp") && lost == false)
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Enemy") && won == false) {
            other.gameObject.SetActive(false);
            lives--;
            SetLifeText();
        }
    }

    void SetCountText(){
        countText.text = "Count: " + count.ToString();
        if (count >= 20 && lost != true) { //20 now
            won = true; //Prevents losing after winning
            winText.text = "You win! Game created by Travis Kosier.";
        }
        
    }

    void SetLifeText()
    {
        lifeText.text = "Lives: " + lives.ToString();
        if (lives == 0) //If player runs out of lives
        {
            lost = true; //Prevents winning after losing
            winText.text = "You lose! Game created by Travis Kosier.";
            Destroy(gameObject);

        }
    }

}