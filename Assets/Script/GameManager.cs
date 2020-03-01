using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int numberOfBoxes = 0;
    private int boxesStocked = 0;

    public void addBox()
    {
        numberOfBoxes++;
    }

    public void StockBox()
    {
        boxesStocked++;
        Debug.Log($"stocked: {boxesStocked}\ttotal: {numberOfBoxes}");
        if (boxesStocked == numberOfBoxes)
        {
            Debug.Log("Game Win");
            int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
            if (SceneManager.sceneCountInBuildSettings > nextScene)
                SceneManager.LoadScene(nextScene);
        }
    }

    public void UnstockBox()
    {
        boxesStocked--;
    }
}
