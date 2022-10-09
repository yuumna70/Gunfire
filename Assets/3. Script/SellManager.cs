using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SellManager : MonoBehaviour
{
    public GameObject sellView;

    //public GameObject player;

    public GameManager gm;

    //public Transform bullet;

    //GameObject bullet;

    AudioSource audio;

    void Start()
    {
        Time.timeScale = 1;

        //bullet = GameObject.FindGameObjectsWithTag("bullet");

        //bullet = Instantiate(FindObjectOfType("bullet(clone)"));
        
        audio = transform.GetChild(0).GetComponent<AudioSource>();
        
    }

    public void ClickSell()
    {
        sellView.SetActive(true);

        Time.timeScale = 0;
    }

    public void ClickPlay()
    {
        sellView.SetActive(false);

        Time.timeScale = 1;
    }

    // ÃÑ
    /*public void ClickBuy1()
    {
        if (gm.coin >= 5)
        {


            bullet.transform.scale += new Vector3(10, 10, 10);
            //print(bullet.transform.localScale);
            //bullet.transform.localScale += new Vector3(1, 1,1);

            gm.coin -= 5;

            gm.Coins(gm.coin);
        }
    }*/

    // ÇÏÆ®
    public void ClickBuy2()
    {
        if(gm.coin >= 5)
        {

            if(gm.life < 3)
            {
                audio.Play();

                gm.life += 1;
                gm.PlayerLife(gm.life);
                gm.coin -= 5;

                gm.Coins(gm.coin);
            }
            else
            {
                gm.PlayerLife(gm.life);
                gm.Coins(gm.coin);
            }
            
            gm.life = Mathf.Clamp(gm.life, 0, 3);
            

            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
