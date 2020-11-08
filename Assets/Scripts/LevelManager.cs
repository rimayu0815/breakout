using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Text levelText;//テキスト型のlevelText変数、SerializeFieldを使っているのでinspectorからレベルの値の指定可能

    [SerializeField] StartShot startShot;//StartShotクラスのstartShot変数、こちらも同様inspectorから値の指定可能

    public static int level;//整数型のlevel変数

    public static bool isStart;//bool型のisStart変数


    // Start is called before the first frame update
    void Start()
    {
        if(!isStart)//もしisStart変数がfalseだったら
        {
            level = 0;//level変数に０を代入する
            isStart = true;//isStart変数にtrueを代入する
        }
        levelText.text = level.ToString();//level変数をToStringメソッドを使って文字列型に変換し、levelText変数のText欄に値を代入する
    }

    public void LevelUp()//levelUpメソッド
    {
        startShot.BallDestroy();//startShot変数にBallDestroyメソッドを実行する
        level++;//レベルを１上げる
        StartCoroutine("NextLevel");//StartCoroutineを呼び出し、NextLevelメソッドを実行する
    }

    IEnumerator NextLevel()//コルーチンの式
    {
        Debug.Log("Please press key");//Please press keyの値を使ってDebugクラスのLogメソッドを実行する
        while (!Input.GetKey("space")) yield return null;//spaceキーが押されるまで一時停止
        SceneManager.LoadScene("Main");//スペースキーが押されたらMain変数の値を使ってSceneManegerクラスのLoadSceneメソッドを実行する
        Debug.Log("Done!");//文字列型のDone変数を使って、DebugクラスのLogメソッドを実行する
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
