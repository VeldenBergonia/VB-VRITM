using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreManager : MonoBehaviour
{
    public static int points = 0;
    public static int playerHealthScore = 3;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverText;

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(points);
    }
}
