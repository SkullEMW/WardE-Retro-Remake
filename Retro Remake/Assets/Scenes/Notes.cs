using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

public class Notes : MonoBehaviour
{
    public int numberOfItems; // Ints = whole numbers   
    public float health; // floats = decimal numbers
    public string menuLabel, actualFavoriteStudent, charaName; // Strings = Words/Phrases/Text/Labels
    public bool playerIsDead, isGrounded; // bool = true/false statements
    public Vector2 currentMovement, size; // vector2 = 2d decimals for (x,y)
    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("The favorite student of the month is " + charaName);

        if (isGrounded) // if statements = only happens when the statement in the paratheses is true
        {
            Debug.Log("On the floor crying");
        } // Curly brackets contains or groups things 
        else // if the "if" doesn't exacuted (can be true but not exacuted) then it'll show the else statement instead 
        {
            Debug.Log("Just kidding it's actually " + actualFavoriteStudent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
