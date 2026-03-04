using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class SceneSwitching1: MonoBehaviour 
{
    public Button button;

    public void Start()
    {
        button.onClick.AddListener(SwitchScene);
    }

    void SwitchScene()
    {
        SceneManager.LoadScene(1);
    }
}
