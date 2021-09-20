using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TextMoney : MonoBehaviour
{
    public static int Coin;
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
    }
    private string money;
    //Update is called once per frame
    void Update()
    {
        money = Coin.ToString() + "/7";
        //Debug.Log(Coin);
        text.text = money;
    }
}
