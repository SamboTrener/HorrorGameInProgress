using UnityEngine;
using UnityEngine.UI;
using YG;

public class LoadSceneButton : MonoBehaviour
{
    [SerializeField] private Loader.Scene scene;
    
    private Button _button;
    
    private void Awake()
    {
        _button = GetComponent<Button>();
        
        _button.onClick.AddListener(LoadGameScene);
    }

    private void LoadGameScene()
    {
        YG2.InterstitialAdvShow();
        Loader.Load(scene);
    }
}
