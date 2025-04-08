using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataTableManager : SingletoneBehaviour<DataTableManager>
{
    private const string DATA_PATH = "DataTable";
    private const string CHAPTER_DATA_TABLE = "ChapterDataTable";

    private List<ChapterData> ChapterDataTable = new List<ChapterData>();

    protected override void Init()
    {
        base.Init();
        
        LoadChapterDataTable();
    }

    private void LoadChapterDataTable()
    {
        // 파일 경로
        var parseDataTable = CSVReader.Read($"{DATA_PATH}/{CHAPTER_DATA_TABLE}");

        // 데이터 테이블을 순회하면서 ChapterDataTable 컨테이너에 넣어줌.
        foreach (var data in parseDataTable)
        {
            var chapterData = new ChapterData
            {
                ChapterNo = Convert.ToInt32(data["chapter_no"]),
                TotalStage = Convert.ToInt32(data["total_stages"]),
                ChapterRewardGem = Convert.ToInt32(data["chapter_reward_gem"]),
                ChapterRewardGold = Convert.ToInt32(data["chapter_reward_gold"]),
            };
            
            ChapterDataTable.Add(chapterData);
        }
    }
    
    public ChapterData GetChapterData(int chapterNo)
    {
        return ChapterDataTable.Where(item => item.ChapterNo == chapterNo).FirstOrDefault();
        // item이 우리가 검색한 챕터 넘과 같으면 리턴. 이 조건에 부합하는 첫 엘리먼트 반환. 없으면 null 반환.
    }
}

public class ChapterData
{
    public int ChapterNo;
    public int TotalStage;
    public int ChapterRewardGem;
    public int ChapterRewardGold;
}
