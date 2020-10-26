using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UIオブジェクトをScriptから操作する際に必要

public class TextDataFetcher : MonoBehaviour    //TextDataFetcherクラス
                                                //MonoBehaviourは「継承」、機能をTextDataFetcherクラスに取り込む

{
    public Text resultMessageText;//Textクラス型のresultMessageText変数

    public AudioClip[] audioClips;//AudioClipクラス型のaudioClips変数（追加）

    public AudioSource audioSource;//AudioSourseクラス型のAudioSource変数（追加）

    // Start is called before the first frame update
    void Start()//Startメソッド
    {
        resultMessageText.text = DataSender.resultMessage;//resultMessageText変数のテキストはDataSenderクラスのresultMessage変数にあるオブジェクトと同じになる


    //(以下追加項目）
        
        if(DataSender.isGameClear)//もしDataSenderクラスがisGameClear変数だったら
        {
            audioSource.clip = audioClips[0];//audioSourceクラス型のclip変数はaudioClips{0}変数にあるオブジェクトになる
        }

        else//それ以外なら
        {
            audioSource.clip = audioClips[1];//audioSourceクラス型のclip変数はaudioclips{1}変数にあるオブジェクトになる
        }

        audioSource.Play();//audioSource変数にあるオブジェクトを使用する


    //(ここまで追加)

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
