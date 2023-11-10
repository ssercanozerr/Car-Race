using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;
    public CarBehaviour carBehaviour;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = carBehaviour.point.ToString();
    }
}
