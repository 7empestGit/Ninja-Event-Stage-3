using System.Collections;
using UnityEngine;

public class CarCollisionController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
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
        if (GameManager.instance.IsPowerupActive)
        {
            GameManager.instance.CollectedCoins += 2;
        }
        else
        {
            GameManager.instance.CollectedCoins++;
        }

        PlayStateUIManager.instance.UICoinUpdate();
        AudioSource coinSound = coin.GetComponent<AudioSource>();
        ParticleSystem coinParticleSystem = coin.GetComponent<ParticleSystem>();
        coinSound.Play();
        coinParticleSystem.Play();
        Destroy(coin);
        Destroy(gameObject, 1f);
    }

    private IEnumerator OnObstacleTrigger()
    {
        Debug.Log("Obstacle Triggered");
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
