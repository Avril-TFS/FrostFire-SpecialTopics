using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController_ : MonoBehaviour
{

    public float speed = 10f;
    public GameObject bullet;
    public Transform shootPoint;

    private Rigidbody rgbd;

    public float bulletSpeed = 20f;

    private Vector3 lastMovementDirection = Vector3.forward;

    public Vector3 initialPosition;

    public int score = 0;
    private int highScore;

    public Text scoreText;
    public Text highScoreText;

    public AudioSource audioSource;
    public AudioClip shootSound;
    public AudioClip gemSound;

    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody>();
        initialPosition = transform.position;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        if (movement != Vector3.zero)
        {
            lastMovementDirection = movement;
            transform.rotation = Quaternion.LookRotation(movement);
        }

        rgbd.velocity = movement * speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (bullet != null && shootPoint != null)
        {
            GameObject newBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
            Rigidbody bulletRgbd = newBullet.GetComponent<Rigidbody>();
            if (bulletRgbd != null)
            {
                bulletRgbd.velocity = shootPoint.forward * bulletSpeed;
            }

            Bullet bulletScript = newBullet.GetComponent<Bullet>();
            if(bulletScript != null)
            {
                bulletScript.playerController = this;
            }

            audioSource.PlayOneShot(shootSound);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            ResetPosition();
        }
        
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Gem"))
        {
            score += 1;
            Destroy(col.gameObject);
            UpdateScoreText();

            audioSource.PlayOneShot(gemSound);
        }
        if (col.gameObject.CompareTag("BigGem"))
        {
            score += 5;
            Destroy(col.gameObject);
            UpdateScoreText();

            audioSource.PlayOneShot(gemSound);
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
    void UpdateHighScoreText()
    {
        highScoreText.text = "Highscore: " + highScore;
    }
    public void RecordHighScore()
    {
        Debug.Log("Recording HighScore");

        if(score> highScore)
        {
            Debug.Log($"New HIghScore! {score}!!!");
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            UpdateHighScoreText();
        }
    }
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    private void ResetPosition()
    {
        transform.position = initialPosition;
    }
}
