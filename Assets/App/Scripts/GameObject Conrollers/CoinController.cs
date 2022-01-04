using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private GameObject coinObject;
    [SerializeField] private ParticleSystem coinParticleSystem;

    void OnTriggerEnter(Collider other)
    {
        GameManager.instance.CollectedCoins++;
        PlayStateUIManager.instance.UICoinUpdate();
        coinParticleSystem.Play();
        Destroy(coinObject);
        Destroy(gameObject, 1f);
    }
}
