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
    private float highscore; // 0-3
    private string levelName; // scene names
    private float bestTime; // fewest seconds to complete 

    /// <summary>
    /// Object to manage the score for a level
    /// </summary>
    /// <param name="levelName">string representing level</param>
    /// <param name="maximumScore">float representing score needed for 3 stars</param>
    public ScoreSystem(string levelName)
    {
        this.levelName = levelName;
        highscore = GetHighscoreForLevel(this.levelName);
    }


    /// <summary>
    /// Checks PlayerPrefs for a highscore on given levelName and creates it at 0 if not
    /// </summary>
    /// <param name="levelName">string representing level</param>
    /// <returns></returns>
    public float GetHighscoreForLevel(string levelName)
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
            yourScore++;
        }

        // close to best time
        if (currentTime <= 1.5f * bestTime)
        {
            yourScore++;
            // actual best time
            if (currentTime <= bestTime)
            {
                yourScore++;
            }
        }         
        return yourScore;
    }

}
