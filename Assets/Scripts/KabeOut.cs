using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KabeOut : MonoBehaviour//KabeOutクラス
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)//これが適用されているオブジェクトに相手が衝突した瞬間、相手の情報がcollision型で送られてくる
    {
        GameObject.Find("Master").GetComponent<GameMaster>().GameOver("ゲームに失敗、また挑戦しよう", false);//ゲームオブジェクトのMasterを探しGameMasterコンポーネントのGameOver関数を呼ぶ、(第２引数を追加)
    }
}
