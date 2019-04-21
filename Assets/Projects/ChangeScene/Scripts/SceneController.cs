﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    // Sceneの呼び出し前に呼ばれるようにする
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void InitializeBeforeSceneLoad()
    {
        var controller = new GameObject("SceneController");
        controller.AddComponent<SceneController>();
        DontDestroyOnLoad(controller);
    }

    // Start is called before the first frame update
    void Start()
    {
        // DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("First");
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            SceneManager.LoadScene("Second");
        }
    }
}