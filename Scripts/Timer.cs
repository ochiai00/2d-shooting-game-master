﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    private float time = 90;

    void Start()
    {

        //初期値60を表示
        //float型からint型へCastし、String型に変換して表示
        GetComponent<Text>().text = ((int)time).ToString();

    }

    void Update()
    {
            //1秒に1ずつ減らしていく
            time -= Time.deltaTime;
            //マイナスは表示しない
            if (time < 0) time = 0;
            GetComponent<Text>().text = ((int)time).ToString();
    

        if (time == 0)
        {
            // 引数にシーン名を指定する
            // Build Settings で確認できる sceneBuildIndex を指定しても良い
            SceneManager.LoadScene("clear");
        }
    }
}