using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody rbody;
    public bool GameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*if(GameOver)
        {
            if(Input.GetMouseButtonDown(0)) //If the mouse's buttom is pressed once, the scene will reload
            {
                SceneManager.LoadScene("Game");
            }
            return; //Still need to work on that
        }*/
        if(Input.GetMouseButton(0)) //If the mouse's button is pressed, the player will change gravity
        {
            rbody.AddForce(new Vector3(0, 50, 0), ForceMode.Acceleration);
        }
        else if(Input.GetMouseButtonUp(0)) //If the mouse's button is not pressed, the player will immediatly go down (temporary code)
        {
            rbody.velocity *= 0.25f;
        }
    }
    void OnTriggerEnter(Collider other) { //If the player collide, GameOver will be true and the player will stop
        GameOver = true;
        rbody.isKinematic = true;

    }
}
