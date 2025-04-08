using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserSettingData : IUserData
{
    public bool Sound { get; set; }

    public void SetDefaultData()
    {
        Sound = true;
    }

    public bool LoadData()
    {
        bool result = false;

        try
        {
            PlayerPrefs.SetInt("Sound", Sound ? 1 : 0);
            result = true;
        }
        catch (Exception e)
        {
            Logger.LogError(e.Message);
        }
        return result;
    }

    public bool SaveData()
    {
        bool result = false;

        try
        {
            PlayerPrefs.SetInt("Sound", Sound ? 1 : 0);
            PlayerPrefs.Save();
            result = true;

            Logger.Log($"Sound : {Sound}");
        }
        catch (Exception e)
        {
            Logger.LogError(e.Message);
        }
        
        return result;
    }
}
