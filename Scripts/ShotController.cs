using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour
{
    // Spaceshipコンポーネント
    Spaceship spaceship;

    void Update()
    {
        // Spaceshipコンポーネントを取得
        spaceship = GetComponent<Spaceship>();

        if (Input.GetMouseButtonDown(0))
        {
            // 弾をプレイヤーと同じ位置/角度で作成
            spaceship.Shot(transform);

            //ショット音を鳴らす
            GetComponent<AudioSource>().Play();
        }
    }
}
