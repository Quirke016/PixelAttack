using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    [SerializeField] float playerRot;
    //Vector2 movement;


     Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    
        //movement = new Vector2(playerSpeed * 100, 0);

        playerRot = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        transform.Rotate(0, 0, -playerRot * 100);

        playerSpeed = Input.GetAxisRaw("Vertical") * Time.deltaTime;
        rb2D.AddForce(transform.up * playerSpeed * 100, ForceMode2D.Force); 
        //rb2D.velocity = movement;



    }
}
