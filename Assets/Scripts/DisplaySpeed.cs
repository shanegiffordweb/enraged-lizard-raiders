using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


///Displays text on the UI based on public static variables
///Need to come back and set this to specific transform based on position relative to the Canvas.

public class DisplaySpeed : MonoBehaviour
{
    
    public static Text speedText;
    // Start is called before the first frame update
    void Start()
    {
    speedText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        speedText.text = "Horizontal Speed: " + LizardMovement.horizontalMove.ToString();
    }
}
