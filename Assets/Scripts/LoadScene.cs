using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// �Ѽ�ȣ �ۼ�
public class LoadScene : MonoBehaviour
{
    /* // �̱��� //
* instance��� ������ static���� ������ �Ͽ� �ٸ� ������Ʈ ���� ��ũ��Ʈ������ instance�� �ҷ��� �� �ְ� �մϴ� 
*/
    public static LoadScene Instance = null;

    private void Awake()
    {
        if (Instance == null) //instance�� null. ��, �ý��ۻ� �����ϰ� ���� ������
        {
            Instance = this; //���ڽ��� instance�� �־��ݴϴ�.
            DontDestroyOnLoad(gameObject); //OnLoad(���� �ε� �Ǿ�����) �ڽ��� �ı����� �ʰ� ����
        }
        else
        {
            if (Instance != this) //instance�� ���� �ƴ϶�� �̹� instance�� �ϳ� �����ϰ� �ִٴ� �ǹ�
            {
                Destroy(this.gameObject); //�� �̻� �����ϸ� �ȵǴ� ��ü�̴� ��� AWake�� �ڽ��� ����
            }
        }
    }
    /// <summary>
    /// ���̵� ������ �����ְ� ���� �ҷ��ɴϴ�.
    /// </summary>
    /// <param name="str">�ҷ��� ���� �̸��Դϴ�.</param>
    public void ActiveTrueFade(string str)
	{
        Fade.Instance.gameObject.SetActive(true);
        Fade.Instance.SetLoadSceneName(str);
	}
    public void LoadS(string str)
	{
		SceneManager.LoadScene(str);
	}
	public void LoadRhythm()
	{
		if (Constant.ChoiceIngredientList.Count > 0)
		{
            ActiveTrueFade("RhythmScene");
		}
	}

    public void LoadPizzaMenu()
	{
        ActiveTrueFade("InGameScene");

	}
}