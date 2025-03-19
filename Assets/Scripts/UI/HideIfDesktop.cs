using UnityEngine;
using YG;

public class HideIfDesktop : MonoBehaviour
{
    private void Start()
    {
        if (YG2.envir.isDesktop)
        {
            gameObject.SetActive(false);
        }
    }
}
