using UnityEngine;

public class RhythmMenu : MonoBehaviour
{
    public GameObject Menu;
    public AudioSource BgSound;
    void Update()
    {
        if (BgSound.time <= 0f)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu.SetActive(!Menu.activeSelf);
            if (Menu.activeSelf)
                BgSound.Pause();
            else
                BgSound.Play();
        }
    }
}
