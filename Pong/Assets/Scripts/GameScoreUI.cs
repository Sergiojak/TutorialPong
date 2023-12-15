using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameScoreUI : MonoBehaviour
{
    //goles del jugador 1
    int goalsPlayerOne;
    //goles jugador 2
    int goalsPlayerTwo;

    public TextMeshProUGUI scoreText;

    //resetear goles 

    public void ResetScore()
    {
        goalsPlayerOne = 0;
        goalsPlayerTwo = 0;
        UpdateScoreText();

    }

    //añadir goles
    public void AddGoalPlayerOne()
    {
        goalsPlayerOne++;
        UpdateScoreText();
    }

    public void AddGoalPlayerTwo()
    {
        goalsPlayerTwo++;
        UpdateScoreText();

    }

    //mostrar
    void UpdateScoreText()
    {
        scoreText.text = goalsPlayerOne + " : " + goalsPlayerTwo;
    }

}
