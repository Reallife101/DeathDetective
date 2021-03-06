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
    [SerializeField] GameObject accusation;

    //Scenes table of contents
    [SerializeField] List<string> sceneNames;
    [SerializeField] List<GameObject> sceneButtons;
    public List<bool> scenesDiscovered = new List<bool>();

    //Diner
    [SerializeField] List<GameObject> dinerClues;
    public List<bool> dinerCluesDiscovered = new List<bool>();

    //Asylum
    [SerializeField] List<GameObject> asylumClues;
    public List<bool> asylumCluesDiscovered = new List<bool>();

    //City
    [SerializeField] List<GameObject> cityClues;
    public List<bool> cityCluesDiscovered = new List<bool>();

    //Office
    [SerializeField] List<GameObject> officeClues;
    public List<bool> officeCluesDiscovered = new List<bool>();

    //Garage
    [SerializeField] List<GameObject> garageClues;
    public List<bool> garageCluesDiscovered = new List<bool>();

    //Home
    [SerializeField] List<GameObject> homeClues;
    public List<bool> homeCluesDiscovered = new List<bool>();

    //Doctors
    [SerializeField] List<GameObject> doctorClues;
    public List<bool> doctorCluesDiscovered = new List<bool>();

    private Dictionary<string, int> locationIndex = new Dictionary<string, int>() { { "diner", 0 }, { "asylum", 1 }, { "city", 2 }, { "office", 3 }, 
        { "garage", 4 }, {"home", 5 }, {"doctor", 6 } };
    private List<(List<GameObject>, List<bool>)> clueList;

    void Start()
    {
        //saveJournal.deleteFile();
        if (saveJournal.dataExists())
        {
            journalData jd = saveJournal.loadJournal();
            scenesDiscovered = new List<bool>(jd.scenesDiscovered);
            dinerCluesDiscovered = new List<bool>(jd.dinerCluesDiscovered);
            asylumCluesDiscovered = new List<bool>(jd.asylumCluesDiscovered);
            cityCluesDiscovered = new List<bool>(jd.cityCluesDiscovered);
            officeCluesDiscovered = new List<bool>(jd.officeCluesDiscovered);
            garageCluesDiscovered = new List<bool>(jd.garageCluesDiscovered);
            homeCluesDiscovered = new List<bool>(jd.homeCluesDiscovered);
            doctorCluesDiscovered = new List<bool>(jd.doctorCluesDiscovered);
            enableContent();
            tableOfContents.SetActive(true);
        }
        else 
        {
            genList();
        }
        clueList = new List<(List<GameObject>, List<bool>)>() { (dinerClues, dinerCluesDiscovered), (asylumClues, asylumCluesDiscovered), 
            (cityClues, cityCluesDiscovered), (officeClues, officeCluesDiscovered), (garageClues, garageCluesDiscovered), (homeClues, homeCluesDiscovered),
            (doctorClues, doctorCluesDiscovered)};
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            deletejournal();
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            discoverScene("diner");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            discoverScene("asylum");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            discoverScene("city");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            discoverScene("office");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            discoverScene("garage");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            discoverScene("home");
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            discoverScene("doctor");
        }
    }

    public void deleteJ()
    {
        saveJournal.deleteFile();
        genList();
        clueList = new List<(List<GameObject>, List<bool>)>() { (dinerClues, dinerCluesDiscovered), (asylumClues, asylumCluesDiscovered),
            (cityClues, cityCluesDiscovered), (officeClues, officeCluesDiscovered), (garageClues, garageCluesDiscovered), (homeClues, homeCluesDiscovered),
            (doctorClues, doctorCluesDiscovered)};
        saveJournal.SaveJournal(this);
        enableContent();
        enableTableOfContents();
    }

    private void deletejournal()
    {
        saveJournal.deleteFile();
        genList();
        clueList = new List<(List<GameObject>, List<bool>)>() { (dinerClues, dinerCluesDiscovered), (asylumClues, asylumCluesDiscovered),
            (cityClues, cityCluesDiscovered), (officeClues, officeCluesDiscovered), (garageClues, garageCluesDiscovered), (homeClues, homeCluesDiscovered),
            (doctorClues, doctorCluesDiscovered)};
        saveJournal.SaveJournal(this);
        playTooltip();
        enableContent();
        enableTableOfContents();
    }

    private void genList()
    {
        scenesDiscovered = new List<bool>();
        for (int i = 0; i < sceneNames.Count; i++)
        {
            scenesDiscovered.Add(false);
        }

        dinerCluesDiscovered = new List<bool>();
        for (int i = 0; i < dinerClues.Count; i++)
        {
            dinerCluesDiscovered.Add(false);
        }

        asylumCluesDiscovered = new List<bool>();
        for (int i = 0; i < asylumClues.Count; i++)
        {
            asylumCluesDiscovered.Add(false);
        }

        cityCluesDiscovered = new List<bool>();
        for (int i = 0; i < cityClues.Count; i++)
        {
            cityCluesDiscovered.Add(false);
        }

        officeCluesDiscovered = new List<bool>();
        for (int i = 0; i < officeClues.Count; i++)
        {
            officeCluesDiscovered.Add(false);
        }

        garageCluesDiscovered = new List<bool>();
        for (int i = 0; i < garageClues.Count; i++)
        {
            garageCluesDiscovered.Add(false);
        }

        homeCluesDiscovered = new List<bool>();
        for (int i = 0; i < homeClues.Count; i++)
        {
            homeCluesDiscovered.Add(false);
        }

        doctorCluesDiscovered = new List<bool>();
        for (int i = 0; i < doctorClues.Count; i++)
        {
            doctorCluesDiscovered.Add(false);
        }
        discoverScene("city");
    }


    public void discoverScene(string name)
    {
        for (int i = 0; i < sceneNames.Count; i++)
        {
            if (sceneNames[i].ToLower() == name.ToLower() && !scenesDiscovered[i])
            {
                playTooltip();
                scenesDiscovered[i] = true;
                sceneButtons[i].SetActive(true);
                saveJournal.SaveJournal(this);
            }
        }
    }

    public void discoverClue(string location, int clueNumber)
    {
        if (!clueList[locationIndex[location.ToLower()]].Item2[clueNumber])
        {
            playTooltip();
            clueList[locationIndex[location.ToLower()]].Item1[clueNumber].SetActive(true);
            clueList[locationIndex[location.ToLower()]].Item2[clueNumber] = true;
            saveJournal.SaveJournal(this);
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
            else
            {
                sceneButtons[i].SetActive(false);
            }
        }
        //Last "scene button" is the accusation button and should alway appear
        sceneButtons[sceneButtons.Count-1].SetActive(true);

        for (int i = 0; i < dinerCluesDiscovered.Count; i++)
        {
            if (dinerCluesDiscovered[i])
            {
                dinerClues[i].SetActive(true);
            }
            else
            {
                dinerClues[i].SetActive(false);
            }
        }

        for (int i = 0; i < asylumCluesDiscovered.Count; i++)
        {
            if (asylumCluesDiscovered[i])
            {
                asylumClues[i].SetActive(true);
            }
            else
            {
                asylumClues[i].SetActive(false);
            }
        }

        for (int i = 0; i < cityCluesDiscovered.Count; i++)
        {
            if (cityCluesDiscovered[i])
            {
                cityClues[i].SetActive(true);
            }
            else
            {
                cityClues[i].SetActive(false);
            }
        }

        for (int i = 0; i < officeCluesDiscovered.Count; i++)
        {
            if (officeCluesDiscovered[i])
            {
                officeClues[i].SetActive(true);
            }
            else
            {
                officeClues[i].SetActive(false);
            }
        }

        for (int i = 0; i < garageCluesDiscovered.Count; i++)
        {
            if (garageCluesDiscovered[i])
            {
                garageClues[i].SetActive(true);
            }
            else
            {
                garageClues[i].SetActive(false);
            }
        }

        for (int i = 0; i < homeCluesDiscovered.Count; i++)
        {
            if (homeCluesDiscovered[i])
            {
                homeClues[i].SetActive(true);
            }
            else
            {
                homeClues[i].SetActive(false);
            }
        }

        for (int i = 0; i < doctorCluesDiscovered.Count; i++)
        {
            if (doctorCluesDiscovered[i])
            {
                doctorClues[i].SetActive(true);
            }
            else
            {
                doctorClues[i].SetActive(false);
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
        accusation.SetActive(false);
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

    public void enableAccusation()
    {
        disableContent();
        accusation.SetActive(true);
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
