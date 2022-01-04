using UnityEngine;

public class FinishLineController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<CarController>() != null)
            {
                other.GetComponent<CarController>().StopCar();
                PlayStateUIManager.instance.OpenFinishPanel();
            }
        }
    }
}
