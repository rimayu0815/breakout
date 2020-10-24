using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour 
{ 

    GameObject player;
    GameObject kabeLeft;
    GameObject kabeRight;

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
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += transform.forward * 0.1f;
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position -= transform.forward * 0.1f;
        }
        float posZ = Mathf.Clamp(transform.position.z, kabeRight.transform.position.z, kabeLeft.transform.position.z);
        transform.position = new Vector3(transform.position.x, transform.position.y, posZ); 
                                    //Mathf.Clamp(player.transform.position.z, kabeLeft.transform.position.z, kabeRight.transform.position.z));
    }
}
