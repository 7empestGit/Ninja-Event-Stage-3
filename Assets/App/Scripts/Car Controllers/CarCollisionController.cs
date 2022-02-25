using System.Collections;
using UnityEngine;

public class CarCollisionController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "Ground":
                CarController carController = GetComponent<CarController>();
                if (carController.isWon)
                    return;
                carController.ExplodeCar();
                break;
            case "Coin":
                OnCoinTrigger(other.gameObject);
                break;
            case "Explosive":
                OnExplosiveTrigger();
                break;
            case "Obstacle":
                StartCoroutine(OnObstacleTrigger());
                break;
        }
    }

    private void OnCoinTrigger(GameObject coin)
    {
        if (GameManager.Instance.IsPowerupActive)
        {
            GameManager.Instance.CollectedCoins += 2;
        }
        else
        {
            GameManager.Instance.CollectedCoins++;
        }

        PlayStateUIManager.Instance.UICoinUpdate();
        AudioSource coinSound = GameManager.Instance.coinSound;
        ParticleSystem coinParticleSystem = coin.GetComponentInChildren<ParticleSystem>();
        coinSound.Play();
        coinParticleSystem.Play();
        Destroy(coin.transform.Find("Coin").gameObject);
        Destroy(coin.transform.Find("CoinParticle").gameObject, 1f);
    }

    private IEnumerator OnObstacleTrigger()
    {
        CarController carController = GetComponent<CarController>();
        carController.isInvert = -1;
        yield return new WaitForSecondsRealtime(10f);
        carController.isInvert = 1;
    }

    private void OnExplosiveTrigger()
    {
        CarController carController = GetComponent<CarController>();
        carController.ExplodeCar();
    }
}
