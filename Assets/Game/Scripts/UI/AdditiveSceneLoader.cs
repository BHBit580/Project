using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdditiveSceneLoader : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }
}