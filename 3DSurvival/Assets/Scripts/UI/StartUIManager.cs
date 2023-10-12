using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartUIManager : MonoBehaviour
{
    [SerializeField] Image backImage;
    [SerializeField] Image fillBarImage;
    [SerializeField] Image fillImage;
    [SerializeField] Image titleImage;
    [SerializeField] GameObject startButton;
    float _count;
    float _alpha;
    Color _color;
    void Start()
    {
        _color = titleImage.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(fillImage.fillAmount >= 1f) 
        {
            fillBarImage.gameObject.SetActive(false);
            _color.a += Time.deltaTime * 2f;
            titleImage.color = _color;
            if(titleImage.color.a >= 1f)
            {
                _count += Time.deltaTime;
                if (_count >= 1f)
                {
                    backImage.gameObject.SetActive(false);
                    startButton.SetActive(true);
                }
                
            }
        }
        else
        {
            fillImage.fillAmount += Time.deltaTime;
        }
    }
    public void GameStart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
