using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Design Intent:
/// Have Manager create an instance of this object on each level
/// Update the PlayerPref Int when a new highscore is reached on a
/// given level.
///
/// 3 Stars available:
///     1 for getting all wisps
///     1 for 50% from best time
///     1 for best time
///     
/// </summary>

public class ScoreSystem
{
    private int highscore; // 0-3
    private string levelName; // scene names
    private float bestTime; // fewest seconds to complete 

    /// <summary>
    /// Object to manage the score for a level
    /// </summary>
    /// <param name="levelName">string representing level</param>
    /// <param name="maximumScore">float representing score needed for 3 stars</param>
    public ScoreSystem(string levelName, float bestTimeInSeconds)
    {
        this.levelName = levelName;
        highscore = GetHighscoreForLevel(this.levelName);
        bestTime = bestTimeInSeconds;
    }


    /// <summary>
    /// Checks PlayerPrefs for a highscore on given levelName and creates it at 0 if not
    /// </summary>
    /// <param name="levelName">string representing level</param>
    /// <returns>the value in player prefs</returns>
    public int GetHighscoreForLevel(string levelName)
    {
        // check whether highscore for this level exists
        if (PlayerPrefs.HasKey(levelName))
        {
            return PlayerPrefs.GetInt(levelName);
        }

        // set new highscore as 0
        PlayerPrefs.SetInt(levelName, 0);
        return PlayerPrefs.GetInt(levelName);       
    }

    /// <summary>
    /// Calculates whether player earned 0-3 stars on level
    /// </summary>
    /// <param name="currentTime">time to complete the level in seconds</param>
    /// <param name="percentOfWispsCollected">100% == 1.0f</param>
    /// <returns></returns>
    public int CalculateScore(float currentTime, float percentOfWispsCollected)
    {
        int yourScore = 0;

        // all wisps collected
        if (percentOfWispsCollected == 1f)
        {
            Debug.Log("[ScoreSystem] Star Awarded For Wisps");
            yourScore++;
        }

        // close to best time
        if (currentTime <= 1.5f * bestTime)
        {
            Debug.Log("[ScoreSystem] Star Awarded For Good Time");
            yourScore++;
            // actual best time
            if (currentTime <= bestTime)
            {
                Debug.Log("[ScoreSystem] Star Awarded For Best Time");
                yourScore++;
            }
        }         
        return yourScore;
    }

    /// <summary>
    /// Call this method to change the PlayerPref for given level
    /// </summary>
    /// <param name="newScore"></param>
    public void SetHighscoreForLevel(string levelName, int newScore)
    {
        PlayerPrefs.SetInt(levelName, newScore);
    }

}
