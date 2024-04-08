using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_ : MonoBehaviour
{

    public float speed = 10f;
    public GameObject bullet;
    public Transform shootPoint;

    private Rigidbody rgbd;

    public float bulletSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical); ;
        
        rgbd.velocity = movement * speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if(bullet != null && shootPoint != null)
        {
            GameObject newBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
            Rigidbody bulletRgbd = newBullet.GetComponent<Rigidbody>();
            if( bulletRgbd != null)
            {
                bulletRgbd.velocity = shootPoint.forward * bulletSpeed;
            }
        }
    }
}
