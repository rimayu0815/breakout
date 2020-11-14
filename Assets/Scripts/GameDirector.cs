using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public QuitCheckPouUp quitCheckPouUpPrefab;
    public Transform canvasTran;
    private QuitCheckPouUp quitCheckPouUp = null;

    private void Awake()
    {
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(quitCheckPouUp == null)
            {
                quitCheckPouUp = Instantiate(quitCheckPouUpPrefab, canvasTran, false);
            }

        }
    }

    ///<summary>
    ///ゲームの終了処理（staticメソッドにしておくことで、終了確認用ポップアップからも呼び出せる）
    ///</summary>
    
    public static void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
