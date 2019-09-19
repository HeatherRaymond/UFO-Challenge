using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text livesText;

    private Rigidbody2D rb2d;
    private int count;
    private int lives;
    
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        count = 0;
        lives = 3;
        winText.text = "";
        SetCountText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("PickUp"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            count = count - 1;
            lives = lives - 1;
            SetCountText();
        }
        if (count == 12)
        {
            transform.position = new Vector2(34.94f, 74.88f); 
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 20)
        {
            winText.text = "You win! Game created by Heather Raymond!";
        }
    
        livesText.text = "Lives: " + lives.ToString();
        if (lives == 0)
        {
            winText.text = "You Lose!";
            Destroy(this);
        }
    }
}
