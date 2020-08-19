using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 speedVector;
    public float speed;
    public float maxSpeed;

    public BoxCollider2D waterCollider;

    void Start()
    {
        speedVector = new Vector3(0, 0, 0);

        speed = 3f;

        waterCollider = GameObject.Find("Map").transform.Find("Water").transform.GetComponent<BoxCollider2D>();

    }
    void Update()
    {
        // Up/Down

        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float y = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        if (!waterCollider.IsTouching(this.transform.GetComponent<BoxCollider2D>()))
        {
            y = -0.25f * Time.deltaTime;

            speedVector += new Vector3(0, y, 0);

            transform.position += speedVector;
        }
        else
        {
            speedVector += new Vector3(x, y, 0);

            transform.position += speedVector;

            speedVector *= 0.7f;
        }
        


    }
}
