using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CutScenes : MonoBehaviour
{
    public Image fadeImage;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public float playSpeed = .01f;
    public float targetAlpha;
    public float targetText;
    public TextMeshProUGUI currentText;
    public float cooldown = 2f;
    public float timer;
    public bool play1bool;
    public int fadeIn;
    public int fadeInImage;
    // Start is called before the first frame update
    void Start()
    {
        play1bool = false;
        targetAlpha = 0;
        Color zm = text1.color;
        zm.a = 0.0f;
        text1.color = zm;
        text2.color = zm;
        text3.color = zm;
        currentText = text1;
        Color zf = fadeImage.color;
        zf.a = 1;
        fadeImage.color = zf;
        timer = 0;
        fadeIn = -1;
        fadeInImage = -1;
    }

    // Update is called once per frame
    void Update()
    {  
        Color curColor = fadeImage.color;
        if ((fadeIn == 1 && curColor.a < targetAlpha)  || (fadeIn == -1 && curColor.a > targetAlpha)) 
        {
            curColor.a = curColor.a + fadeIn * playSpeed * Time.deltaTime;
            fadeImage.color = curColor;
        }

        Color curColor2 = currentText.color;
        if ((fadeInImage == 1 && curColor2.a < targetText) || (fadeInImage == -1 && curColor2.a > targetText))
        {
            curColor2.a = curColor2.a + fadeInImage * playSpeed * Time.deltaTime;
            currentText.color = curColor2;
        }
        if (play1bool)
        {
            play1();
            play1bool = false;
        }
        if (curColor.a >= 1)
        {
            timer += Time.deltaTime;
        }
        if (timer > cooldown)
        {
            targetAlpha = 0;
            targetText = 0;
            fadeIn = -1;
            fadeInImage = -1;
        }
        Debug.Log(curColor2.a);
    }

    public void play1()
    {
        currentText = text1;
        targetAlpha = 1;
        targetText = 1;
        fadeIn = 1;
        fadeInImage = 1;
    }

    public void play2()
    {
        currentText = text2;
        targetAlpha = 1;
        targetText = 1;
        fadeIn = 1;
        fadeInImage = 1;
    }

    public void play3()
    {
        currentText = text3;
        targetAlpha = 1;
        targetText = 1;
        fadeIn = 1;
        fadeInImage = 1;
    }
}
