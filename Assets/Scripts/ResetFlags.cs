using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetFlags : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LevelManager.isStart = false;//isStartのフラグをfalseにする
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
