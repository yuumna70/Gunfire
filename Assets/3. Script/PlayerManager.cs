using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    

    // 캐릭터 이동 속도
    public float maxSpeed;

    // 목숨
    //public int life = 3;

    Rigidbody2D rig;

    // 캐릭터 이동
    float h, v;

    //int number = 42;

    //public GameObject camera;

    public GameManager gm;

    SpriteRenderer sr;

    Animator anim;

    AudioSource audio;

    bool isWalk = false;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        //camera = GetComponent<GameObject>();

        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();

        audio = GetComponent<AudioSource>();

        //gm = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gm.isPlay == false)
        {
            return;
        }

        // 좌우 이동
        h = Input.GetAxisRaw("Horizontal");
        
        

        if (Input.GetButtonUp("Horizontal"))
        {
            // 속도를 0으로 고정
            rig.velocity = new Vector2(0, rig.velocity.y);
            
        }

        v = Input.GetAxisRaw("Vertical");
        

        if (Input.GetButtonUp("Vertical"))
        {
            // 속도를 0으로 고정
            rig.velocity = new Vector2(rig.velocity.x, 0);
            
        }

        if(rig.velocity.x != 0 || rig.velocity.y != 0)
        {
            if (!audio.isPlaying)
                audio.Play();
        }
        else
            audio.Stop();

        anim.SetInteger("speed",(int)rig.velocity.x);
        //anim.SetInteger("speed",(int)rig.velocity.y);

        if(h > 0)
        {
            sr.flipX = false;
        }
        else if(h < 0)
        {
            sr.flipX = true;
        }

        /*if (v > 0)
        {
            sr.flipY = true;
        }
        else if (v < 0)
        {
            sr.flipY = false;
        }*/

    }

    private void FixedUpdate()
    {
        // 이동 힘 가하기
        rig.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        rig.AddForce(Vector2.up * v, ForceMode2D.Impulse);

        float xClamp = Mathf.Clamp(rig.velocity.x, -maxSpeed, maxSpeed);
        float yClamp = Mathf.Clamp(rig.velocity.y, -maxSpeed, maxSpeed);

        rig.velocity = new Vector2(xClamp, yClamp);
        
        

    }

    // 문으로 스테이지 이동
    private void OnCollisionEnter2D(Collision2D collision)
    {

        switch (collision.gameObject.tag)
        {
            case "HomeDoor":
            case "door1-1":
            case "door2-1":
            case "door3-1":
                //SceneManager.LoadScene("2. MainStage");
                transform.position = new Vector2(2, 2);
                break;

            case "door1":
                transform.position = new Vector2(1.6f, 22);
                break;
            case "door1-3":
                transform.position = new Vector2(1.6f, 36);
                //SceneManager.LoadScene("3. PlayStage1_1");
                
                break;

            case "door1-2":
                transform.position = new Vector2(1.6f, 49);
                break;
            case "door1-5":
                transform.position = new Vector2(1.6f, 61);
                
                break;

            case "door1-4":
                transform.position = new Vector2(1.6f, 75);
                
                break;

            case "door2":
                transform.position = new Vector2(-30, 2.5f);
                break;
            case "door2-3":
                transform.position = new Vector2(-40, 9);
                break;

            case "door2-2":
                transform.position = new Vector2(-41, 21.5f);
                break;
            case "door2-5":
                transform.position = new Vector2(-41.5f, 36);
                //SceneManager.LoadScene("4. PlayStage2-2");
                
                break;

            case "door2-4":
                transform.position = new Vector2(-42, 49);
                //SceneManager.LoadScene("4. BossStage");
                
                break;

            case "door3":
                transform.position = new Vector2(32, 2.6f);
                break;
            case "door3-3":
                transform.position = new Vector2(55, 2.7f);
                //SceneManager.LoadScene("5. PlayStage3-1");
                
                break;

            case "door3-2":
                transform.position = new Vector2(32, 30);
                break;
            case "door3-5":
                transform.position = new Vector2(55, 30);
                //SceneManager.LoadScene("5. PlayStage3-2");
                
                break;

            case "door3-4":
                transform.position = new Vector2(32, 58);
                break;
            case "door3-7":
                transform.position = new Vector2(44, 64);
                //SceneManager.LoadScene("5. PlayStage3-3");
                
                break;

            case "door3-6":
                transform.position = new Vector2(44, 80);
                //SceneManager.LoadScene("5. BossStage");
                
                break;

        }

        switch (collision.gameObject.tag)
        {
            case "enemy":
                gm.life--;
                gm.life = Mathf.Clamp(gm.life, 0, 3);
                gm.PlayerLife(gm.life);
                break;
        }


    }

    
   
}
