using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    // Playerプレハブ
    public GameObject player;

    // タイトル
    private GameObject title;

    void Start()
    {
        //Titleゲームオブジェクトを検索し取得する
        title = GameObject.Find("Title");        

    }

    void OnGUI()
    {
        // ゲーム中ではなく、タッチまたはマウスクリック直後であればtrueを返す。
        if (IsPlaying() == false && Event.current.type == EventType.MouseDown)
        {
            GameStart();
        }
    }


    void GameStart()
    {
        // ゲームスタート時に、タイトルを非表示にしてプレイヤーを作成する
        title.SetActive(false);
        Instantiate(player, player.transform.position, player.transform.rotation);
    }


    public void GameOver()
    {

        // 引数にシーン名を指定する
        // Build Settings で確認できる sceneBuildIndex を指定しても良い
        SceneManager.LoadScene("gameover");

    }


    public bool IsPlaying()
    {
        // ゲーム中かどうかはタイトルの表示/非表示で判断する
        return title.activeSelf == false;
    }
}