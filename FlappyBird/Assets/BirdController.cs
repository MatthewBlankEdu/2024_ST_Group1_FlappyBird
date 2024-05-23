using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{
    public float JumpForce;
    public Rigidbody2D Rb2D;
    public GameObject GameOverScreen;
    public Animator Anim;

    public static bool HasStarted;
    public static bool GameOver;

    public int Points;

    public void Restart()
    {
        SceneManager.LoadScene("FlappyBird");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver = true;
        GameOverScreen.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        HasStarted = false;
        GameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver)
            return;

        if(Input.GetButtonDown("Jump"))
        {
            if (!HasStarted)
            {
                HasStarted = true;
                Rb2D.gravityScale = 1;
            }

            Anim.SetTrigger("FlapWings");
            //In this case transform.up == new Vector2(0, 1)
            Rb2D.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PointsTrigger"))
        {
            Points++;
        }
    }
}
