using UnityEngine;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    public Game gameOver;

    public Text trueFalseAnswer;

    public Button button;
    void Start()
    {
        gameOver = FindObjectOfType<Game>();
        
        int trueAnswer = gameOver.trueAnswer;
        int falseAnswer = gameOver.falseAnswer;

        trueFalseAnswer.text = "Правильных ответов: " + trueAnswer + "\nНеправельных ответов: " + falseAnswer;
        Destroy(gameOver.gameObject);
    }

}
