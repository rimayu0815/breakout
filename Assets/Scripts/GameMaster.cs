using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//SceneManagerを動かすのに必要
using UnityEngine.UI;

public class GameMaster : MonoBehaviour//GameMasterクラス
{
    public int boxNum;//整数型のboxNum変数
    public float nowTime;//浮動小数点型のnowTime変数
    [SerializeField] Text resultMessageText;//テキスト型のresultMessageText変数
    private bool isClear;//bool型のisClear変数
    [SerializeField] private Score score;

    // Start is called before the first frame update
    void Start()
    {
        nowTime = 0;//nowTime変数のオブジェクトは０になる
    }

    // Update is called once per frame
    void Update()//Updateメソッド、毎フレーム実行
    {
        nowTime += Time.deltaTime;//nowTimeに経過時間を追加、Time.deltaTimeは前のフレームと現在のフレームの時間差を取得                                  
        if (!isClear)
        {

            if (boxNum <= 0)//もしBoxNum変数のオブジェクトが０以下なら
            {
                StageClear(nowTime.ToString("F0") + "秒でクリアできた！"); //nowTime変数のオブジェクトを小数点第０位までの文字列に変換、文字列型に変換したnowTimeの値と言葉を使ってStageClearメソッドを実行する
                isClear = true;
            }

        }
    }

    public void StageClear(string resultMessage)//文字列型のresultMessage変数をつかってStageClearメソッドを実行する
    {
        score.Save();
        resultMessageText.text = resultMessage;//resultMessage変数の値をresultMessageTextのText欄に代入する
        FindObjectOfType<LevelManager>().LevelUp();//LevelManagerのLevelUpメソッドを呼び出す
    }

    public void GameOver(string resultMessage)
    {
        score.Save();

        DataSender.resultMessage = resultMessage; //DataSenderクラスのresultMessage変数のオブジェクトをresultMessageと同じにする

        SceneManager.LoadScene("Result");//Resultというシーンに移動させる
    }
}
