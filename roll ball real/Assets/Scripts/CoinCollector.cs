using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Timer timerScript = FindObjectOfType<Timer>(); // Encontra o script do timer na cena
            if(timerScript != null) 
            {
                timerScript.AddTime(30.0f); // Adiciona 30 segundos ao timer
            }
            Destroy(gameObject); // Destroi a moeda após ser coletada
        }
    }
}
