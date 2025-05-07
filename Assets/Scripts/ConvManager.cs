using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    using UnityEngine.SceneManagement;
using TMPro;
using System;

public class ConvManager : MonoBehaviour
{
    public GameObject scanObject;
    public GameObject convUi;
    public TextMeshProUGUI text;
    [SerializeField] ConvParsing convParsing;
    public bool isAction;
    int key, convNum;
    Dictionary<int, string[]> convDic;
    Dictionary<int, bool> isDoConv;

    private void Start()
    {
        convDic = convParsing.ConvDictionary;
        isDoConv = convParsing.isConvDone;
    }
    public void ConversationSetting(GameObject scanObj)
    {
        if (!isAction)  
        {
            convNum = 0;
            
            isAction = true;
            scanObject = scanObj;

            key = CalculateKey();
            text.text = convDic[key][convNum];
            convUi.SetActive(true);
        }
        else            
        {
            convNum++;
            try
            {                
                text.text = convDic[key][convNum];
            }
            catch (IndexOutOfRangeException)
            {
                EndConversation(key);
            }
        }
    }

    int CalculateKey()
    {
        int nameLength = scanObject.name.Length;
        int iNum = (scanObject.name[nameLength - 1]) - '0';
        int key2 = iNum * 100;
        while(isDoConv[key2])
        {
            key2++;
        }
        return key2;
    }

    void EndConversation(int key)
    {
        isAction = false;
        isDoConv[key] = true;
        convUi.SetActive(false);
        if(key / 100 == 1)
        {
            SceneManager.LoadSceneAsync(1);
        }
    }
}
