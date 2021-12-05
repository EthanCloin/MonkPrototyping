using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // public Health healthbar;
    public bool tempDeathBool;
    
    // UI
    public GameObject deathScreen;
    public GameObject heartContainer;
    public bool deathScreenVisible;
    public Camera mainCamera;
    

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        timerSeconds = 0;
        wispsCollected = 0;

        player = GetComponent<SideScrollPlayer>();
        // healthbar = player.healthbar;
        tempDeathBool = false;

        deathScreenVisible = false;
        GetWispsInScene();
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
        // if (healthbar.GetIsDead())
        if (tempDeathBool)
        {
            ShowDeathScreen();
            // freeze the game
            Time.timeScale = 0;
        }
        else
        {
            HideDeathScreen();
            Time.timeScale = 1;
        }

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
        // move behind the camera
        deathScreen.transform.position = new Vector3(mainCamera.transform.position.x,
                                            mainCamera.transform.position.y,
                                            mainCamera.transform.position.z - 1000);
        print("moved deathscreen");
    }

    private void ShowDeathScreen()
    {
        // move to camera
        deathScreen.transform.position = new Vector3(
                                        413,
                                        215,
                                        mainCamera.transform.position.z);
    }
}


