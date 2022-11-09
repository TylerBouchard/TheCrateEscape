using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject instructionBox;
    public GameObject instructionText;
    private Text Directions;
    void Start()
    {
        //instructionText = GameObject.Find("InstructionText");
        //instructionBox = GameObject.Find("InstructionBox");
        Directions = instructionText.GetComponent<Text>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Input.GetKey(KeyCode.P))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
    public void DisplayInstructions(string text) {
        Directions.text = text;
        instructionText.SetActive(true);
        instructionBox.SetActive(true);
        print("shown");
    }
    public void HideInstructions() {
        instructionBox.SetActive(false);
        instructionText.SetActive(false);
        print("hide");
    }
}
