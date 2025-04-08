using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGoodsData : IUserData
{
    public long Gem { get; set; }
    public long Gold { get; set; }


    public void SetDefaultData()
    {
        Gem = 0;
        Gold = 0;
    }

    public bool LoadData()
    {
        bool result = false;

        try
        {
            Gem = long.Parse(PlayerPrefs.GetString("Gem"));
            Gold = long.Parse(PlayerPrefs.GetString("Gold"));
            result = true;
        }
        catch (Exception e)
        {
            Logger.LogError("Load failed ("+e.Message+")");
        }
        return result;
    }

    public bool SaveData()
    {
        bool result = false;
        try
        {
            PlayerPrefs.SetString("Gem", Gem.ToString());
            PlayerPrefs.SetString("Gold", Gold.ToString());
            PlayerPrefs.Save();
            result = true;
        }
        catch (Exception e)
        {
            Logger.LogError("Save failed ("+e.Message+")");
        }
        return result;
    }
}
