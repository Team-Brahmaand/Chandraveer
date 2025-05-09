using UnityEngine;
using System.Collections;
using System;


public class GoToNext : MonoBehaviour
{
    public SwitchScene switchscene;
    public String sceneName;
    public float delay;

    void Start()
    {
        StartCoroutine(RunFunctionAfterDelay(delay));
    }

    IEnumerator RunFunctionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Next();
    }

    void Next()
    {
        switchscene.ChangeScene(sceneName);
    }
}
