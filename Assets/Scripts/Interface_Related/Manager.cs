using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    // Scoring
    public float score;
    public float timeToLevelComplete;
    public float timerSeconds;
    public string timerDisplay;
    public int wispsCollected;
    public List<Wisp> wispList;

    // Player
    private SideScrollPlayer player;
    private RefactoredHealth health;
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
    

    // Start is called before the first frame update
    void Start()
    {
        print("Start: started method");
        score = 0;
        timerSeconds = 0;
        wispsCollected = 0;

        player = GetComponent<SideScrollPlayer>();
        health = RefactoredHealth.getInstance();
        health.RestoreFullHealth();
        heartImagesArray = heartContainer.GetComponentsInChildren<Image>();    
        
        // freezeTime = false;

        HideDeathScreen();
        HideWinScreen();
        GetWispsInScene();
        UnFreezeTime();

        print("Start: completed method");

    }

    // Update is called once per frame
    void Update()
    {
        timerSeconds += Time.deltaTime;
        timerDisplay = formatTimerDisplay(timerSeconds);
        currentHealth = health.GetCurrentHealth();
         
        
        foreach (Wisp wisp in wispList)
        {
            // Dynamically update wispList upon collection
            if (wisp.isCollected)
            {              
                wispsCollected += 1;        
                wispList.Remove(wisp);                                
            }
        }

        // PLAYER DEATH
        if (currentHealth <= 0)
        {
            print(" health is zero " + health.GetCurrentHealth());
            ShowDeathScreen();
            // freeze the game
            FreezeTime();
        }
        


        // Refresh health display
        DisplayCurrentHealth();

    }

    private void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 200, 40), "Score: " + wispsCollected.ToString());
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
        deathScreen.transform.position = new Vector3(mainCamera.transform.position.x,
                                            mainCamera.transform.position.y,
                                            mainCamera.transform.position.z - 1000);      
    }

    public void ShowDeathScreen()
    {
        // move to camera
        deathScreen.transform.position = new Vector3(
                                        413,
                                        215,
                                        mainCamera.transform.position.z);
    }
    public void HideWinScreen()
    {
        // move behind the camera once
        winScreen.transform.position = new Vector3(mainCamera.transform.position.x,
                                            mainCamera.transform.position.y,
                                            mainCamera.transform.position.z - 1000);
    }

    public void ShowWinScreen()
    {
        // move to camera
        winScreen.transform.position = new Vector3(
                                        mainCamera.transform.position.x,
                                        mainCamera.transform.position.y,
                                        mainCamera.transform.position.z);
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
        print("Level won!");
        ShowWinScreen();
        FreezeTime();
    }
}


