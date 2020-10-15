using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void StartGame(int nummer)
    {
        SceneManager.LoadScene(nummer);
    }

}
