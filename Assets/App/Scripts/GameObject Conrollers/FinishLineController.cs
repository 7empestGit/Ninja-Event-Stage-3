using UnityEngine;

public class FinishLineController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<CarController>() != null)
            {
                CarController otherCarController = other.GetComponent<CarController>();
                otherCarController.isWon = true;
                otherCarController.StopCar();
                PlayStateUIManager.Instance.OpenFinishPanel();
            }
        }
    }
}
