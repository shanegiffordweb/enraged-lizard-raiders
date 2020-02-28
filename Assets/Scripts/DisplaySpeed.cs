using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;



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
