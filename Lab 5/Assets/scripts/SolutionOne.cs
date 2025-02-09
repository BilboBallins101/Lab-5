using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SolutionOne : MonoBehaviour
{
    public string characterName;
    public int characterLevel;
    public int characterCon;
    private float characterHP;
    public bool isHillDwarf = false;
    public bool toughFeat = false;
    public bool averageHP = false;

    private List<string> characterClasses = new List<string>
    {
        "Artificer", "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk",
        "Ranger", "Rogue", "Paladin", "Sorcerer", "Wizard", "Warlock"

    };

    Dictionary<string, int> hitDice = new Dictionary<string, int>
    {
        { "Artificer",8}, {"Barbarian",12 }, {"Bard",8 }, {"Cleric",8 }, {"Druid",8 }, {"Fighter",10 },{ "Monk",8 },
        { "Ranger",10 }, {"Rogue",8 }, {"Paladin",10 }, {"Sorcerer",6 }, {"Wizard",6 }, {"Warlock",8}
    };

    private int[] modifiers = new int[]
    {
        -5,-4,-4,-3,-3,-2,-2,-1,-1,0,0,1,1,2,2,3,3,4,4,5,5,6,6,7,7,8,8,9,9,10
    };

    public string selectedClass = "";
    

    // Start is called before the first frame update
    void Start()
    {
      GetHP();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rightclass()
    {
        if(characterClasses.Contains(selectedClass))
        {
          Debug.Log("Valid class");
        }
        else if(!characterClasses.Contains(selectedClass))
        {
            Debug.Log("Invalid class restart code");
            foreach(string characterClass in characterClasses)
            {
                Debug.Log(characterClass);
            }
            return;  
        }
    }

    private void OnValidate()
    {
        characterCon = Mathf.Clamp(characterCon,1,30);
        characterLevel = Mathf.Clamp(characterLevel,1,30);
    }

    private void GetHP() //Look over
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
        Debug.Log("HP = " +  characterHP);

    }
}