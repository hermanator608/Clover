using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backyardigan : MonoBehaviour
{

    private Vector2 velocity;
    private Vector3 direction;
    private bool hasMoved;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (velocity.x == 0 && velocity.y == 0)
        {
            hasMoved = false;
        }
        else if ((velocity.x != 0 || velocity.y != 0) && !hasMoved)
        {
            hasMoved = true;
            MoveByDirection();
        }

        velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    }

    private void MoveByDirection()
    {
        if (direction != null && direction.x < 0 && velocity.x > 0)
        {
            transform.RotateAround(transform.position, transform.up, 180f);
        }
        else if (direction != null && direction.x > 0 && velocity.x < 0)
        {
            transform.RotateAround(transform.position, transform.up, -180f);
        }


        Debug.Log("Moving - " + direction.ToString());
        if (velocity.x < 0) // Move Left
        {
            if (velocity.y > 0) // Move Upper Left
            {
                direction = new Vector3(-.5f, 0.5f);
            }
            else if (velocity.y < 0) // Move Bottom Left
            {
                direction = new Vector3(-.5f, -.5f);
            } 
            else // Move left
            {
                direction = new Vector3(-.5f, 0);
            }
        }
        else if (velocity.x > 0)
        {
            if (velocity.y > 0) // Move upper right
            {
                direction = new Vector3(.5f, .5f);
            } 
            else if (velocity.y < 0) // Move lower right
            {
                direction = new Vector3(.5f, -.5f);
            }
            else // Move right
            {
                direction = new Vector3(.5f, 0);
            }
        }
        else if (velocity.y < 0 && direction != null)
        {
            Debug.Log("Down pressed - " + direction.ToString());
            if (direction.x < 0) // Move Lower Left
            {
                direction = new Vector3(-.5f, -.5f);
            }
            else if (direction.x > 0) // Move lower right
            {
                direction = new Vector3(.5f, -.5f);
            }
        }
        else if (velocity.y > 0 && direction != null)
        {
            Debug.Log("Up pressed - " + direction.ToString());
            if (direction.x < 0) // Move Upper Left
            {
                direction = new Vector3(-.5f, 0.5f);
            } 
            else if (direction.x > 0) // Move Upper right
            {
                direction = new Vector3(.5f, .5f);
            }

        }

        transform.position += direction;
    }
}
