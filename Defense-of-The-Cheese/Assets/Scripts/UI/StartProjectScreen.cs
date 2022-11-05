using UnityEngine;
using UnityEngine.UI;

public class StartProjectScreen : MonoBehaviour
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button exitGameButton;

    public Button StartGameButton => startGameButton;

    public Button ExitGameButton => exitGameButton;

    private void Awake()
    {
        exitGameButton.onClick.AddListener(Exit);
    }

    private void OnDestroy()
    {
        exitGameButton.onClick.RemoveListener(Exit);
    }

    private void Exit()
    {
        Application.Quit();
    }
}