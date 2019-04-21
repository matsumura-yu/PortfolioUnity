using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRM;
using System.IO;
using System;

public class LoadVRM : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        var path = GameObject.Find("SceneController").GetComponent<SceneController>().path;
        Debug.Log("start" + path);
        // VRMを読み込む機能の提供
        var context = new VRMImporterContext();
        // ファイルをByte配列に読み込みファイルを閉じる
        var bytes = File.ReadAllBytes(path);
        // GLB形式でJSONを取得しParseする
        context.ParseGlb(bytes);
        // metaデータの取得
        // 引数にサムネイルの取得設定を行える
        var meta = context.ReadMeta(false);

        Debug.LogFormat("meta_title: {0}", meta.Title);

        // LoadAsync後に引数のメソッドが呼び出されるように登録
        // context.LoadAsync(_ => OnLoaded(context));
        // 今UnityのVersionだとObsoleteになっている

        try
        {
            // awaitを使いたいのでメソッドにasyncを付ける
            await context.LoadAsyncTask();

            // 
            context.EnableUpdateWhenOffscreen();

            OnLoaded(context);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            // 関連するリソースを破棄する
            context.Dispose();
            throw;
        }
    }
    public void OnLoaded(VRMImporterContext context)
    {
        // BuildHierarchyメソッドが内部で呼び出されRootの中にVRMGameObject生成
        var root = context.Root;
        root.transform.position = new Vector3(0, 0, 0);

        // メッシュを表示する
        context.ShowMeshes();
    }
}
