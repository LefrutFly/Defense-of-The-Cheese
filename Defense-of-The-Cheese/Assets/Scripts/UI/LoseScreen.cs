using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LoseScreen : MonoBehaviour
{
    [SerializeField] private Button restartGameButton;
    [SerializeField] private TMP_Text timeNowText;
    [SerializeField] private TMP_Text killsNowText;
    [SerializeField] private TMP_Text bulletsNowText;
    [SerializeField] private TMP_Text timeBestText;
    [SerializeField] private TMP_Text killsBestText;
    [SerializeField] private TMP_Text bulletsBestText;

    [Inject] private Statistics statistics;

    public Button RestartGameButton => restartGameButton;

    private void OnEnable()
    {
        timeNowText.text = "Time : " + statistics.TimeNow;
        timeBestText.text = "Time : " + statistics.data.TimeBest;

        killsNowText.text = "Kills : " + statistics.KillsNow;
        killsBestText.text = "Kills : " + statistics.data.KillsBest;

        bulletsNowText.text = "Bullets : " + statistics.BulletsNow;
        bulletsBestText.text = "Bullets : " + statistics.data.BulletsBest;
    }
}
