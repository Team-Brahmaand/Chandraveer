using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLunarScene : MonoBehaviour
{
    public float delay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("ChangeScene", delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeScene(){
        SceneManager.LoadScene("LunarLandscape3D");
    }
}
