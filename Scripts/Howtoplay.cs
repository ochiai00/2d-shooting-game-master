﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Howtoplay : MonoBehaviour
{
    public void MoveScene()
    {
        // 引数にシーン名を指定する
        // Build Settings で確認できる sceneBuildIndex を指定しても良い
        SceneManager.LoadScene("howToPlay");
    }
}
