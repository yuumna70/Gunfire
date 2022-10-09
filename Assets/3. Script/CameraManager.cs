using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // 플레이어
    public Transform player;

    // 카메라 속도
    public float cameraSpeed;

    // 카메라 제한
    public Vector2 areaCenter, areaSize;

    // 카메라 세로, 가로
    float cameraSizeY, cameraSizeX;

    //public GameObject dontdestory;

    

    /*private void Awake()
    {
        DontDestroyOnLoad(dontdestory);

        GameObject[] camera = GameObject.FindGameObjectsWithTag("MainCamera");

        if (camera.Length >= 2)
        {
            Destroy(camera[1]);
        }


    }*/

    // Start is called before the first frame update
    void Start()
    {
        
        cameraSizeY = Camera.main.orthographicSize;
        cameraSizeX = cameraSizeY * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, target, cameraSpeed * Time.deltaTime);

        float distX = areaSize.x / 2 - cameraSizeX;
        float distY = areaSize.y / 2 - cameraSizeY;

        float clampX = Mathf.Clamp(transform.position.x, areaCenter.x - distX, areaCenter.x + distX);
        float clampY = Mathf.Clamp(transform.position.y, areaCenter.y - distY, areaCenter.y + distY);

        transform.position = new Vector3(clampX, clampY, -10);


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(areaCenter, areaSize);
    }
}
