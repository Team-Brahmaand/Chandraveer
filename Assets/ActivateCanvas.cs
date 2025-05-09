using UnityEngine;

public class ActivateCanvas : MonoBehaviour
{
    public float delay;
    public GameObject NextCanvas; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("enableThis", 8f);
    }

    void enableThis(){
        NextCanvas.SetActive(true);
    }


}
