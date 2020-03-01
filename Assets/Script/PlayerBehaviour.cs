using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private bool moving = false;

    void Update()
    {
        int x = 0, y = 0;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            y = 1;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            y = -1;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            x = 1;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            x = -1;
        }
        
        Vector2 movement = new Vector2(x, y);
        Collider2D collider = Physics2D.OverlapBox(movement + (Vector2)transform.position, Vector2.one * 0.01f, 0.0f);
        BoxBehaviour box = collider?.GetComponent<BoxBehaviour>();

        if (!collider || box)
        {
            bool canMove = true;
            if (box)
            {
                canMove = box.Move(movement);
            }

            if (canMove)
            {
                transform.position = movement + (Vector2)transform.position;
            }
        }
    }
}
