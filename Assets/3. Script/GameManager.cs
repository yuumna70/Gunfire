using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject endingView;

    public Text lifeTxt;

    public GameObject ending;

    public Text num;

    public Text co;

    

    [HideInInspector]
    public bool isPlay;

    public int life = 3;

    public int number = 42;

    public int coin;

    

    // Start is called before the first frame update
    void Start()
    {
        isPlay = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerLife(int life)
    {
        lifeTxt.text = life.ToString();

        if(life == 0)
        {
            Ending();
        }
    }

    public void Ending()
    {
        endingView.SetActive(true);

        isPlay = false;

        Time.timeScale = 0;


    }

    public void MonsterNum(int number)
    {
        num.text = number.ToString();

        if(number == 0)
        {
            Endding();
        }
    }

    public void Endding()
    {
        ending.SetActive(true);

        isPlay = false;

        Time.timeScale = 0;
    }


    public void Coins(int coin)
    {
        co.text = coin.ToString();

        
    }

    

    

}
