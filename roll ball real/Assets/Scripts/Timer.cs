using UnityEngine;
using TMPro; // Se você estiver usando TextMeshPro para exibir o timer na UI

public class Timer : MonoBehaviour
{
    public float timeLeft = 120.0f; // 2 minutos em segundos
    public TMP_Text timerText; // Referência ao componente de texto da UI, se aplicável

    private void Start()
    {
        // Atualiza a exibição do timer ao iniciar
        UpdateTimerDisplay();
    }

    private void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            // Evita que o tempo vá para negativo
            timeLeft = 0;
            
            // O tempo acabou, pode colocar aqui o que acontece quando o tempo acaba
            Debug.Log("Tempo Esgotado!");
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);

        // Corrige a exibição para mostrar corretamente os minutos e segundos
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void AddTime(float timeToAdd)
    {
        timeLeft += timeToAdd;
        // Para garantir que a exibição seja atualizada imediatamente ao adicionar tempo
        UpdateTimerDisplay();
    }
}
