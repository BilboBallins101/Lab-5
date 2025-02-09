using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpClass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlayerHP()
     {
        rightclass();
        int hitDie = hitDice[selectedClass];
        int conModifier = modifiers[characterCon - 1];

         characterHP = hitDie + conModifier; //Level 1 hp
        
        if(averageHP)
        {
            float avgRoll = (hitDie / 2.0f) + 0.5f;
            characterHP += Mathf.FloorToInt((characterLevel - 1) * (avgRoll + conModifier));
        }
        else
        {
            for(int i =1; i < characterLevel; i++)
            {
                characterHP += Random.Range(1, hitDie + 1) + conModifier;
            }   
        }
        if(isHillDwarf)
        {
            characterHP += characterLevel;
        }

        if(toughFeat)
        {
            characterHP += characterLevel * 2;
        }

        Debug.Log($"My character {characterName} is a level {characterLevel} {selectedClass} with a CON score of {characterCon} and {(isHillDwarf ? "is" : "is not")} a Hill Dwarf and {(toughFeat ? "has" : "does not have")} the Tough feat. I want the HP { (averageHP ? "averaged" : "rolled") }.");

    }
}
