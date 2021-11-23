using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public float score;
    public float timeToLevelComplete;
    public float timerSeconds;
    public string timerDisplay;
    public int wispsCollected;
    public Wisp[] wispList;
    private SideScrollPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        timerSeconds = 0;
        wispsCollected = 0;
        player = GetComponent<SideScrollPlayer>();
        wispList = (Wisp[]) FindObjectsOfType(typeof(Wisp), false);
    }

    // Update is called once per frame
    void Update()
    {
        timerSeconds += Time.deltaTime;
        timerDisplay = formatTimerDisplay(timerSeconds);

        foreach (Wisp wisp in wispList)
        {
            if (wisp.isCollected)
            {
                wispsCollected += 1;
                /*TODO
                 Make this delete a wisp from the Manager's Array/List when it detects the collection.
                Currently keeps counting bc the isCollected flips true and element isn't properly deleted

                Some major refactoring may be necessary to make this function as intended.
                 */
            }
        }


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

    //private List<Wisp> GetWispsInScene()
    //{
    //    find
    //}
}


