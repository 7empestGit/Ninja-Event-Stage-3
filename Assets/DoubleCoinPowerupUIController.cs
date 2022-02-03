using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DoubleCoinPowerupUIController : MonoBehaviour
{
    private Image poweupSprite;

    void Start()
    {
        poweupSprite = GetComponent<Image>();
        StartCoroutine("Powerup");
    }

    private IEnumerator Powerup()
    {
        while (poweupSprite.fillAmount > 0)
        {
            poweupSprite.fillAmount -= Time.deltaTime / 10f;
            yield return null;
        }
        GameManager.instance.IsPowerupActive = false;
        Destroy(gameObject);
    }
}
