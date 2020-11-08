using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour//Scoreクラス
{
    public Text scoreText;//Text型のscoreText変数

    public Text highScoreText;//Text型のhighSoreText変数

    private static int score;//整数型のscore変数

    private static int highScore;//整数型のhighScore変数

    private string highScoreKey = "highScore";//highScoreを文字列型のhighScoreKey変数に代入する

    void Awake()//Awakeメソッド
    {
        if(!LevelManager.isStart)//もしLevelManagerクラスのisStart変数がfalseだったら
        {
            Initialize();//Initializeメソッドを実行する
        }
    }

    private void Initialize()//Initializeメソッド
    {
        score = 0;//scoreを０にする

        highScore = PlayerPrefs.GetInt(highScoreKey, 0);//Playprefs.GetInt関数を利用してhighScoreをロードしている、もしデータがなければ０を代入する

    }

    private void Start()
    {
        DisplayScores();//DisplayScoresを使って０を表示
    }

    public void Addpoint (int point)//Addpointメソッド、int型の値をpointとして受け取る
    {
        score += point;//スコアの元々の値にポイントを加算する

        Debug.Log(score);//コンソールにscore変数の値(中身)を表示する

        if(highScore　< score)//もし整列型のscoreがhighScoreより大きければ
        {
            highScore = score;//scoreの値をhighScireに代入する

            Debug.Log(highScore);//コンソールにhighScore変数の値を表示する
        }

        DisplayScores();//大文字始まりで()終わりはメソッド、Initialize同様呼び出すために入れている
    }

    private void DisplayScores()//DisplayScoresメソッド
    {
        scoreText.text = score.ToString();//score変数をToStringメソッドを使って文字列に変換し、scoreTextに代入する
        //int型.の後にはメソッドがポップアップで表示される
        highScoreText.text = highScore.ToString();//highscore変数をToStringメソッドを使って文字列に変換し、highscireTextに代入する
    }

    public void Save()//Saveメソッド
    {
        PlayerPrefs.SetInt(highScoreKey, highScore);//PlayerPrefsクラスのSetIntメソッドにhighScoreKeyとhighScoreを送る、SetIntを呼び出すためにhighScoreKeyとhighScore変数を用意している
        PlayerPrefs.Save();//PlayerPrefsクラスのSaveメソッドが実行される

        Debug.Log(highScore);//highScore変数の値をDebugクラスのLogメソッドに与えて実行する
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
