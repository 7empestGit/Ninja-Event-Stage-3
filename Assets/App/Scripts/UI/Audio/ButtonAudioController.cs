using UnityEngine;
using UnityEngine.UI;

public class ButtonAudioController : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SFXAudioController.instance.clickSound.Play);
    }
}
