using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI textField;

    CanvasGroup _canvasGroup;

    private const string HidingText = "Вылезти";

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        PlayerStateMachine.Instance.OnStateChanged += ChangeUIWithState;
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnDisable()
    {
        PlayerStateMachine.Instance.OnStateChanged -= ChangeUIWithState;
    }

    private void ChangeUIWithState()
    {
        switch (PlayerStateMachine.Instance.PlayerState)
        {
            case PlayerState.Default:
                HideText();
                break;
            case PlayerState.Hiding:
                ShowTextWhileHiding();
                break;
        }
    }

    public void ShowText(string text)
    {
        _canvasGroup.alpha = 1;
        textField.text = text;
    }

    public void HideText()
    {
        _canvasGroup.alpha = 0;
    }

    private void ShowTextWhileHiding()
    {
        ShowText(HidingText);
    }
}
