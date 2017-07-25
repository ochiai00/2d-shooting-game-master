using System.Collections;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    //プレハブを格納する
    public GameObject[] waves;

    //現在のWave
    private int currentWave;

    //Managerコンポーネント
    private Manager manager;

    // 敵の出現ループの回数
    private int emitterCount = 0;

    IEnumerator Start()
    {


        //waveが存在しなければコルーチンを終了する
        if(waves.Length == 0)
        {
            yield break;
        }

        //Managerコンポーネントをシーン内から探して取得する
        manager = FindObjectOfType<Manager>();

        while (true)
        {

            //タイトル中は待機
            while(manager.IsPlaying() == false)
            {
               yield return new WaitForEndOfFrame();
            }

            // Waveを作成する
            GameObject wave = (GameObject)Instantiate (waves [currentWave], transform.position, Quaternion.identity);

            // Waveの子要素を取り出す
            foreach (Transform child in wave.transform)
            {
                // 体力を敵群が一巡するごとにHPを倍増させる
                Enemy enemy = child.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.hp *= emitterCount + 1;
                }
            }

            //WaveをEmitterの子要素にする
            wave.transform.parent = transform;

            //Waveの子要素のEnemyが全て削除されるまで待機する
            while (wave.transform.childCount != 0)
            {
                yield return new WaitForEndOfFrame();
            }

            //Waveの削除
            Destroy(wave);

            // 格納されているWaveを全て実行したらcurrentWaveを0にする（最初から -> ループ）
            if (waves.Length <= ++currentWave)
            {
                currentWave = 0;
                emitterCount++;
            }


        }
    }
}
