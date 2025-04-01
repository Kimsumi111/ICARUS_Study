using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 제네릭
// : 타입을 변수처럼 사용하는 기능 <T> : 타입 매개변수
// where T : 제약조건
public class SingletoneBehaviour<T> : MonoBehaviour where T : SingletoneBehaviour<T>
{
    // 파괴여부
    protected bool m_IsDestroyed = false;
    
    // 정적변수
    protected static T m_Instance;
    
    // 외부에서 접근할 수 있도록 해주는 public 변수
    // static : 싱글톤 미니버젼
    public static T Instance
    {
        get
        {
            return m_Instance;
        }
    }

    private void Awake()
    {
        Init();
    }

    // DontDestroyOnLoad
    protected virtual void Init()
    {
        // 만약 이 인스턴스 없다면 이거를 인스턴스
        if (m_Instance == null)
        {
            m_Instance = this as T;
            if (m_IsDestroyed)
            {
                DontDestroyOnLoad(this);
            }
        }
        else
        {
            Destroy(this);
        }
    }

    // 싱글톤인 나는 단 하나!
    protected virtual void OnDestroy()
    {
        m_Instance = null;
    }
}


