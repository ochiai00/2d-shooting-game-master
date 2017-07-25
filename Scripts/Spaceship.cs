using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour
{
    // 移動スピード
    public float speed;

    // 弾を撃つ間隔
    public float shotDelay;

    // 弾のPrefab
    public GameObject bullet;

    // 弾を撃つかどうか
    public bool canShot;

    // 爆発のPrefab
    public GameObject explosion;

    //出血のPrefab
    public GameObject blood;

    //爆発2のプレハブ
    public GameObject explosion2;

    //爆発3のプレハブ
    public GameObject explosion3;

    //アニメーターコンポーネント
    private Animator animator;

    private void Start()
    {
        //アニメーターコンポーネントの取得
        animator = GetComponent<Animator>();

    }

    // 爆発の作成
    public void Explosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }

    //血しぶきの作成
    public void Blood()
    {
        Instantiate(blood, transform.position, transform.rotation);
    }
	
	// 弾の作成
	public void Shot (Transform origin)
	{
		Instantiate (bullet, origin.position, origin.rotation);
	}

    //アニメーターコンポーネントの取得
    public Animator GetAnimator()
    {
        return animator;
    }

}