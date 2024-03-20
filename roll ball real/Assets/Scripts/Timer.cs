using UnityEngine;
using TMPro; 

// CÓDIGO CONSTRUÍDO COM AUXÍLIO DO CHATGPT

public class Timer : MonoBehaviour
{
    public float timeLeft = 120.0f; 
    public TMP_Text timerText;

    private void Start()
    {
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
            timeLeft = 0;
            
            Debug.Log("Tempo Esgotado!");
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void AddTime(float timeToAdd)
    {
        timeLeft += timeToAdd;
        UpdateTimerDisplay();
    }
    public void ResetTimeToTwoMinutes(){
    timeLeft = 120.0f;
    UpdateTimerDisplay();
    }

}
