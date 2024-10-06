using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Exoplanet
{
    public string name = "";
    public Sprite map;
    public Location currentLocation = null;
    public List<Location> locations;

    public void Reset()
    {
        currentLocation = Location.Empty();
    }

    public void ExitLocation()
    {
        currentLocation = Location.Empty();
    }

    public void GoLocation(int index)
    {
        if (index < locations.Count)
        {
            currentLocation = locations[index];
        }
    }

    public Sprite GetCurrentImage()
    {
        if (InLocation())
        {
            return currentLocation.GetImage();
        }

        return map;
    }

    public bool InLocation()
    {
        if (currentLocation == null) { return false; }
        return currentLocation.isReal;
    }
}
