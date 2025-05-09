using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour

{
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   

    public void changeScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    void Update()
    {
        Invoke("changeScene", 25f);
    }

}
