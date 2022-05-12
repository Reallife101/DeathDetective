using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public HighlightPlus.HighlightEffect he;
    public abstract void interact();

}
