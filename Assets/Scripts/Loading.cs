using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    [SerializeField] private Int32 _timeToWait = 3;
    
    [SerializeField] private Int32 _scene;

    private void Start()
    {
        StartCoroutine(WaitForTime());
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(_timeToWait);

        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(_scene);
    }
}
