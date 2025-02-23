using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
public class menuStart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  public void Startgame()
    {
        SceneManager.LoadScene("Level 1");
    }

    // Update is called once per frame
    public void Quit()
    {
        if (Application.isEditor)
        {
            EditorApplication.isPlaying = false; // Arrête le mode Play
        }
        else
        {
            Application.Quit(); // Quitte l'application
        }
    }
}
