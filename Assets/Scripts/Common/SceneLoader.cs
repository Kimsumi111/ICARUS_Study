using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 씬을 로드하는 클래스
public class SceneLoader : SingletoneBehaviour<SceneLoader>
{
    // enum
    public enum Scenetype
    {
        Title,
        Lobby,
        InGame
    }
    
    // 호출 방법 : SceneLoader.Instance.LoadScene(Scenetype.Title)
    // 로드함수
    public void LoadScene(Scenetype scenetype)
    {
        // 로그
        
        // 시간 초기화
        Time.timeScale = 1f;
        SceneManager.LoadScene(scenetype.ToString());  
    }
    
    // 리로드함수
    public void ReloadScene()
    {
        // 로그
        
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    // 비동기 씬 로드함수
    public AsyncOperation AsyncLoadScene(Scenetype scenetype)
    {
        Time.timeScale = 1f;
        return SceneManager.LoadSceneAsync(scenetype.ToString());
    }
}
