using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocator : MonoBehaviour
{
    public Dictionary<string, bool> PlayerLocations = new Dictionary<string, bool>();

    private void Start()
    {
        PlayerLocations.Add("Room1Enter", false);
        PlayerLocations.Add("Room1Exit", false);
        PlayerLocations.Add("Room2Enter", false);
        PlayerLocations.Add("Room2Exit", false);
        PlayerLocations.Add("Room3Enter", false);
        PlayerLocations.Add("Room3Exit", false);
        PlayerLocations.Add("Room4Enter", false);
        PlayerLocations.Add("Room4Exit", false);
        PlayerLocations.Add("Room5Enter", false);
        PlayerLocations.Add("Room5Exit", false);
        PlayerLocations.Add("Room6Enter", false);
        PlayerLocations.Add("Room6Exit", false);
        PlayerLocations.Add("LiftArea1Enter", false);
        PlayerLocations.Add("LiftArea1Exit", false);
        PlayerLocations.Add("LiftArea2Enter", false);
        PlayerLocations.Add("LiftArea2Exit", false);
        PlayerLocations.Add("HallwayEnter", false);
        PlayerLocations.Add("HallwayExit", false);

    }


}
