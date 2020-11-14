using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitCheckPouUp : MonoBehaviour
{
    public Button btnQuitGame;//ButtonクラスのbtnQuitGame変数、ゲーム終了ボタン
    public Button btnClosePopup;//ButtonクラスのbtnClosePopup変数、ポップアップを閉じてゲームに戻るボタン

    // Start is called before the first frame update
    void Start()
    {

        btnQuitGame.onClick.AddListener(GameDirector.QuitGame);//クリックした時のイベントメソッドを「GameDirectorクラスのQuitGame変数」としてセット
        btnClosePopup.onClick.AddListener(OnClickClosePopUp);//クリックした時のイベントメソッドを「OnClickClosePopup」としてセット

        Time.timeScale = 0;//一時停止

    }

    /// <summary>
    /// ポップアップを閉じてゲームに戻る
    /// </summary>
    private void OnClickClosePopUp()//OnClickClosePopUpメソッド
    {
        Time.timeScale = 1.0f;//再生する
        Destroy(gameObject);//`gameObjectを使ってDestroyメソッドを実行、ポップアップを削除
    }


}
