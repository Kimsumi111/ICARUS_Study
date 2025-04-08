using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataManager : SingletoneBehaviour<UserDataManager>
{
    public bool ExistsSavedData { get; private set; }
    
    public List<IUserData> UserDatas { get; private set; }  = new List<IUserData>();
    
    protected override void Init()
    {
        base.Init();  // 꼭 붙이기
        // 모든 유저 데이터를 List에 추가
        // 세팅, 굿즈 데이터를 동시에 인스턴스로 생성 및 리스트에 넣기
        UserDatas.Add(new UserGoodsData());
        UserDatas.Add(new UserSettingData());
    }
    
    public void SetDefaultUserData()
    {
        for (int i = 0; i < UserDatas.Count; i++)
        {
            UserDatas[i].SetDefaultData();
        }
    }
    
    public void LoadUserData()
    {
        ExistsSavedData = PlayerPrefs.GetInt("ExistsSavedData", 0) == 1 ? true : false;

        if (ExistsSavedData)
        {
            for (int i = 0; i < UserDatas.Count; i++)
            {
                UserDatas[i].LoadData();
            }
        }
    }
    
    public void SaveUserData()
    {
        bool hasSaveError = false;
        for (int i = 0; i < UserDatas.Count; i++)
        {
            bool isSaveSuccess = UserDatas[i].SaveData();  // bool 값 반환.
            if (!isSaveSuccess)
            {
                hasSaveError = true;
            }   
        }

        if (!hasSaveError)
        {
            ExistsSavedData = true;
            PlayerPrefs.SetInt("ExistsSavedData", 1);
            PlayerPrefs.Save();  // 로컬 디바이스에 저장
        }
    }
}
