using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Timer timerScript = FindObjectOfType<Timer>(); 
            if(timerScript != null) 
            {
                timerScript.AddTime(30.0f); 
            }
            Destroy(gameObject); 
        }
    }
}
