using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public PlayerController_ playerController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            /* Rigidbody enemyRigidbody = col.gameObject.GetComponent<Rigidbody>();
             if (enemyRigidbody != null)
             {
                 // Freeze position and rotation
                 enemyRigidbody.constraints = RigidbodyConstraints.FreezeAll;
                 col.gameObject.transform.Rotate(Vector3.forward * 180f);
             }*/

            col.gameObject.SetActive(false);
            playerController.AddScore(5);
        }
        Destroy(gameObject);
    }

}
