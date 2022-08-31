using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour
{
    public int totalMoney;
    public Text moneyText;

    // Start is called before the first frame update
    void Start()
    {
        totalMoney = 0;
        PlayerPrefs.SetInt("MoneyToAdd", 0);
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "£" + totalMoney;

        if (totalMoney < 0)
        {
            totalMoney = 0;
        }
    }

    public void AddMoney(int moneyToAdd)
    {
        totalMoney += moneyToAdd * GetComponent<Freefall>().correct;
    }

    //public void DisplayFinalTotal()
    //{
    //    moneyText.fontSize = 40;
    //    moneyText.transform.position = new Vector3(0, 0, 0);
    //}
}
