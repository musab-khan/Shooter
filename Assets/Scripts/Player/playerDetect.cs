using UnityEngine;

public class playerDetect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyAI>().OnAware();
        }
    }
}
