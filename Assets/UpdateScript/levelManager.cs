using System.Collections;
using UnityEngine;
using TMPro;

public class levelManager : MonoBehaviour
{
    public static levelManager levelMan;
    public GameObject mainMenu,LevelUI,playButton, nextButton, retryButton;
    public TextMeshProUGUI levelText;
    public int level = 0;
    public bool gameOver = false;

    void Start()
    {
        levelMan = this;
        LevelUI.SetActive(false);
        playButton.SetActive(true);

    }
    private void Update()
    {
        showNextButton();
    }
    public void Play()
    {
        LevelUI.SetActive(true);
        mainMenu.SetActive(false);
        playButton.GetComponent<Animator>().SetBool("exit", true);
    }
    void showNextButton()
    {
        if(!gameOver)
        {
            nextButton.SetActive(false);
        }
    }
    
}
