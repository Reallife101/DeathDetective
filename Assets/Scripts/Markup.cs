 //This code is from: https://answers.unity.com/questions/1580505/make-object-b-visible-when-clicking-on-object-acli.html
 
 using UnityEngine;
 
 public class Markup : MonoBehaviour
 {
     [SerializeField] GameObject objectToMakeVisible;
 
     void Awake()
     {   
         objectToMakeVisible.SetActive(false);
     }
 
     public void ToggleLinkedObject()
     {
         objectToMakeVisible.SetActive(!objectToMakeVisible.activeSelf);
 
         // If don't want the object to toggle, then do (comment out line above)
         //objectToMakeVisible.SetActive(false);
 
         // if the visibility only happens once, remove  this script so it can't be clicked again (comment out line above)
         //Destroy(this);
     }
 }