using UnityEngine;

public class DoubleCoinPowerupController : MonoBehaviour
{
    [SerializeField] private GameObject object1, object2;

    private Vector3 object1StartPos, object2StartPos;

    void Start()
    {
        object1StartPos = object1.transform.position;
        object2StartPos = object2.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (object1.transform.position != object1StartPos || object2.transform.position != object2StartPos)
            return;

        GameManager.instance.ActivatePowerup();
        PlayStateUIManager.instance.StartCoroutine("ShowPowerup");
        Destroy(gameObject);
    }
}
