using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerGun : MonoBehaviour
{
    public float gunPower;

    SpriteRenderer sr;

    int dir;

    public int bulletCount = 10;

    public GameObject[] bulletPool;

    AudioSource audio;

    //public AudioClip[] clips;

    //AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        //audio = transform.GetChild(0).GetComponent<AudioSource>();

        bulletPool = new GameObject[bulletCount];

        audio = transform.GetChild(0).GetComponent<AudioSource>();
        
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bullet = Instantiate(Resources.Load("Bullet")) as GameObject;
            bulletPool[i] = bullet;
            bullet.SetActive(false);
        }
    }

        // Update is called once per frame
        void Update()
        {

        if (Input.GetButtonDown("Fire1") && !EventSystem.current.IsPointerOverGameObject() && Time.timeScale != 0)
        {
            
            audio.Play();

            if (!sr.flipX)
            {
                dir = 1;
            }
            else
            {
                dir = -1;
            }


            for (int i = 0; i < bulletCount; i++)
            {
                GameObject bullet = bulletPool[i];

                if (!bullet.activeSelf)
                {

                    bullet.transform.position = transform.position + new Vector3(dir * 0.6f, -0.5f, 0);

                    bullet.SetActive(true);

                    bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * dir * gunPower, ForceMode2D.Impulse);

                    StartCoroutine(ResetBuulet(bullet));

                    break;
                }


            }


        }






    }


    



    IEnumerator ResetBuulet(GameObject bullet)
    {

        // 2초 쉬고
        yield return new WaitForSeconds(1);

        // 총알 비활성화
        bullet.SetActive(false);
    }
}
