using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;

public class Game : MonoBehaviour
{
    public Text question;
    public Text health;

    public List<QuestionList> questionList;
  
    public Text[] answer;

    public Button[] button;
    public Button helpButton;

    public int trueAnswer;
    public int falseAnswer;

    int countAnswer;
    int countQuestion;
    int countHealth = 3;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(UpdateQuestions());
    }
    public void ButtonRight(int nummer)
    {
        if (answer[nummer].text.ToString() != questionList[countQuestion].answers[0])
        {
            button[nummer].image.color = Color.red;
            falseAnswer++;
            countHealth -= 1;
            if(countHealth == 0)
            {
                SceneManager.LoadScene(2);
            }
        }
        else
        {
            trueAnswer++;
            button[nummer].image.color = Color.green;
        }
        questionList.RemoveAt(countQuestion);
        StartCoroutine(UpdateQuestions());

    }
    public void HellpButton()
    {
        for (int i = 0; i < button.Length; i++)
        {
            if (answer[i].text.ToString() == questionList[countQuestion].answers[0])
            {
                button[i].gameObject.SetActive(true);
            }
            else if (answer[i].text.ToString() == questionList[countQuestion].answers[1] || answer[i].text.ToString() == questionList[countQuestion].answers[2])
            {
                button[i].gameObject.SetActive(false);
            }
        }
        helpButton.gameObject.SetActive(false);
    }
    public IEnumerator UpdateQuestions()
    {
        yield return new WaitForSeconds(0.5f);
        if (questionList.Count > 0)
        {
            countQuestion = Random.Range(0, questionList.Count);
            question.text = questionList[countQuestion].question;

            health.text = "Жизни: " + countHealth;

            List<string> answers = new List<string>(questionList[countQuestion].answers);

            for (int i = 0; i < questionList[countQuestion].answers.Length; i++)
            {
                button[i].gameObject.SetActive(true);
                button[i].image.color = Color.white;
                countAnswer = Random.Range(0, answers.Count);
                answer[i].text = answers[countAnswer];
                answers.RemoveAt(countAnswer);
            }
        }
        else
        {
            SceneManager.LoadScene(2);
        }
        
    }
}
