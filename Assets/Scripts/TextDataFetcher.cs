using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UIオブジェクトをScriptから操作する際に必要

public class TextDataFetcher : MonoBehaviour    //TextDataFetcherクラス
                                                //MonoBehaviourは「継承」、機能をTextDataFetcherクラスに取り込む、これがないとGameObjectにアタッチできない

{
    public Text resultMessageText;//TextクラスのresultMessageText変数

    public AudioClip[] audioClips;//AudioClipクラスのaudioClips変数の配列、変数の後ろに[]がついてれば配列（追加）

    public AudioSource audioSource;//AudioSourseクラスのAudioSource変数（追加）

    // Start is called before the first frame update
    void Start()//Startメソッド
    {
        resultMessageText.text = DataSender.resultMessage;//DataSenderクラスのresultMessage変数をresultMessageTextの持つテキストに代入する、


        //(以下追加項目）

        if (DataSender.isGameClear)//もしDataSenderクラスがisGameClear変数の中身がtrueだったら、bool型
        {
            audioSource.clip = audioClips[0];//audioSourceクラスのclip変数はaudioClips{0}変数にあるオブジェクトになる
        }

        else//それ以外なら
        {
            audioSource.clip = audioClips[1];//audioSourceクラスのclip変数はaudioclips{1}変数にあるオブジェクトになる
        }

        audioSource.Play();//audioSource変数にあるオブジェクトを使用する


    //(ここまで追加)

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
