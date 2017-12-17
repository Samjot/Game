using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour

{
    [SerializeField]
    GameObject mDeathParticleEmitter;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Instantiate(mDeathParticleEmitter, transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            SceneManager.LoadScene("DieMenu");
        }
    }
}
