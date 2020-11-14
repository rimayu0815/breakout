using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour 
{
    public float kakudo;//角度をinspectorで変更できるようにするため
    public float kakudotime;//同様に時間も
    public bool isTilt;//傾いてるか傾いてないか判断

    GameObject player;
    GameObject kabeLeft;
    GameObject kabeRight;
    public float playerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        kabeLeft = GameObject.Find("kabe left");
        kabeRight = GameObject.Find("kabe right");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(-6.5f, transform.position.y , transform.position.z);

        if(Input.GetMouseButtonDown(1) && !isTilt)
        {
            //transform.eulerAngles = new Vector3(0, Random.Range(-kakudo,kakudo), 0);
            StartCoroutine(Tilt());
           
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += transform.forward * playerSpeed;
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position -= transform.forward * playerSpeed;
        }
        float posZ = Mathf.Clamp(transform.position.z, kabeRight.transform.position.z + 0.75f, kabeLeft.transform.position.z - 0.75f);
        transform.position = new Vector3(transform.position.x, transform.position.y, posZ); 
                                    //Mathf.Clamp(player.transform.position.z, kabeLeft.transform.position.z, kabeRight.transform.position.z));
    }

    private IEnumerator Tilt()
    {
        transform.eulerAngles = new Vector3(0, Random.Range(-kakudo, kakudo), 0);

        isTilt = true;

        yield return new WaitForSeconds(kakudotime);

        isTilt = false;

        transform.eulerAngles = Vector3.zero;
    }
}