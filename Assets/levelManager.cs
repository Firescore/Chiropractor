using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class levelManager : MonoBehaviour
{
    public GameObject[] scene;
    public GameObject mainMenu,LevelUI,playButton, nextButton, retryButton;
    public TextMeshProUGUI levelText;
    public int level = 0, i, i1;
    // Start is called before the first frame update
    void Start()
    {
        LevelUI.SetActive(false);
        playButton.SetActive(true);
        /*
        i1 = 0;
        i = 0;
        scene[i].SetActive(true);
        level += 1;
        levelText.text = "Level " + level.ToString();*/
    }

    // Update is called once per frame
    void Update()
    {
        if(i <= 4)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (i >= 1)
                {
                    i1 += 1;
                }
                i += 1;
                sceneEnable();
                level += 1;
                levelText.text = "Level " + level.ToString();
            }
        }
        
    }
    void sceneEnable()
    {
        scene[i].SetActive(true);
        scene[i1].SetActive(false);
    }
    public void Play()
    {
        LevelUI.SetActive(true);
        playButton.SetActive(false);
        mainMenu.SetActive(false);
        i1 = 0;
        i = 0;
        scene[i].SetActive(true);
        level += 1;
        levelText.text = "Level " + level.ToString();
    }
    public void nexLevel()
    {
        if (i <= 4)
        {
                if (i >= 1)
                {
                    i1 += 1;
                }
                i += 1;
                sceneEnable();
                level += 1;
                levelText.text = "Level " + level.ToString();
        }
    }
    public void retry()
    {
        sceneEnable();
    }
}
