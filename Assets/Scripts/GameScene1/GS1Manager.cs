using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GS1Manager : MonoBehaviour
{
    private static GS1Manager instance;
    [SerializeField] GS1Player player;
    [SerializeField] GameObject backGroundPrefeb;
    [SerializeField] GameObject obstaclePrefeb;
    [SerializeField] Transform grid;
    [SerializeField] Transform obstacles;
    [SerializeField] List<GameObject> backGroundPrefebList = new List<GameObject>();
    [SerializeField] List<GameObject> obstaclePrefebList = new List<GameObject>();
    [SerializeField] TextMeshProUGUI text;
    Vector3 LastBGPosition = new Vector3(0, 0, 0);
    Vector3 LastObsPosition = new Vector3(2.5f, 0, 0);
    int BGNum = 0;
    int ObsNum = 0;
    Quaternion quaternion = Quaternion.identity;

    private void Awake()
    {
        if(null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        text.text = player.score.ToString();
    }
    public static GS1Manager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    void Start()
    {
        SettingPrefebs();
    }

    void SettingPrefebs()
    {
        for (int i = 0; i < 5; i++)
        {
            LastObsPosition.y = UnityEngine.Random.Range(-1.2f, 1.2f);
            backGroundPrefebList.Add(Instantiate(backGroundPrefeb, LastBGPosition, quaternion, grid));
            obstaclePrefebList.Add(Instantiate(obstaclePrefeb, LastObsPosition, quaternion, obstacles));
            LastBGPosition.x += 7;
            LastObsPosition.x += 8;
        }
    }

    public void SetBackGround()
    {
        int LastBGIndex = BGNum % 5;
        backGroundPrefebList[LastBGIndex].transform.position = LastBGPosition;
        backGroundPrefebList[LastBGIndex].SetActive(true);
        BGNum++;
        LastBGPosition.x += 7;
    }

    public void SetObstacle()
    {
        int LastObsIndex = ObsNum % 5;
        LastObsPosition.y = UnityEngine.Random.Range(-1.2f, 1.2f);
        obstaclePrefebList[LastObsIndex].transform.position = LastObsPosition;
        obstaclePrefebList[LastObsIndex].SetActive(true);
        ObsNum++;
        LastObsPosition.x += 8;
    }

    void ShowResult()
    {
        if (!player.isDie) return;
    }


}
