using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour//Destroyerクラス
{
    public int point;//整数型のpoint変数
    public GameObject masterObj;//GameObject型のmasterobj変数

    public int initHp;//整数型のinitHp変数、最大HP
    private int currentHp;//整数型のcurrentHp変数、現在のHP

    public AudioClip hitSE;//AudioClip型のhitSE変数、当たった時の音（まだ破壊されない）
    public AudioClip DestroySE;//AudioClip型のDestroySE変数、破壊された時の音

    public Renderer rend;//Rendererクラスのrend変数
    private ChangeColorOnHit changeColorOnHit;//ChangeColorOnHitクラスのchangeColorOnHit変数

    // Start is called before the first frame update
    void Start()
    {
        this.currentHp = initHp;//initHpにcurrentHpの値を代入する、現在のHPを最大値にする

        changeColorOnHit = masterObj.GetComponent<ChangeColorOnHit>();//masterObj(=Master)の中にあるChangeColorOnHitの値をGetComponentメソッドで取得し、changeColorOnHitに代入する

        rend.material.color = changeColorOnHit.ChangeMaterialColor(currentHp);//current変数を使って、changeColorOnHit変数の中にあるChangeMaterialColorメソッドを実行し、rend変数にあるmaterialのcolorに値を代入する
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision colllision)//OnCollisionメソッドで、これが適用されているオブジェクト相手が衝突した瞬間、相手の情報がcollision型で送られてくる
    {
        this.currentHp -= 1; //currentHp変数を１減らす、当たったらHPが１減る

        if (this.currentHp <= 0)//ifメソッドでcurrentHpが０より低い場合
        {
            AudioSource.PlayClipAtPoint(DestroySE, transform.position);//AudioSourceクラスのPlayClipAtPointメソッドにDestroySEとtransformクラスのposition（変数？）の値を送り実行する、破壊されるSEを再生

            masterObj.GetComponent<GameMaster>().boxNum--;//GameMasterクラスのGetComponentメソッドを実行してboxNumの値を１減らし、masterobj変数にデータを送る、ブロックの数を１減らす

            FindObjectOfType<Score>().Addpoint(point); //ヒエラルキーの中からScoreクラスを探し出してAddpointメソッドにpointの値を渡す

            Destroy(this.gameObject);//Destroyメソッドを実行する、ブロックを破壊する

        }

        else
        {
            AudioSource.PlayClipAtPoint(hitSE, transform.position);//AudioSourceクラスのPlayClipPointメソッドにhitSEとtransformクラスのpositionの値を送り実行する、破壊されないSEを流す

            ChangeBlockColor();//ChangeBlockColorメソッドを実行する
        }
    }

    ///<summary>
    ///ブロックの色を残りの耐久力に合わせて変更する
    ///ChangeColorOnHitクラスのChangeMaterialColorメソッドに現在の耐久力の値を渡し、戻り値としてColor(色の情報)をもらう
    /// </summary>
    
    private void ChangeBlockColor()//ChanageBlockColorメソッド
    {
        rend.material.color = changeColorOnHit.ChangeMaterialColor(currentHp);//current変数を使って、changeColorOnHit変数の中にあるChangeMaterialColorメソッドを実行し、rend変数にあるmaterialのcolorに値を代入する

    }
}
