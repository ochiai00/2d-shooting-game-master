using UnityEngine;

public class Scream : MonoBehaviour
{
    void OnAnimationFinish()
    {
        Destroy(gameObject);
    }
}
