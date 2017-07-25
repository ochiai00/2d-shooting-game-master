using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
	// Spaceshipコンポーネント
	Spaceship spaceship;

    // Backgroundコンポーネント
    Background background;

    private void Start()
    {
        // Spaceshipコンポーネントを取得
        spaceship = GetComponent<Spaceship>();

        // Backgroundコンポーネントを取得。3つのうちどれか1つを取得する
        background = FindObjectOfType<Background>();
    }

    void Update ()
    { 

        // 右・左
        float x = CrossPlatformInputManager.GetAxisRaw("Horizontal");

        // 上・下
        float y = CrossPlatformInputManager.GetAxisRaw("Vertical");

        // 移動する向きを求める
        Vector2 direction = new Vector2(x, y).normalized;

        // 移動の制限
        Move(direction);

    }

    // 機体の移動
    void Move(Vector3 direction)
    {
        // 背景のスケール
        Vector2 scale = background.transform.localScale;

        // 背景のスケールから取得
        Vector2 min = scale * -0.5f;

        // 背景のスケールから取得
        Vector2 max = scale * 0.5f;

        // プレイヤーの座標を取得
        Vector3 pos = transform.position;

        // 移動量を加える
        pos += direction * spaceship.speed * Time.deltaTime;

        // プレイヤーの位置が画面内に収まるように制限をかける
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        // 制限をかけた値をプレイヤーの位置とする
        transform.position = pos;
    }


    // ぶつかった瞬間に呼び出される
    void OnTriggerEnter2D (Collider2D c)
	{
		// レイヤー名を取得
		string layerName = LayerMask.LayerToName(c.gameObject.layer);
		

		// レイヤー名がBullet (Enemy)またはEnemyの場合は爆発
		if( layerName == "Enemy")
        {

            // Managerコンポーネントをシーン内から探して取得し、GameOverメソッドを呼び出す
            FindObjectOfType<Manager>().GameOver();

            // 爆発する
            spaceship.Blood();
		
			// プレイヤーを削除
			Destroy (gameObject);

        }
	}
}