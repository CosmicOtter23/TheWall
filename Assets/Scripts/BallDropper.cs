using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDropper : MonoBehaviour
{
    public GameObject ball;
    private float offset;

    public Transform[] numbers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Drop(int dropNo)
    {
        do
        {
            offset = Random.Range(-0.1f, 0.1f);
        }
        while (-0.01f < offset && offset < 0.01f);

        Instantiate(ball, new Vector3(numbers[dropNo].position.x + offset, numbers[dropNo].position.y, numbers[dropNo].position.z), Quaternion.identity);
    }
}
