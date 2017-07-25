using UnityEngine;

public class Score : MonoBehaviour
{
    //スコアを表示するGUIText
    public GUIText scoreGUIText;

    //ハイスコアを表示するGUIText
    public GUIText highScoreGUIText;

    //スコア
    private int score;

    //ハイスコア
    private int hightScore;

    //PlayerPrefsで保存するためのキー
    private string highScorekey = "highScore";

    private void Start()
    {
        Initialize ();
    }

    private void Update()
    {
        //スコアがハイスコアより大きければ
        if (hightScore < score)
        {
            hightScore = score;
        }

        //スコア・ハイスコアを表示する
       // scoreGUIText.text = score.ToString();
       //highScoreGUIText.text = "HighScore : " + hightScore.ToString();
    }

    //ゲーム開始時の状態に戻す
    private void Initialize()
    {
        //スコアを0に戻す
        score = 0;

        //ハイスコアを取得する。保存されていなければ0を取得する。
        hightScore = PlayerPrefs.GetInt(highScorekey, 0);
    }

    //ポイントの追加
    public void AddPoint (int point)
    {
        score = score + point;
    }

    //ハイスコアの保存
    public void Save ()
    {
        //ハイスコアを保存する
        PlayerPrefs.SetInt(highScorekey, hightScore);
        PlayerPrefs.Save();

        //ゲーム開始前の状態に戻す
        Initialize ();
    }
}
