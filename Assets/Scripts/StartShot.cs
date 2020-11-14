using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShot : MonoBehaviour//StartShotクラス
{
    public float shootPower;

    public bool isShooteed = false;

    public float addSpeed = 500;//浮動小数点型のaddSpeed変数を追加
    private bool isShooted = false;
    // Start is called before the first frame update
    void Start()//Startメソッド
    {
        transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);

        //transform.eulerAngles = new Vector3(0, Random.Range(30, 120), 0);//transformの変数が持っているRotationの情報ををeulerAnglesで上書きする、x=0,y=30～120,z=0
        //gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * (500 + (LevelManager.level * addSpeed)));//forwardは(0,0,1)
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !isShooted)
        {
            transform.parent = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit rayCastHit;

            Physics.Raycast(ray, out rayCastHit);

            Vector3 rayHitPosition = new Vector3(rayCastHit.point.x, this.transform.position.y, rayCastHit.point.z);

            Vector3 normalDirection = (rayHitPosition - this.transform.position).normalized;

            isShooted = true;
            //transform.eulerAngles = new Vector3(0, Random.Range(30, 120), 0);

            GetComponent<Rigidbody>().AddForce(normalDirection * (500 + (LevelManager.level * addSpeed)));
        }
    }

    public void BallDestroy()//BallDestroyメソッド
    {
        this.gameObject.SetActive(false);//gameObject変数にSetActiveメソッドを実行しfalseだったら
        Destroy(this.gameObject);//gameObject変数を使ってDestroyメソッドを実行する
    }
}
