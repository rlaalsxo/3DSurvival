using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartUIManager : MonoBehaviour
{
    [SerializeField] Image backImage;
    [SerializeField] Image fillBarImage;
    [SerializeField] Image fillImage;
    [SerializeField] Image titleImage;
    [SerializeField] Button startButton;
    void Awake()
    {
        startButton.onClick.AddListener(StartButtonClick);
    }
    public void StartButtonClick()
    {
        LoadingSceneManager.LoadScene(2, null);
    }
}
