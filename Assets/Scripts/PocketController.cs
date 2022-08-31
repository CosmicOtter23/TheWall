using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketController : MonoBehaviour
{
    public int pocketValue;
    private int totalMoney, moneyToAdd;

    private GameObject gameController;

    private List<GameObject> ballsInHole = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController");

        if (gameController == null)
        {
            Debug.Log("Game controller not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider ball)
    {
        //ball.GetComponentInParent<BoxCollider>().enabled = false;

        if(!ballsInHole.Contains(ball.gameObject))
        {
            ballsInHole.Add(ball.gameObject);
            Debug.Log("Ball in pocket: " + pocketValue);
            moneyToAdd = pocketValue;
            gameController.GetComponent<MoneyController>().AddMoney(moneyToAdd);
            gameController.GetComponent<Freefall>().FreezeButtons();
        }
    }
}
