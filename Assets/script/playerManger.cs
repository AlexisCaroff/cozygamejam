using UnityEngine;

public class playerManger : MonoBehaviour
{

    #region Sigleton
    public static playerManger instance;

    private void Awake()
    {
        instance = this;
            
    }

    #endregion

    public GameObject Dog;
    public GameObject Player;

}

