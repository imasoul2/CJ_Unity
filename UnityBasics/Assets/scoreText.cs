using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UI;

public class scoreText : MonoBehaviour
{
    private static int score;
    public Text scoreboard;

    // Update is called once per frame
    void Update()
    {
        score = Player.coinScore;
        scoreboard.text = "Score :" + score.ToString();
    }
}
