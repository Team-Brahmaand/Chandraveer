using UnityEngine;

public class ActivateUI : MonoBehaviour
{
    public GameObject NextScene;

    public void ActivateCanvas(){
        NextScene.SetActive(true);
    }
}
