using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    public Text scorePlayerText;
    public Text scoreEnemyText;

    int scorePlayerQuantity;
    int scoreEnemyQuantity;

    public GameObject ball;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.GetComponent<AudioSource>().Play();
        if (gameObject.CompareTag("Left"))
        {
            scoreEnemyQuantity++;
            UpdateScoreLabel(scoreEnemyText, scoreEnemyQuantity);
        }
        else if (gameObject.CompareTag("Right"))
        {
            scorePlayerQuantity++;
            UpdateScoreLabel(scorePlayerText, scorePlayerQuantity);
        }
        CheckScore();
        ball.GetComponent<Ball>().gameStarted = false;
    }

    void UpdateScoreLabel(Text label, int score)
    {
        label.text = score.ToString();
    }

    void CheckScore()
    {
        if (scoreEnemyQuantity > 2)
        {
            SceneManager.LoadScene("Loose");
        }else if(scorePlayerQuantity > 2)
        {
            SceneManager.LoadScene("Win");
        
        }
    }
}
