using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public string path = "";
    // Sceneの呼び出し前に呼ばれるようにする
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void InitializeBeforeSceneLoad()
    {
        var controller = new GameObject("SceneController");
        controller.AddComponent<SceneController>();
        DontDestroyOnLoad(controller);
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
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
            SceneManager.LoadScene("SelectVRM");
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            SceneManager.LoadScene("Second");
        }
    }
}
