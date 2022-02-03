using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private GameObject coinObject;
    [SerializeField] private ParticleSystem coinParticleSystem;
    [SerializeField] private AudioSource coinSound;

    void OnTriggerEnter(Collider other)
    {
        if (GameManager.instance.IsPowerupActive)
        {
            GameManager.instance.CollectedCoins += 2;
        }
        else
        {
            GameManager.instance.CollectedCoins++;
        }
        
        PlayStateUIManager.instance.UICoinUpdate();
        coinSound.Play();
        coinParticleSystem.Play();
        Destroy(coinObject);
        Destroy(gameObject, 1f);
    }
}
