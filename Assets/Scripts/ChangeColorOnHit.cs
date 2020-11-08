using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOnHit : MonoBehaviour
{
    //Hierarchyからカラーを’セットするために配列を用意する
    public Color[] blockColors;//ColorクラスのblockColors変数の配列

    /// <summary>
    /// ブロックの色を変更するメソッド。配列のSizeで指定した数が、色の変わる順番と内容にする
    /// </summary>
    /// <param name="index">ブロックの残りのHP</param>
    /// <returns></returns>
    
    public Color ChangeMaterialColor(int index)//整列型のindexを使ってChangeMaterialColorメソッドを実行し、色のデータを送る
    {
        index--;//indexは［Blockのhp - 1]の値を利用する

        return blockColors[index];//ブロックの色を配列に登録されているIndexの色に変更する
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
