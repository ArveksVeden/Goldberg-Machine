using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SaveManager
{
    private static Level[] Levels;

    public static void Initialize()
    {

        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            Levels[i] = new Level(SceneManager.GetSceneByBuildIndex(i).name, false);
        }

        PlayerPrefs.SetString("Save", JsonUtility.ToJson(Levels));
    }

    public static void LevelDone(string name)
    {
        int index;

        for (index = 0; index < Levels.Length; index++)
            if (Levels[index].name == name)
                break;

        Levels[index].IsDone = true;

        if (!PlayerPrefs.HasKey("Save"))
            PlayerPrefs.SetString("Save", JsonUtility.ToJson(Levels));
        else
            Initialize();
    }

    public static void LoadLevelsInformation()
    {
        if (!PlayerPrefs.HasKey("Save"))
            Levels = JsonUtility.FromJson<Level[]>(PlayerPrefs.GetString("Save"));
        else
            Initialize();
    }

    public static bool IsLevelDone(string name)
    {
        int index;

        for (index = 0; index < Levels.Length; index++)
            if (Levels[index].name == name)
                break;
        
        return Levels[index].IsDone;
    }
}
