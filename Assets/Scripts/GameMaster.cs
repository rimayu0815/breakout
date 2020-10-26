using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//SceneManagerを動かすのに必要

public class GameMaster : MonoBehaviour//GameMasterクラス
{
    public int boxNum;//整数型のboxNum変数
    public float nowTime;//浮動小数点型のnowTime変数

    // Start is called before the first frame update
    void Start()
    {
        nowTime = 0;//nowTime変数のオブジェクトは０になる
    }

    // Update is called once per frame
    void Update()//Updateメソッド、毎フレーム実行
    {
        nowTime += Time.deltaTime;//nowTimeに経過時間を追加、Time.deltaTimeは前のフレームと現在のフレームの時間差を取得                                  

        if (boxNum <= 0)//もしBoxNum変数のオブジェクトが０以下なら
        {
            GameOver(nowTime.ToString("F0") + "秒でクリアできた！", true); //nowTime変数のオブジェクトを小数点第０位までの文字列に変換
                                                                          //第2引数としてtrueを追加し、ゲームクリアの状態を渡す
        }

        else if (Input.GetKey(KeyCode.Space))
        {
            GameOver(nowTime.ToString("F0") + "秒でクリアできた！", true);//クリアシーンのデバッグ用に追加
        }
    }

    public void GameOver(string resultMessage, bool isClear)//GameOverメソッドで文字列型のresultMessageとブール型のisClearを渡す(第２引数を追加)
    {
        DataSender.resultMessage = resultMessage; //DataSenderクラスのresultMessage変数のオブジェクトをresultMessageと同じにする

        DataSender.isGameClear = isClear;//DataSenderクラスのisGameClear変数のオブジェクトをisClearと同じにする


        SceneManager.LoadScene("Result");//Resultというシーンに移動させる
    }
}
