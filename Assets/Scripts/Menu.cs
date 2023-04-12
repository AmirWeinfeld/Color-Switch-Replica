using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public void OnClickRestart()
    {
        SceneManager.LoadScene(0);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
