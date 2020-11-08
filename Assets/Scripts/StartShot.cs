using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShot : MonoBehaviour//StartShotクラス
{
    public float addSpeed;//浮動小数点型のaddSpeed変数を追加

    // Start is called before the first frame update
    void Start()//Startメソッド
    {
        transform.eulerAngles = new Vector3(0, Random.Range(30, 120), 0);//transformの変数が持っているRotationの情報ををeulerAnglesで上書きする、x=0,y=30～120,z=0
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * (500 + (LevelManager.level * addSpeed)));//forwardは(0,0,1)
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BallDestroy()//BallDestroyメソッド
    {
        this.gameObject.SetActive(false);//gameObject変数にSetActiveメソッドを実行しfalseだったら
        Destroy(this.gameObject);//gameObject変数を使ってDestroyメソッドを実行する
    }
}
