using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float PlayerSpeed;

   

    [SerializeField] KeyCode links;
    [SerializeField] KeyCode rechts;
    [SerializeField] KeyCode omhoog;
    [SerializeField] KeyCode onder;
    private Rigidbody2D RB;
    [SerializeField] SpriteRenderer spriteturn;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(links))
        {
            transform.Translate(Vector2.left * PlayerSpeed * Time.deltaTime);
            spriteturn.flipX = true;
        }
        if (Input.GetKey(rechts))
        {
            transform.Translate(Vector2.right * PlayerSpeed * Time.deltaTime);
            spriteturn.flipX = false;
        }
        if (Input.GetKey(omhoog))
        {
            transform.Translate(Vector2.up * PlayerSpeed * Time.deltaTime);
            spriteturn.flipY = true;
           
        }
        if (Input.GetKey(onder))
        {
            transform.Translate(Vector2.down * PlayerSpeed * Time.deltaTime);
            spriteturn.flipY = false;
            
        }








    }

    

}
