using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Linq;
public class ConvParsing : MonoBehaviour
{
    public struct Conv
    {
        public int Id { get; private set; }
        public string[] Text { get; private set; }

        public bool[] IsMe { get; private set; }
        public bool IsConvDone { get; private set; }
        public Conv(int id, string[] text, bool[] isMe, bool isConvDone)
        {
            Id = id; Text = text; IsMe = isMe; IsConvDone = isConvDone;
        }
    }
    public Dictionary<int, string[]> ConvDictionary = new Dictionary<int, string[]>();
    public Dictionary<int, bool[]> isConvMe = new Dictionary<int, bool[]>();
    public Dictionary<int, bool> isConvDone = new Dictionary<int, bool>();

    void Start()
    {
        string jsonString = Resources.Load("Dialogue").ToString();
        Conv[] json = JsonConvert.DeserializeObject<Conv[]>(jsonString);

        for (int i = 0; i < json.Length; i++)
        {
            ConvDictionary.Add(json[i].Id, json[i].Text);
            isConvMe.Add(json[i].Id, json[i].IsMe);
            isConvDone.Add(json[i].Id, json[i].IsConvDone);

        }
    }
}
