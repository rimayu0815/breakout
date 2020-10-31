using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public int point;
    public GameObject masterobj;//GameObject型のmasterobj変数
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision colllision)
    {
        FindObjectOfType<Score>().Addpoint(point); //ヒエラルキーの中からScoreクラスを探し出してAddpointメソッドにpointの値を渡す

        masterobj.GetComponent<GameMaster>().boxNum--;//msterobj変数にGetComponentメソッドを実行してGameMasterクラスの持つboxNum変数の値を一減らす
        Destroy(gameObject);
    }
}
