using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingView : MonoBehaviour
{
    public GameObject settingView;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        player = GetComponent<GameObject>();

    }

    public void ClickSetting()
    {
        settingView.SetActive(true);

        Time.timeScale = 0;
    }

    public void ClickPlay()
    {
        settingView.SetActive(false);

        Time.timeScale = 1;
    }

    public void ClickHome()
    {
        SceneManager.LoadScene(0);
    }

    public void ClickResume()
    {
        SceneManager.LoadScene(1);
        //player.transform.position = new Vector2(2, 2);
    }
    

}
