using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    Rigidbody2D rig;

    Animator anim;

    SpriteRenderer sr;

    int dir;

    bool isChange;

    bool isDead;

    //int number = 42;

    //int number;

    public GameManager gm;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        //number = gm.GetComponent<int>();

        RandomDir();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("speed", dir);

        if(dir > 0)
        {
            sr.flipX = true;
        }
        else if(dir < 0)
        {
            sr.flipX=false;
        }

        if(dir != 0)
        {
            Debug.DrawRay(transform.position + new Vector3(dir * 0.6f, 0.5f, 0), Vector2.down * 1);
            //Debug.DrawRay(transform.position + new Vector3( 0, dir * 0.6f, 0), Vector2.down * 1);
            
            
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(dir * 0.6f, 0.5f, 0), Vector2.down * 1);
            //RaycastHit2D hit1 = Physics2D.Raycast(transform.position + new Vector3( 0, dir * 0.6f, 0), Vector2.down * 1);
            
            

            if (hit && !isChange)
            {
                dir = -dir;
                

                CancelInvoke("RandomDir");
                isChange = true;
                Invoke("RandomDir", Random.Range(2f, 5f));

            }
            else if (!hit)
            {
                isChange = false;
            }
        }

        


    }

    float t;
    void FixedUpdate()
    {
        if (isDead)
        {
            t += Time.deltaTime;

            

            
            sr.color = Vector4.Lerp(Color.white, new Vector4(1, 1, 1, 0), t / 2);

            if (sr.color.a == 0)
            {
                
                Destroy(gameObject);

                //gm.MonsterNum(number -= 1);

                gm.number--;
                gm.number = Mathf.Clamp(gm.number, 0, 42);
                gm.MonsterNum(gm.number);

                gm.coin++;

                gm.Coins(gm.coin);


            }

            // ÇÔ¼ö Å»Ãâ
            return;
        }

        rig.velocity = new Vector2(dir, rig.velocity.y);
    }

    void Dead()
    {

        anim.SetTrigger("dead");
        
        isDead = true;

        GetComponent<BoxCollider2D>().enabled = false;

        
        rig.simulated = false;

        
        CancelInvoke("RandomDir");
    }

    void RandomDir()
    {
       
        dir = Random.Range(-1, 3);

        Invoke("RandomDir", Random.Range(2f, 5f));
    }

    

}
