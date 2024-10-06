using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolScript : MonoBehaviour
{
    public string toolType;

    public void OnBotton()
    {
        // Play Minigame
        // After the minigame, Register:

        string toRegister = string.Empty;

        if (toolType == "temperature")
        {
            toRegister = $"Equilibrium Temperature is 300 to 400 Kelvin";
        }

        if (toolType == "atmosphere")
        {
            toRegister = $"It has a potentially dense atmosphere.";
        }

        if (toolType == "size")
        {
            toRegister = "It's radius is around 103% of earth's, and its mass is 90% of earth's";
        }

        if (toRegister != string.Empty)
        {
            GameManager.i.LaunchMinigame(toRegister);
        }
    }

    public sealed class TTSmessage
    {

    }

}
