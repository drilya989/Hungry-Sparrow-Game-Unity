using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10;
    private float xRange = 29;
    private Collisions collisionsScript;
    private bool isFacingRight = true;
    private float yPosition = 1.7f;
    private float zPosition = 19.0f;
    private int xRotation = 0;
    private int yRotation = 0;
    private int zRotation = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        collisionsScript = GameObject.Find("Player").GetComponent<Collisions>();
    }

    // Update is called once per frame
    void Update()
    {
        //umozliwienie sterowanie playera
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);

        //rotacja gracza
        if (horizontalInput < 0 && isFacingRight)
        {
            FlipCharacter(false); // Obróæ w lewo
        }
        else if (horizontalInput > 0 && !isFacingRight)
        {
            FlipCharacter(true); // Obróæ w prawo
        }

        //zatrzymanie playera w granicach kamery
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3 (xRange, transform.position.y, transform.position.z);
        } else if (transform.position.x < - xRange) 
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        //trzymanie graczach w dobrej pozycji
        if (transform.position.z != zPosition || transform.position.y != yPosition)
        {
            transform.position = new Vector3(transform.position.x, yPosition, zPosition);
        }


        //zatrzymanie playera w dobrej pozycji
        if (transform.rotation.x != xRotation || transform.rotation.y != yRotation || transform.rotation.z != zRotation)
        {
            transform.rotation = Quaternion.Euler(xRotation, yRotation, zRotation);
        }

        //po gameover zatrzymanie playera
        if (collisionsScript.gameOver == true)
        {
            transform.position = new Vector3(0, transform.position.y, 19);
        } 

    }
    void FlipCharacter(bool facingRight)
    {
        isFacingRight = facingRight;
        Vector3 scale = transform.localScale;
        scale.x = facingRight ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
        transform.localScale = scale;
    }

}
