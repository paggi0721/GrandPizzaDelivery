using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

/// <summary>
/// 리듬 게임 관련된 데이터를 관리하는 싱글톤 클래스
/// </summary>
public class RhythmManager : MonoBehaviour
{
    public static RhythmManager Instance = null;    // 싱글톤 인스턴싱
    public string Title;                            // 관리 할 곡 제목
    public decimal CurrentTime;                     // 현재 시간
    public AudioData Data;                          // 곡 데이터
    public float Speed;                             // 속도
    public bool SceneChange;
    public AudioSource BgSound;
    public RhythmStorage Storage;
    public JudgeStorage Judges;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);

        Instance = this;
        Judges = new JudgeStorage();
        DontDestroyOnLoad(Instance);
    }

    private void Update()
    {
        Judges.SetAttractive();
        if ((float)CurrentTime >= Data.Length && !SceneChange)
        {
            EndScene();
        }
        if (Input.GetKeyDown(KeyCode.F5) && SceneManager.GetActiveScene().name == "RhythmScene")
        {
            EndScene();
        }
    }

    /// <summary>
    /// 곡 데이터를 Json 파일로 저장
    /// </summary>
    public void SaveData()
    {
        JsonManager<AudioData>.Save(Data, Title);
    }

    /// <summary>
    /// Json 파일인 곡 데이터 불러오기
    /// </summary>
    public void LoadData()
    {
        Data = new AudioData(Title);
    }

    public void Init()
    {
        LoadData();
        CurrentTime = 0;
        Judges.Init();
        
        SceneChange = false;
        if (BgSound == null)
            BgSound = GameObject.Find("BGSound").GetComponent<AudioSource>();
        BgSound.Play();
    }

    private void EndScene()
    {
        LoadScene.Instance.LoadPizzaMenu();
        Constant.PizzaAttractiveness = Judges.Attractive;
        SceneChange = true;
    }
}
