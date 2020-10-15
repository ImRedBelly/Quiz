using UnityEngine;

[CreateAssetMenu(menuName = "Questions", fileName = "New Questions")]
public class QuestionList : ScriptableObject
{
    public string question;
    public string[] answers;
}
