using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayTextCorrectly : MonoBehaviour
{
    public WinConditionMonitor winConditionMonitor;
    public TextMeshProUGUI textM;
    public string text = "FARAGE INVASION STOPPED! CAN YOU DO IT AGAIN?";
    // Start is called before the first frame update
    void Start()
    {
        //textM = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textM.text = text + "\n\n" + "Restarting in " + ((int)winConditionMonitor.RestartingIn) + "...";
    }
}
