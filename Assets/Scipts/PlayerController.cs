using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    public float speed;
    private int count;
    public Text counTxt;
    public Text winTxt;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winTxt.text = "";
        updateTxt();
    }

    private void FixedUpdate()
    {
        //grabs input from keyboard, keys set by default in input manager
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PickUp")) {
            collision.gameObject.SetActive(false);
            count++;
            updateTxt();
        }
    }

    private void updateTxt()
    {
        counTxt.text = "Count: " + count.ToString();
        checkWin();
    }

    private void checkWin()
    {
        if (count >= 12)
        {
            winTxt.text = "You Win!";
        }
    }
}
