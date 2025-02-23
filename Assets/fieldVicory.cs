using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class fieldVicory : MonoBehaviour
{
    private Button button;
    private TextMeshProUGUI buttonText;
    public float fadeDuration = 1.0f;
    GameObject[] moutons;
    float moutonforVictory ;
    int moutonsCapture = 0;
    public TextMeshProUGUI victory;
    public TextMeshProUGUI NextLeveltext;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moutons = GameObject.FindGameObjectsWithTag("sheep");
        moutonforVictory = moutons.Length;
        victory = GameObject.Find("VictoryText").GetComponent<TextMeshProUGUI>();
        NextLeveltext = GameObject.Find("nextLeveltext").GetComponent<TextMeshProUGUI>();
        Debug.Log(moutonforVictory + " moutons a ramener");
        GameObject buttonObj = GameObject.Find("NextLevel");
        button = buttonObj.GetComponent<Button>();
    }

    IEnumerator FadeInText()
    {
        Color color = victory.color;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            victory.color = color;
            NextLeveltext.color = color;
            yield return null;
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
       
        
       if (other.gameObject.tag == "sheep")
        {
            other.gameObject.GetComponent<sheepBrain>().infield = true;
            
            moutonsCapture += 1;
            Debug.Log("moutonsCapture " + moutonsCapture);
            if (moutonsCapture >= moutonforVictory)
            {
                StartCoroutine(FadeInText());
                Debug.Log("Victory");
                
            }
        }
    }
}
