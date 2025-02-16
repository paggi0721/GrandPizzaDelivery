using DayNS;
using UnityEngine;
using UnityEngine.SceneManagement;

// 한석호 작성
public class LoadScene : MonoBehaviour
{
    /* // 싱글톤 //
* instance라는 변수를 static으로 선언을 하여 다른 오브젝트 안의 스크립트에서도 instance를 불러올 수 있게 합니다 
*/
    public static LoadScene Instance = null;

    private bool oneTimeMethod = false;

    private void Awake()
    {
        if (Instance == null) //instance가 null. 즉, 시스템상에 존재하고 있지 않을때
        {
            Instance = this; //내자신을 instance로 넣어줍니다.
            DontDestroyOnLoad(gameObject); //OnLoad(씬이 로드 되었을때) 자신을 파괴하지 않고 유지
        }
        else
        {
            if (Instance != this) //instance가 내가 아니라면 이미 instance가 하나 존재하고 있다는 의미
            {
                Destroy(this.gameObject); //둘 이상 존재하면 안되는 객체이니 방금 AWake된 자신을 삭제
            }
        }
    }
    /// <summary>
    /// 페이드 연출을 보여주고 씬을 불러옵니다.
    /// </summary>
    /// <param name="str">불러올 씬의 이름입니다.</param>
    public void ActiveTrueFade(string str)
    {
        Fade.Instance.gameObject.SetActive(true);
        Fade.Instance.SetLoadSceneName(str);
    }
    public void LoadNextDay(bool isDead)
    {
        if (oneTimeMethod) { return; }
        oneTimeMethod = true;
        if (Constant.NowDay != DayEnum.SUNDAY)
        {
            Constant.NowDay++;
        }
        else
        {
            Constant.NowDay = DayEnum.MONDAY;
        }
        Constant.NowDate++;
        if (isDead) { Constant.IsDead = true; }

        ActiveTrueFade("CalculateScene");
    }
    public void LoadS(string str)
    {
        oneTimeMethod = false;
        SceneManager.LoadScene(str);
    }
    public void LoadRhythm()
    {
        if (Constant.ChoiceIngredientList.Count > 0)
        {
            ActiveTrueFade("SelectScene");
        }
    }
    public void LoadPrologueToInGameScene()
    {
        Constant.isStartGame = true;
        DataManager.LoadData();
        ActiveTrueFade("InGameScene");
    }

    public void LoadPizzaMenu()
    {
        Constant.IsMakePizza = true;
        Constant.DevelopPizza.Add(new Pizza("새 피자" + System.DateTime.Now.ToString("MM-dd-HH-mm-ss"), Constant.Perfection, Constant.ProductionCost
            , Random.Range(2000 * Constant.ingreds.Count, 4000 * Constant.ingreds.Count + 1) + 10000, Constant.PizzaAttractiveness, Constant.ingreds, Constant.TotalDeclineAt, 100, 0));
        ActiveTrueFade("InGameScene");
    }
}
