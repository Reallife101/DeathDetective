using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JournalManager : MonoBehaviour
{

    [SerializeField] GameObject Journal;
    [SerializeField] GameObject tableOfContents;

    //Scenes table of contents
    [SerializeField] List<string> sceneNames;
    [SerializeField] List<GameObject> sceneButtons;
    private List<bool> scenesDiscovered = new List<bool>();


    void Start()
    {
        genSceneList();
    }


    private void genSceneList()
    {
        for (int i = 0; i < sceneNames.Count; i++)
        {
            scenesDiscovered.Add(false);
        }
    }


    public void discoverScene(string name)
    {
        for (int i = 0; i < sceneNames.Count; i++)
        {
            if (sceneNames[i] == name)
            {
                scenesDiscovered[i] = true;
                sceneButtons[i].SetActive(true);
            }
        }
    }

    void enableTableOfContents()
    {
        tableOfContents.SetActive(true);
        for (int i = 0; i < scenesDiscovered.Count; i++)
        {
            if (scenesDiscovered[i])
            {
                sceneButtons[i].SetActive(true);
            }
        }
    }

    private void disableTableOfContents()
    {
        tableOfContents.SetActive(false);
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
