using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JournalManager : MonoBehaviour
{

    [SerializeField] GameObject Journal;
    [SerializeField] GameObject tableOfContents;
    [SerializeField] GameObject diner;

    //Scenes table of contents
    [SerializeField] List<string> sceneNames;
    [SerializeField] List<GameObject> sceneButtons;
    private List<bool> scenesDiscovered = new List<bool>();

    //Diner
    [SerializeField] List<GameObject> dinerClues;
    private List<bool> dinerCluesDiscovered = new List<bool>();


    private Dictionary<string, int> locationIndex = new Dictionary<string, int> () { { "diner", 0 }, { "city", 1 } };
    private List<(List<GameObject>, List<bool>)> clueList;

    void Start()
    {
        clueList = new List<(List<GameObject>, List<bool>)>() { (dinerClues, dinerCluesDiscovered) };
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

    public void enableTableOfContents()
    {
        disableContent();
        tableOfContents.SetActive(true);
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
        tableOfContents.SetActive(false);
    }
    public void enableDiner()
    {
        disableContent();
        diner.SetActive(true);
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
