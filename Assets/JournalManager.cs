using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JournalManager : MonoBehaviour
{

    [SerializeField] GameObject Journal;
    [SerializeField] GameObject tableOfContents;
    [SerializeField] GameObject diner;
    [SerializeField] GameObject asylum;
    [SerializeField] GameObject city;
    [SerializeField] GameObject office;
    [SerializeField] GameObject garage;
    [SerializeField] GameObject home;
    [SerializeField] GameObject doctor;

    //Scenes table of contents
    [SerializeField] List<string> sceneNames;
    [SerializeField] List<GameObject> sceneButtons;
    private List<bool> scenesDiscovered = new List<bool>();

    //Diner
    [SerializeField] List<GameObject> dinerClues;
    private List<bool> dinerCluesDiscovered = new List<bool>();

    //Asylum
    [SerializeField] List<GameObject> asylumClues;
    private List<bool> asylumCluesDiscovered = new List<bool>();

    //City
    [SerializeField] List<GameObject> cityClues;
    private List<bool> cityCluesDiscovered = new List<bool>();

    //Office
    [SerializeField] List<GameObject> officeClues;
    private List<bool> officeCluesDiscovered = new List<bool>();

    //Garage
    [SerializeField] List<GameObject> garageClues;
    private List<bool> garageCluesDiscovered = new List<bool>();

    //Home
    [SerializeField] List<GameObject> homeClues;
    private List<bool> homeCluesDiscovered = new List<bool>();

    //Doctors
    [SerializeField] List<GameObject> doctorClues;
    private List<bool> doctorCluesDiscovered = new List<bool>();




    private Dictionary<string, int> locationIndex = new Dictionary<string, int>() { { "diner", 0 }, { "asylum", 1 }, { "city", 2 }, { "office", 3 }, 
        { "garage", 4 }, {"home", 5 }, {"doctor", 6 } };
    private List<(List<GameObject>, List<bool>)> clueList;

    void Start()
    {
        clueList = new List<(List<GameObject>, List<bool>)>() { (dinerClues, dinerCluesDiscovered), (asylumClues, asylumCluesDiscovered), 
            (cityClues, cityCluesDiscovered), (officeClues, officeCluesDiscovered), (garageClues, garageCluesDiscovered), (homeClues, homeCluesDiscovered),
            (doctorClues, doctorCluesDiscovered)};
        genList();
    }


    private void genList()
    {
        for (int i = 0; i < sceneNames.Count; i++)
        {
            scenesDiscovered.Add(false);
        }

        for (int i = 0; i < dinerClues.Count; i++)
        {
            dinerCluesDiscovered.Add(false);
        }
    }


    public void discoverScene(string name)
    {
        for (int i = 0; i < sceneNames.Count; i++)
        {
            if (sceneNames[i] == name && !scenesDiscovered[i])
            {
                playTooltip();
                scenesDiscovered[i] = true;
                sceneButtons[i].SetActive(true);
            }
        }
    }

    public void discoverClue(string location, int clueNumber)
    {
        if (!clueList[locationIndex[location]].Item2[clueNumber])
        {
            playTooltip();
            clueList[locationIndex[location]].Item1[clueNumber].SetActive(true);
            clueList[locationIndex[location]].Item2[clueNumber] = true;
        }
    }

    public void enableContent()
    {
        disableContent();
        for (int i = 0; i < scenesDiscovered.Count; i++)
        {
            if (scenesDiscovered[i])
            {
                sceneButtons[i].SetActive(true);
            }
        }
    }

    private void disableContent()
    {
        diner.SetActive(false);
        asylum.SetActive(false);
        city.SetActive(false);
        office.SetActive(false);
        garage.SetActive(false);
        home.SetActive(false);
        doctor.SetActive(false);
        tableOfContents.SetActive(false);
    }

    public void enableTableOfContents()
    {
        disableContent();
        tableOfContents.SetActive(true);
    }
    public void enableDoctor()
    {
        disableContent();
        doctor.SetActive(true);
    }
    public void enableHome()
    {
        disableContent();
        home.SetActive(true);
    }
    public void enableGarage()
    {
        disableContent();
        garage.SetActive(true);
    }
    public void enableOffice()
    {
        disableContent();
        office.SetActive(true);
    }
    public void enableCity()
    {
        disableContent();
        city.SetActive(true);
    }
    public void enableDiner()
    {
        disableContent();
        diner.SetActive(true);
    }
    public void enableAsylum()
    {
        disableContent();
        asylum.SetActive(true);
    }

    public void playTooltip()
    {
        GetComponentInChildren<updateJournalTooltip>().playTooltip();
    }

    public void showJournal()
    {
        Journal.SetActive(true);
    }

    public void hideJournal()
    {
        Journal.SetActive(false);
    }
}
