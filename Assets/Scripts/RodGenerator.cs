using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodGenerator : MonoBehaviour
{
    public GameObject rod;

    public Transform startPoint;
    
    public int horRodNo, verRodNo, topRows;

    private Vector3 rodPosition;

    private bool indent = false;
    private float indentAmount = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < verRodNo; i++)
        {
            for (int j = 0; j < horRodNo; j++)
            {
                //Debug.Log("Horizontal: " + j);
                //Debug.Log("Vertical: " + i);

                if (indent)
                {
                    indentAmount = 0.5f;
                    horRodNo = 14;
                }
                else
                {
                    indentAmount = 0f;
                    horRodNo = 15;
                }

                rodPosition = new Vector3(startPoint.position.x + j + indentAmount, startPoint.position.y + i, startPoint.position.z);
                Instantiate(rod, rodPosition, Quaternion.Euler(new Vector3(90, 0, 0)));
            }
            indent = !indent;
        }
        for (int n = 0; n < horRodNo - 1; n++)
        {
            rodPosition = new Vector3(startPoint.position.x + 1 + n, startPoint.position.y + verRodNo, startPoint.position.z);
            Instantiate(rod, rodPosition, Quaternion.Euler(new Vector3(90, 0, 0)));
        }
        for (int n = 0; n < horRodNo - 2; n++)
        {
            rodPosition = new Vector3(startPoint.position.x + 1.5f + n, startPoint.position.y + verRodNo + 1, startPoint.position.z);
            Instantiate(rod, rodPosition, Quaternion.Euler(new Vector3(90, 0, 0)));
        }
        for (int n = 0; n < horRodNo - 5; n++)
        {
            rodPosition = new Vector3(startPoint.position.x + 3 + n, startPoint.position.y + verRodNo + 2, startPoint.position.z);
            Instantiate(rod, rodPosition, Quaternion.Euler(new Vector3(90, 0, 0)));
        }
        for (int n = 0; n < horRodNo - 6; n++)
        {
            rodPosition = new Vector3(startPoint.position.x + 3.5f + n, startPoint.position.y + verRodNo + 3, startPoint.position.z);
            Instantiate(rod, rodPosition, Quaternion.Euler(new Vector3(90, 0, 0)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
