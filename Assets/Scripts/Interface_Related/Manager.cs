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
    public bool tempDeathBool;
    
    // UI
    public GameObject deathScreen;
    public GameObject heartContainer;
    public Image[] heartImagesArray;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public bool deathScreenVisible;
    public Camera mainCamera;
    

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        timerSeconds = 0;
        wispsCollected = 0;

        player = GetComponent<SideScrollPlayer>();
        health = RefactoredHealth.getInstance();
        heartImagesArray = heartContainer.GetComponentsInChildren<Image>();
        print(heartImagesArray.Length);
        
        tempDeathBool = false;

        HideDeathScreen();
        GetWispsInScene();

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timerSeconds += Time.deltaTime;
        timerDisplay = formatTimerDisplay(timerSeconds);
         
        
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
        if (health.GetCurrentHealth() == 0)
        {         
            ShowDeathScreen();
            // freeze the game
            Time.timeScale = 0;
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

    

    private void HideDeathScreen()
    {
        // move behind the camera once
        deathScreen.transform.position = new Vector3(mainCamera.transform.position.x,
                                            mainCamera.transform.position.y,
                                            mainCamera.transform.position.z - 1000);      
    }

    private void ShowDeathScreen()
    {
        // move to camera
        deathScreen.transform.position = new Vector3(
                                        413,
                                        215,
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
}


