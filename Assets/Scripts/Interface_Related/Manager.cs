using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    // Scoring
    public string levelName;
    public float score;
    public float timeToLevelComplete;
    public float threeStarTimeInSeconds;
    public float timerSeconds;
    public string timerDisplay;
    public float wispsAvailable;
    public float wispsCollected;
    public List<Wisp> wispList;
    public ScoreSystem scoreObject;
    public int highscore;
    public Text TimerValue;
    public Text ScoreValue;

    // Player
    private SideScrollPlayer player;
    private Health health;
    public int currentHealth;
    // public bool freezeTime;

    // UI
    public GameObject deathScreen;
    public GameObject winScreen;
    public GameObject heartContainer;
    public Image[] heartImagesArray;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public bool deathScreenVisible;
    public bool winScreenVisible;
    public Camera mainCamera;
    public Sprite[] starImagesArray;
    public Image LevelOneStars;
    public Image LevelTwoStars;

    // DataManagement
    public string LevelOneName = "SideScrollPrototyping";
    public string LevelTwoName = "2_level_raft";
    public bool ResetHighScores;
    


    // Start is called before the first frame update
    void Start()
    {

        
        

        // Score System
        levelName = SceneManager.GetActiveScene().name;
        scoreObject = new ScoreSystem(levelName, threeStarTimeInSeconds);
        // TitleScreen Unique Logic
        if (levelName.Equals("TitleScreen"))
        {
            int highscoreOne = scoreObject.GetHighscoreForLevel(LevelOneName);
            int highscoreTwo = scoreObject.GetHighscoreForLevel(LevelTwoName);

            LevelOneStars.sprite = starImagesArray[highscoreOne];
            print("ONE: " + highscoreOne.ToString());
            LevelTwoStars.sprite = starImagesArray[highscoreTwo];
            print("TWO: " + highscoreTwo.ToString());

        }
        else
        {
            highscore = scoreObject.GetHighscoreForLevel(levelName);

            score = 0;
            timerSeconds = 0;
            wispsCollected = 0;
            GetWispsInScene();
            wispsAvailable = wispList.Count;


            player = GetComponent<SideScrollPlayer>();
            health = Health.GetInstance();
            health.RestoreFullHealth();
            heartImagesArray = heartContainer.GetComponentsInChildren<Image>();

            // freezeTime = false;

            HideDeathScreen();
            HideWinScreen();

            UnFreezeTime();
        }     
        


    }

    // Update is called once per frame
    public void Update()
    {
        if (levelName.Equals("TitleScreen")) { return;  }

        // This only runs on NOT titlescreen scenes
        timerSeconds += Time.deltaTime;
        timerDisplay = formatTimerDisplay(timerSeconds);
        TimerValue.text = timerDisplay;
        currentHealth = health.GetCurrentHealth();
        string scoreString = GetScoreString(wispsCollected, wispsAvailable);
        ScoreValue.text = scoreString;


        foreach (Wisp wisp in wispList)
        {
            //TODO: Redesign this to be less destructive
            // Dynamically update wispList upon collection
            if (wisp.isCollected)
            { 
                wispsCollected += 1;
                try
                {
                    wispList.Remove(wisp);
                }
                catch (System.InvalidOperationException e)
                {
                    Debug.Log(e);
                }
                
                
            }
        }

        // PLAYER DEATH
        if (currentHealth <= 0)
        {
            ShowDeathScreen();
            FreezeTime();
        }



        // Refresh health display
        DisplayCurrentHealth();

    }


    /// <summary>
    /// Helper to convert the raw seconds into a more UI friendly string mm:ss
    /// </summary>
    /// <param name="timerSeconds"></param>
    /// <returns></returns>
    private string formatTimerDisplay(float timerSeconds)
    {
        float minutes = Mathf.FloorToInt(timerSeconds / 60);
        float seconds = Mathf.FloorToInt(timerSeconds % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Gets all objects tagged "Wisp", converts to Wisp and adds to List param
    private void GetWispsInScene()
    {
        Object[] wispObjectArray = FindObjectsOfType(typeof(Wisp), false);
        foreach (Object obj in wispObjectArray)
        {
            wispList.Add((Wisp)obj);
        }
    }



    public void HideDeathScreen()
    {
        // move behind the camera once
        //deathScreen.transform.position = new Vector3(mainCamera.transform.position.x,
        //                                    mainCamera.transform.position.y,
        //                                    mainCamera.transform.position.z - 1000);      
        deathScreen.SetActive(false);
    }

    public void ShowDeathScreen()
    {
        // move to camera
        //deathScreen.transform.position = new Vector3(
        //                                413,
        //                                215,
        //                                mainCamera.transform.position.z);
        deathScreen.SetActive(true);
    }
    public void HideWinScreen()
    {
        // move behind the camera once
        //winScreen.transform.position = new Vector3(mainCamera.transform.position.x,
        //                                    mainCamera.transform.position.y,
        //                                    mainCamera.transform.position.z - 1000);
        winScreen.SetActive(false);
    }

    public void ShowWinScreen()
    {
        // move to camera
        //winScreen.transform.position = new Vector3(
        //                                mainCamera.transform.position.x,
        //                                mainCamera.transform.position.y,
        //                                mainCamera.transform.position.z);
        winScreen.SetActive(true);
    }

    /// <summary>
    /// Updates the Heart Images to match RefactoredHealth
    /// </summary>
    private void DisplayCurrentHealth()
    {
        for (int i = 0; i < heartImagesArray.Length; i++)
        {
            if (i < health.GetCurrentHealth())
            {
                heartImagesArray[i].sprite = fullHeart;
            }
            else
            {
                heartImagesArray[i].sprite = emptyHeart;
            }
        }
    }

    public void FreezeTime()
    {
        Time.timeScale = 0f;
    }

    public void UnFreezeTime()
    {
        Time.timeScale = 1f;
    }

    public void CompleteLevel() //should call when player touches the fireplace
    {
        ShowWinScreen();
        FreezeTime();
        UpdateHighscore();
    }

    public void UpdateHighscore()
    {
        float percentOfWispsCollected = wispsCollected / wispsAvailable;
        int newHighscore = scoreObject.CalculateScore(timerSeconds, percentOfWispsCollected);
        if (newHighscore > highscore)
        {
            scoreObject.SetHighscoreForLevel(levelName, newHighscore);

        }
        print("[Manager] NEW SCORE: " + newHighscore.ToString());
        print("[Manager] BEST SCORE: " + scoreObject.GetHighscoreForLevel(levelName));

    }

    public void ResetScores()
    {
        scoreObject.ResetHighscore(LevelOneName);
        scoreObject.ResetHighscore(LevelTwoName);

        int highscoreOne = scoreObject.GetHighscoreForLevel(LevelOneName);
        int highscoreTwo = scoreObject.GetHighscoreForLevel(LevelTwoName);

        LevelOneStars.sprite = starImagesArray[highscoreOne];
        LevelTwoStars.sprite = starImagesArray[highscoreTwo];

    }

    public string GetScoreString(float wispsCollected, float wispsAvailable)
    {
        string collectedString = wispsCollected.ToString("0");
        string availableString = wispsAvailable.ToString("0");
        string outputString = string.Concat("SCORE: ", collectedString, " / ", availableString);

        return outputString;
    }
    //public void DidPlayerFall()
    //{
    //    print("before if");
    //    if (player)
    //    {
    //        currentHealth = 0;
    //        print("Play fell below crate");
    //    }
    //    print("HERE");
    //}
}
