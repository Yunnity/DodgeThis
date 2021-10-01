using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text displayText;

    string preText = "Score: ";
    int score = 0;
    float elapsedTime = 0;
    public static bool running = true;

    // Start is called before the first frame update
    void Start()
    {
        displayText.text = preText + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(running)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > 1)
            {
                score += Champion.pointsPerSec;
                elapsedTime = 0;
                displayText.text = preText + score.ToString();
            }
        }
    }
}
