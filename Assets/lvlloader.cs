using UnityEngine;
using UnityEngine.SceneManagement;
public class lvlloader : MonoBehaviour
{
    private Scene scene;
    Scene currentscene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentscene = SceneManager.GetActiveScene();
        Debug.Log(currentscene.name);
    }
    public void loadNextLevel()
    {

        Debug.Log("clic !");
        
        currentscene = SceneManager.GetActiveScene();

        if (currentscene.name == "Teste")
        {
            Debug.Log("load Level 1");
            SceneManager.LoadScene("Level 1");
        }
        if (currentscene.name == "Level 1")
        {
            Debug.Log("load Level 2");
            SceneManager.LoadScene("Level 2");
        }
        if (currentscene.name == "Level 2")
        {
            Debug.Log("load Level 3");
            SceneManager.LoadScene("Level 3");
        }
        if (currentscene.name == "Level 3")
        {
            Debug.Log("load Level test");
            SceneManager.LoadScene("Teste");
        }
        

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
