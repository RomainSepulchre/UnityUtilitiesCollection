using System;
using UnityEngine;

/*********************************************************
* 
*  2014-2019 Alan Mattano
*  SOARING STARS Lab
*  Information  Note
*      
*      .Let you place inspector info text boxes notes.
*      
*          . Will handle info text note in the inspector
* 
*  See https://github.com/ALanMAttano/UnityInspectorInfoTextNote
*  Modified by Romain Sepulchre
* *******************************************************/

[AddComponentMenu("Miscellaneous/Inspector Note")]
public class InspectorNote : MonoBehaviour
{
    public bool isReady = true;

    public string TextInfo = "Type your message here and press enter to send";

    public string spaceMessage = ""; // use in case of space or message


    private void Awake()
    {
        this.enabled = false; // Disable this component when game start
    }

    public void SwitchToggle()
    {
        isReady = !isReady;
    }
}
