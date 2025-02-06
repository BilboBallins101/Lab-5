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

    Dictionary<string, int> dndDiction = new Dictionary<string, int>
    {
        { "Artificer",8}, {"Barbarian",12 }, {"Bard",8 }, {"Cleric",8 }, {"Druid",8 }, {"Fighter",10 },{ "Monk",8 },
        { "Ranger",10 }, {"Rogue",8 }, {"Paladin",10 }, {"Sorcerer",6 }, {"Wizard",6 }, {"Warlock",8}
    };

    public int[] modifiers = new int[]
    {
        -5,-4,-4,-3,-3,-2,-2,-1,-1,0,0,1,1,2,2,3,3,4,4,5,5,6,6,7,7,8,8,9,9,10
    };




    // Start is called before the first frame update
    void Start()
    {
      // Debug.LogFormat("My character ")
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetHP(Dictionary die) //Look over
    {
        if(averageHP)
        {
            characterHP = die * characterLevel / 2 + 0.5;
        }
       
    }
}
