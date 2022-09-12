using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    private bool justStarted;

    public Text DialogText;
    public Text nameText;

    public GameObject dialogBox;
    public GameObject nameBox;

    public string[] dialogLines;
    public int currentLine;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        //DialogText.text = dialogLines[currentLine];
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogBox.activeInHierarchy)
        {
            if (Input.GetButtonUp("Fire2"))
            {
                if (!justStarted)
                {
                    currentLine++;

                    if (currentLine >= dialogLines.Length)
                    {
                        dialogBox.SetActive(false);
                        Player2Controller.instance.canMove = true;
                    }
                    else
                    {
                        checkIfName();

                        DialogText.text = dialogLines[currentLine];
                    }
                }
                else
                {
                    justStarted = false;
                }
                
            }
        }
    }
    public void showDialog(string[] newLines)
    {
        dialogLines = newLines;

        currentLine = 0;

        checkIfName();

        DialogText.text = dialogLines[currentLine];
        dialogBox.SetActive(true);

        justStarted = true;

        Player2Controller.instance.canMove = false;
    }

    public void checkIfName()
    {
        if (dialogLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogLines[currentLine].Replace("n-","");
            currentLine++;
        }
    }
}
