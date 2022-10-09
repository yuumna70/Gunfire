using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{

    public GameObject title;

    public GameObject dontdestory;

    public GameObject optionView;

    public GameObject optionView2;

    


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<GameObject>();
        GetComponent<Transform>();
        GetComponent<MainManager>();

        title.GetComponent<Transform>();

        

        

    }

    void Awake()
    {
        DontDestroyOnLoad(dontdestory);

        GameObject[] audios = GameObject.FindGameObjectsWithTag("Audio");

        if(audios.Length >= 2)
        {
            Destroy(audios[1]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickStart()
    {
        SceneManager.LoadScene("2. MainStage");
        Time.timeScale = 1;

        
    }

    public void ClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }

    public void ClickOtion()
    {
        optionView.SetActive(true);

        Time.timeScale = 0;
        
    }

    public void ClickOkay()
    {
        optionView.SetActive(false);

        Time.timeScale = 1;
    }

    public void ClickOkay1()
    {
        optionView2.SetActive(false);

        Time.timeScale = 1;
    }

    public void ClickNext()
    {
        optionView.SetActive(false);
        optionView2.SetActive(true);

        Time.timeScale = 0;
    }

    public void ClickBefore()
    {
        optionView.SetActive(true);
        optionView2.SetActive(false);

        Time.timeScale = 0;
    }

}
