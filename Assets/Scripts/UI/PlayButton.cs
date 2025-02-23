using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    private Button _button;
    
    private void Awake()
    {
        _button = GetComponent<Button>();
        
        _button.onClick.AddListener(LoadGameScene);
    }

    private void LoadGameScene()
    {
        Loader.Load(Loader.Scene.Game);
    }
}
