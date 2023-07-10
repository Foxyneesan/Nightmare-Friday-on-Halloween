using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image[] hearts;
    public Color grayColor;
    private int currentLives = 3;

    public void LoseLife()
    {
        currentLives--;
        UpdateUI();

        if (currentLives <= 0)
        {
            // Kod, który wykonuje siê po utraceniu wszystkich ¿yæ
            Debug.Log("Game Over!");
        }
    }

    private void UpdateUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentLives)
            {
                hearts[i].color = Color.white;
            }
            else
            {
                hearts[i].color = grayColor;
            }
        }
    }
}
