using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class StartMenuUI : MonoBehaviour
{
    public TMP_InputField nameInput;
    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        if (Persistence.Instance != null)
        {
            nameInput.text = Persistence.Instance.PlayerName;
        }
    }

    public void EnableStartButton()
    {
        startButton.interactable = !string.IsNullOrEmpty(nameInput.text);
    }

    public void StartGame()
    {
        Persistence.Instance.PlayerName = nameInput.text;
        Persistence.Instance.LoadHighScore();
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit()
#endif
    }
}
