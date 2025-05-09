using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public float countdownTime = 60f;

    private float currentTime;
    private bool isCounting = false;

    void Start()
    {
        currentTime = countdownTime;
        UpdateCountdownDisplay();
        // StartCountdown();
    }

    public void StartCountdown()
    {
        if (!isCounting)
        {
            isCounting = true;
            StartCoroutine(CountdownRoutine());

            countdownText.gameObject.SetActive(true);
        }
    }

    private System.Collections.IEnumerator CountdownRoutine()
    {
        while (currentTime > 0)
        {
            yield return new WaitForSeconds(1f);
            currentTime--;
            UpdateCountdownDisplay();
        }

        currentTime = 0;
        UpdateCountdownDisplay();
        isCounting = false;
        Debug.Log("Countdown Finished!");
    }

    private void UpdateCountdownDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
