using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json.Linq;
using UnityEngine.Networking;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static int[] answers = new int[5];
    public static GameObject[] Panel;
    public static GameObject ResultPanel;
    public static Text ResultText;
    public static Text jsonresultText;

    public static string responseText;

    void Start(){
        ResultPanel = GameObject.Find("Canvas/BG/ResultPanel");
        ResultText = ResultPanel.transform.Find("ResultText").GetComponent<Text>()    ;    
        jsonresultText = ResultPanel.transform.Find("resultJsonText").GetComponent<Text>()    ;    
        ResultPanel.SetActive(false);
        ServerControl.init(this);
    }
    
    public static void OnFinishedQuestion()
    {
        ResultPanel.SetActive(true);
        ServerControl.request("dblookup", OnResponse, ServerControl.makeParam("schema", "team_four"));
    }

    static void OnResponse(Response res)
    {
        // JObject json = (JObject)(res.json)["user"];
        Debug.Log(res);

        JObject json = JObject.Parse(responseText);
        Debug.Log(json.ToString());
        JArray j = (JArray)json["results"];
        Debug.Log(j.ToString());
        int result= 0;
        foreach (var item in j)
        {
            result = (int)item["result"];
            Debug.Log(result.ToString());
        }

        
        ResultText.text = "결과 : " + result;
        jsonresultText.text = responseText;
            

        
        
    }
}
