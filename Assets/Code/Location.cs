using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Location
{
    public bool isReal = true;
    public int current = 0;
    public Sprite imageRight;
    public string descriptionRight;
    public Sprite imageFront;
    public string descriptionFront;
    public Sprite imageLeft;
    public string descriptionLeft;

    public void Left()
    {
        if (current > -1)
        {
            current -= 1;
        }
        else
        {
            current = 1;
        }
    }

    public void Right()
    {
        if (current < 1)
        {
            current += 1;
        }
        else
        {
            current = -1;
        }
    }

    public Sprite GetImage()
    {
        if (current == -1)
        {
            return imageLeft;
        }
        if (current == 0)
        {
            return imageFront;
        }
        if (current == 1)
        {
            return imageRight;
        }

        return null;
    }

    public string GetDescription()
    {
        if (current == -1)
        {
            return descriptionLeft;
        }
        if (current == 0)
        {
            return descriptionFront;
        }
        if (current == 1)
        {
            return descriptionRight;
        }

        return string.Empty;
    }

    public static Location Empty()
    {
        Location l = new Location();
        l.isReal = false;
        return l;
    }
}
