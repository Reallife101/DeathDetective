using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class journalData
{
    public bool[] scenesDiscovered;
    public bool[] dinerCluesDiscovered;
    public bool[] asylumCluesDiscovered;
    public bool[] cityCluesDiscovered;
    public bool[] officeCluesDiscovered;
    public bool[] garageCluesDiscovered;
    public bool[] homeCluesDiscovered;
    public bool[] doctorCluesDiscovered;

    public journalData(JournalManager jm)
    {
        scenesDiscovered = jm.scenesDiscovered.ToArray();
        dinerCluesDiscovered = jm.dinerCluesDiscovered.ToArray();
        asylumCluesDiscovered = jm.asylumCluesDiscovered.ToArray();
        cityCluesDiscovered = jm.cityCluesDiscovered.ToArray();
        officeCluesDiscovered = jm.officeCluesDiscovered.ToArray();
        garageCluesDiscovered = jm.garageCluesDiscovered.ToArray();
        homeCluesDiscovered = jm.homeCluesDiscovered.ToArray();
        doctorCluesDiscovered = jm.doctorCluesDiscovered.ToArray();

    }

}
