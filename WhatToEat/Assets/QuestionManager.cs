using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QuestionManager : MonoBehaviour
{
    Text[] choiceText = new Text[5];
    int[] answer = new int[3];
    public Text QuestionText;
    public int state;

    string[] choice = new string[15];
    string[] question = new string[3];

    void Start()
    {
        choiceText[0] = GameObject.Find("Button").GetComponentInChildren<Text>();
        choiceText[1] = GameObject.Find("Button (1)").GetComponentInChildren<Text>();
        choiceText[2] = GameObject.Find("Button (2)").GetComponentInChildren<Text>();
        choiceText[3] = GameObject.Find("Button (3)").GetComponentInChildren<Text>();
        choiceText[4] = GameObject.Find("Button (4)").GetComponentInChildren<Text>();

        question[0] = "당신의 성별은?";
        choice[0] = "남자";
        choice[1] = "여자";
        question[1] = "당신의 나이대는?";
        choice[5] = "10대";
        choice[6] = "20대";
        choice[7] = "30대";
        choice[8] = "40대";
        choice[9] = "50대";
        question[2] = "선호하는 카테고리는?";
        choice[10] = "한식";
        choice[11] = "중식";
        choice[12] = "일식";
        choice[13] = "양식";
        choice[14] = "분식";

        state = 1;
        UpdateQuestion(1);
        
    }



    public void UpdateQuestion(int state)
    {
        for (int i = 0; i < 5; i++)
        {
            choiceText[i].text = choice[(state-1) * 5 + i];
            QuestionText.text = question[state-1];
        }
    }

    public void OnResponseQuestion(int _answer)
    {
        state ++;
        answer[state-2] = _answer;
        if (state <= 3)
        {
            UpdateQuestion(state);
        }
        else
        {
            GameManager.OnFinishedQuestion();
        }
        
        

        for (int i = 0; i < 3; i++)
        {
            Debug.Log("answer" +"["+i+"] : " + answer[i])   ;
        }
    }


}


