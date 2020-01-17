using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class ServerControl : MonoBehaviour
{
    static MonoBehaviour mb;
    static string serverUrl = "https://exbju52tj7.execute-api.ap-northeast-2.amazonaws.com/team-04/";
    

    public static void init(MonoBehaviour _mb)
    {
        mb = _mb;
    }

    public static void request(string _action, Action<Response> _callBack, object[] _param = null)
    {
        Response res = new Response(serverUrl + _action, _callBack, _param);
        
        string paramStr = null;
        if (_param != null)
        {
            Array.ForEach(_param, item => paramStr += item.ToString() + ",");
        }

        mb.StartCoroutine(requestCoroutine(res,res.uH));
    }

    static IEnumerator requestCoroutine(Response res, UploadHandler uh)
    {
        yield return null;

        Stopwatch stop = new Stopwatch();
        stop.Start();

        UnityWebRequest req = UnityWebRequest.Post(res.uri, res.form);
        req.uploadHandler = uh;
        yield return req.SendWebRequest();

        if (req.isHttpError || req.isNetworkError)
        {
            UnityEngine.Debug.Log("[Request " + req.responseCode+" Error] - " + res.uri + "  " + stop.ElapsedMilliseconds+"ms" );
            
            req.Dispose();
        }
        else
        {
            UnityEngine.Debug.Log("[Request Success] - " + res.uri + "  " + stop.ElapsedMilliseconds + "ms  " + req.responseCode);
            UnityEngine.Debug.Log(req.downloadHandler.text);
            GameManager.responseText = req.downloadHandler.text;
            if (String.IsNullOrEmpty(req.downloadHandler.text) == false)
            {
                JObject json = JObject.Parse(req.downloadHandler.text);
                res.json = (JObject)json["response"];
            }

            if (res.callBack != null)
            {
                res.callBack(res);
            }

            req.Dispose();
        }
    }


    public static object[] makeParam(params object[] param){
        return param;
    }

}
public class Response
{

    public Action<Response> callBack;
    public string uri;
    public WWWForm form;
    public JObject json;
    public UploadHandlerRaw uH;


    public Response(string _uri, Action<Response> _callBack, object[] _param)
    {
        this.callBack = _callBack;
        this.uri = _uri;


        // var bodyData = "{ 'test': 'value' }";
        // var postData = System.Text.Encoding.UTF8.GetBytes(bodyData);
        // form = new WWWForm();
        if (_param != null && _param.Length > 0)
        {
            // UnityEngine.Debug.Log(_param[0]);
            // form = new WWWForm();
            // form.AddField("schema", "team_four");

            byte[] body = Encoding.UTF8.GetBytes("{\"schema\" : \"team_four\"}");
            uH = new UploadHandlerRaw(body);
            uH.contentType= "application/json";
        

            // for (int i = 0; i < _param.Length * 0.5; i++)
            // {
            //     form.AddField(_param[i * 2].ToString(), _param[i * 2 + 1].ToString());
            // }
        }
    }
}
