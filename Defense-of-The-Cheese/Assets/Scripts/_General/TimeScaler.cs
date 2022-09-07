using UnityEngine;
using UnityEngine.UI;

public class TimeScaler : MonoBehaviour
{
    [SerializeField] private Text text;

    private float scale;

    private void LateUpdate()
    {
        text.text = "X " + (int)scale;
    }

    public void SclaeTime(float scale)
    {
        Time.timeScale = scale;
        this.scale = scale;
    }
}
