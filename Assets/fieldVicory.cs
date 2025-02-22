using UnityEngine;

public class fieldVicory : MonoBehaviour
{
    GameObject[] moutons;
    float moutonforVictory ;
    int moutonsCapture = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moutons = GameObject.FindGameObjectsWithTag("sheep");
        moutonforVictory = moutons.Length;
        
        Debug.Log(moutonforVictory + " moutons a ramener");
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
                Debug.Log("Victory");
            }
        }
    }
}
