using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
    public void LaunchGame() {
        SoundManager.Instance.Play(SoundManager.Instance.tickSound);
        SceneManager.LoadScene(1);
    }

    public void QuitGame() {
        SoundManager.Instance.Play(SoundManager.Instance.tickSound);
        Application.Quit();
    }
}
