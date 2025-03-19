using UnityEngine;
using UnityEngine.UI;
using YG;

public class PauseButton : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _button.onClick.AddListener(PauseGame);
    }

    private void PauseGame()
    {
        GameManager.Instance.PauseGame();
    }
    
}
