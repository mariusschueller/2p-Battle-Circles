using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1Move : MonoBehaviour
{
    private Rigidbody2D rb;

    public Camera MainCamera;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of width / 2
    }


    // Update is called once per frame
    void Update()
    {
        if (gameController.reset == 1)
        {
            transform.position = new Vector2(-5, 0);
            gameController.reset = 0;
        }

        if (gameController.playing == true)
        {
            if (Input.GetKey("a"))
            {
                rb.velocity = new Vector2(moveVal(rb.velocity.x - 1.5f), rb.velocity.y);
            }

            if (Input.GetKey("d"))
            {
                rb.velocity = new Vector2(moveVal(rb.velocity.x + 1.5f), rb.velocity.y);
            }

            if (Input.GetKey("s"))
            {
                rb.velocity = new Vector2(rb.velocity.x, moveVal(rb.velocity.y - 1.5f));
            }

            if (Input.GetKey("w"))
            {
                rb.velocity = new Vector2(rb.velocity.x, moveVal(rb.velocity.y + 1.5f));
            }

        }

        if (!Input.GetKey("a") || !Input.GetKey("d") || !Input.GetKey("s") || !Input.GetKey("w") || !gameController.playing)
        {
            if (rb.velocity.x <= 0.25f && rb.velocity.x >= -0.25f)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }

            else if (rb.velocity.x > 0.25f)
            {
                rb.velocity = new Vector2(rb.velocity.x - .5f, rb.velocity.y);
            }

            else
            {
                rb.velocity = new Vector2(rb.velocity.x + .5f, rb.velocity.y);
            }

            //y change

            if (rb.velocity.y <= 0.25f && rb.velocity.y >= -0.25f)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }

            else if (rb.velocity.y > 0.25f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - 0.5f);
            }

            else
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 0.5f);
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + (objectWidth), screenBounds.x - (objectWidth));
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + (objectHeight), screenBounds.y - (objectHeight));
        transform.position = viewPos;
    }


    float moveVal(float val)
    {
        if (val >= 7.5f)
        {
            return 7.5f;
        }

        if (val <= -7.5f)
        {
            return -7.5f;
        }

        return val;
    }
}
