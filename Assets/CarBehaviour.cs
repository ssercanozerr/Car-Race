using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarBehaviour : MonoBehaviour
{
    public int point = 0;
    bool gameIsOver = false;
    bool dKeyBeenPressed = false;
    bool aKeyBeenPressed = false;
    private Rigidbody rigidbodyComponent;
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
        point = 0;
        rigidbodyComponent.velocity = new Vector3(-40, 0, 0);
    }


    void Update()
    {

        if (Input.GetKey("d"))
        {
            dKeyBeenPressed= true;
        }
        if (Input.GetKey("a"))
        {
            aKeyBeenPressed= true;
        }

    }

    private void FixedUpdate()
    {
        if (gameIsOver == false)
        {
            rigidbodyComponent.velocity = new Vector3(-40, 0, rigidbodyComponent.velocity.z);
            if (dKeyBeenPressed)
            {
                rigidbodyComponent.AddForce(0, 0, 40, ForceMode.Force);
                dKeyBeenPressed= false;
            }
            if (aKeyBeenPressed)
            {
                rigidbodyComponent.AddForce(0, 0, -40, ForceMode.Force);
                aKeyBeenPressed= false;
            }
        }
        else
        {
            rigidbodyComponent.velocity= Vector3.zero;
        }   
        if (rigidbodyComponent.position.x <= -115 || rigidbodyComponent.position.z <= -10 || rigidbodyComponent.position.z >= 10)
        {
            gameIsOver = true;
            rigidbodyComponent.velocity = Vector3.zero;
            Invoke("Restart", 3f);
        }        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Barrier")
        {
            Invoke("Restart", 3f);
            gameIsOver= true;
        }
        if (collision.collider.tag == "Coin")
        {
            point++;
            Destroy(collision.gameObject);
        }
    }
    
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameIsOver= false;
    }
}
