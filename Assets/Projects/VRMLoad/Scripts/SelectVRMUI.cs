using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRM;
using VRM.Samples;
using System.IO;
using System;

public class SelectVRMUI : MonoBehaviour
{
    [SerializeField]
    Button m_button;
    // Start is called before the first frame update
    void Start()
    {
        m_button.onClick.AddListener(OnOpenClicked);
    }

    void OnOpenClicked()
    {
        var path = FileDialogForWindows.FileDialog("VRMを選択してください", "vrm");

        if (string.IsNullOrEmpty(path))
        {
            return;
        }
        Debug.Log(path);
        // 小文字に直して大文字と小文字の判別を無視する
        var file_extention = Path.GetExtension(path).ToLower();
        if (file_extention == ".vrm")
        {
            var s_sceneController = GameObject.Find("SceneController").GetComponent<SceneController>();
            s_sceneController.path = path;
            // LoadVRMSceneに遷移する
            s_sceneController.LoadScene("LoadVRM");
        }
        else
        {
            Debug.LogWarningFormat("unknown file type: {0}", path);
        }
    }
}
