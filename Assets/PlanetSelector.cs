using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class PlanetSelector : MonoBehaviour
{
    public GameObject[] planetList;
    public GameObject buttonObject;
    public GameObject targetObject;
    private int currentPlanet;
    private float topSpeed = 30;
    
    
    void Start()
    {
        resetCycle();
    }

    public void cyclePlanet()
    {
      
        if (currentPlanet < planetList.Length - 1)
        {
           currentPlanet++;
        }
        else
        {
            resetCycle();       
        } 
        planetName();
        getPlanetInfo();
    }

    private void planetName()
    {
        buttonObject.GetComponent<ButtonConfigHelper>().MainLabelText = planetList[currentPlanet].name;
    }


    private void resetCycle()
    {
        currentPlanet = 0;
        getPlanetInfo();
    }

    public void getPlanetInfo() 
    {
        string currentPlanetName = planetList[currentPlanet].name;
        targetObject = GameObject.Find(currentPlanetName);
    }

    public void increasePlanetSpeed() 
    {      
        if (targetObject.GetComponent<PlanetMover>().orbitSpeed >= topSpeed)
        {
            return;
        }
         targetObject.GetComponent<PlanetMover>().orbitSpeed++;
    }

    public void decreasePlanetSpeed()
    {
       if (targetObject.GetComponent<PlanetMover>().orbitSpeed <= 0)
       {
           return;
       }
        targetObject.GetComponent<PlanetMover>().orbitSpeed--;
    }
}
