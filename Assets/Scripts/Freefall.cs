using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Freefall : MonoBehaviour
{
    public GameObject newQuestion;

    public Text questionText, correctAnswer, wrongAnswer;
    //private GameObject correctAnswer, wrongAnswer;
    public Button correctButton, wrongButton;

    public List<string> questions = new List<string>();
    public List<string> correctAnswers = new List<string>();
    public List<string> wrongAnswers = new List<string>();

    private bool ballinHole;
    public int correct;

    public float timeToNextQ;
    private float countdown;
    private bool waiting;

    GameObject[] ballList = new GameObject[3];

    public Material redBall, greenBall;

    public int questionsLeft;

    public Canvas canvas;

    private bool ended;

    // Start is called before the first frame update
    void Start()
    {
        waiting = false;
        canvas.enabled = true;

        questionsLeft -= 1;
        Question();
        countdown = timeToNextQ;
        ended = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (waiting)
        {
            countdown -= Time.deltaTime;
        }

        if (countdown <= 0)
        {
            if (questionsLeft > 0)
            {
                countdown = timeToNextQ;
                waiting = false;
                foreach (GameObject n in ballList)
                {
                    Destroy(n);
                }

                questionsLeft -= 1;
                Question();
            }
            else
            {
                countdown = timeToNextQ;
                waiting = false;
                EndFreefall();
            }
        }
    }

    public void Question()
    {
        correctButton.interactable = true;
        wrongButton.interactable = true;
        correct = 0;

        GetComponent<BallDropper>().Drop(0);
        GetComponent<BallDropper>().Drop(3);
        GetComponent<BallDropper>().Drop(6);

        newQuestion.SetActive(true);
        int random = Random.Range(0, questions.Count);
        if (random % 2 == 0)
        {
            correctButton.transform.localPosition = new Vector3(-52, -64, 0);
            wrongButton.transform.localPosition = new Vector3(52, -64, 0);
        }
        if (random % 2 == 1)
        {
            correctButton.transform.localPosition = new Vector3(52, -64, 0);
            wrongButton.transform.localPosition = new Vector3(-52, -64, 0);
        }
        questionText.text = questions[random];
        correctAnswer.text = correctAnswers[random];
        wrongAnswer.text = wrongAnswers[random];
        questions.RemoveAt(random);
        correctAnswers.RemoveAt(random);
        wrongAnswers.RemoveAt(random);
    }

    public void CorrectAnswer()
    {
        if (!ended)
        {
            Debug.Log("Correct!");
            correct = 1;
        }
        else
        {
            SceneManager.LoadScene("Wall");
        }
    }

    public void WrongAnswer()
    {
        if (!ended)
        {
            Debug.Log("Wrong!");
            correct = -1;
        }
        else
        {
            Application.Quit();
        }
    }

    public void FreezeButtons()
    {
        correctButton.interactable = false;
        wrongButton.interactable = false;
        countdown = timeToNextQ;
        waiting = true;
        ballList = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject n in ballList)
        {
            if (correct > 0)
            {
                n.GetComponent<Light>().color = Color.green;
                n.GetComponent<MeshRenderer>().materials[0] = greenBall;
            }
            if (correct < 0)
            {
                n.GetComponent<Light>().color = Color.red;
                n.GetComponent<MeshRenderer>().materials[0] = redBall;
            }
        }
    }

    public void EndFreefall()
    {
        //Destroy(correctButton.gameObject);
        //Destroy(wrongButton.gameObject);
        correctButton.GetComponentInChildren<Text>().text = "Play Again";
        wrongButton.GetComponentInChildren<Text>().text = "Quit";
        correctButton.interactable = true;
        wrongButton.interactable = true;
        ended = true;

        questionText.text = "£" + GetComponent<MoneyController>().totalMoney;
    }

    //public void CorrectClick()
    //{
    //    Debug.Log("Correct click");
    //    correct = 1;
    //}
    //public void WrongClick()
    //{
    //    Debug.Log("Wrong click");
    //    correct = -1;
    //}
}
