using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public int boxNum;
    public float nowTime;

    // Start is called before the first frame update
    void Start()
    {
        nowTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        nowTime += Time.deltaTime;
        if (boxNum <= 0)
        {
            GameOver(nowTime.ToString("F0") + "秒でクリアできた！"); //<=======秒数をstring型にキャストとして引数へ
        }

        else if (Input.GetKey(KeyCode.Space))
        {
            GameOver(nowTime.ToString("F0") + "秒でクリアできた！");//クリアシーンのデバッグ用に追加
        }
    }

    public void GameOver(string resultMessage)
    {//<=======引数を持たせた
        DataSender.resultMessage = resultMessage; //<======受け取った引数をstatic変数へ格納
        SceneManager.LoadScene("Result");
    }
}
