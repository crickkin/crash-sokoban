using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehaviour : MonoBehaviour
{
    private bool stocked = false;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        gameManager.addBox();
        stocked = false;
    }

    public bool Move(Vector2 movement)
    {
        Collider2D collider = Physics2D.OverlapBox(movement + (Vector2)transform.position, Vector2.one * 0.01f, 0f);
        bool isStockPlace = collider?.gameObject.tag == "StockPlace";
        if (!collider || isStockPlace)
        {
            if (isStockPlace)
            {
                if (!stocked)
                {
                    stocked = true;
                    gameManager.StockBox();
                }
            }
            else if (stocked)
            {
                stocked = false;
                gameManager.UnstockBox();
            }

            transform.position = movement + (Vector2)transform.position;
            return true;
        }

        return false;
    }
}
