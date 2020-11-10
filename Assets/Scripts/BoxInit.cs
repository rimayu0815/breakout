using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInit : MonoBehaviour
{
    [Header("Boxの種類数")]
    public GameObject[] boxObjPrefabs;//GameObjectクラスのboxObjectPrefabs変数の配列
    public GameObject boxesObj;//GameObjectクラスのboxesObj変数

    [Header("Boxの行と列の設定値")]
    public int row;//整数型のrow変数
    public int column;//整数型のcolumn変数

    void Awake()//Awakeメソッド
    {
        GameObject masterObj = GameObject.Find("Master");//GameObjectクラスのMasterを探し、GameObjectクラスのmasterObj変数に代入する

        for(int x = 0; x < row; x++)//x=0であり、x<rowになるまでxに１を足し続ける
        {
            for (int y = 0; y < column; y++)//y=0であり、y<columnになるまでｙに５を足し続ける
            {
                int randomValue = Random.Range(0, boxObjPrefabs.Length);//(0, boxObjPrefabs, Length)を使用してRandomクラスのRangeメソッドを使用し、整数型のrandomValue変数に代入する

                GameObject g = Instantiate(boxObjPrefabs[randomValue], boxesObj.transform);

                g.transform.position = new Vector3((2f + (1f * y)),0.4f,(-4.2f + (1.2f * x)));

                g.GetComponent<Destroyer>().masterObj = masterObj;

            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
