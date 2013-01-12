using UnityEngine;
using System.Collections;
using System;
public class CharacterGenerator : MonoBehaviour {
	PlayerCharacter _toon;
	const int STARTING_POINTS=350;
	const int MIN_STARTING_ATTRIBUTE_VALUE=10;
	int pointsLeft=STARTING_POINTS;
	// Use this for initialization
	void Start () {
		_toon = new PlayerCharacter();
		_toon.Awake();
		for(var cnt= 0; cnt< Enum.GetValues(typeof(AttributeName)).Length;cnt++)
			_toon.GetPrimaryAttribute(cnt).BaseValue=MIN_STARTING_ATTRIBUTE_VALUE;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		DisplayName();
		DisplayPointsLeft();
		DisplayAttributes();
		DisplayVitals();
		DisplaySkills();
	}
	
	void DisplayName(){
		GUI.Label(new Rect(10,10,50,25),"Name:");
		_toon.Name= GUI.TextArea(new Rect(65,10,100,25),_toon.Name);
	}
	void DisplayPointsLeft(){
		GUI.Label(new Rect(250,10,100,25),"Points Left: " + pointsLeft);
		
	}
	
	void DisplayAttributes(){
		for(var cnt= 0; cnt< Enum.GetValues(typeof(AttributeName)).Length;cnt++)
		{
			GUI.Label(new Rect(10,40+25*cnt,100,25),((AttributeName)cnt).ToString());
			//_toon.GetPrimaryAttribute(cnt).BaseValue=
			GUI.Label(new Rect(115,40+25*cnt,30 ,25),_toon.GetPrimaryAttribute(cnt).AdjustedBaseValue.ToString());
			if(GUI.Button(new Rect(150,40+25*cnt,25,25),"-"))
			{
				if( _toon.GetPrimaryAttribute(cnt).BaseValue> MIN_STARTING_ATTRIBUTE_VALUE){
					_toon.GetPrimaryAttribute(cnt).BaseValue--;
					pointsLeft++;	
				}
				
			}
			if(GUI.Button(new Rect(180,40+25*cnt,25,25),"+") && pointsLeft > 0)
			{
				_toon.GetPrimaryAttribute(cnt).BaseValue++;
				pointsLeft--;
			}
		}
	
	}
	
	void DisplayVitals(){
		for(var cnt= 0; cnt< Enum.GetValues(typeof(VitalName)).Length;cnt++)
		{
			GUI.Label(new Rect(10,40+25*(cnt+7),100,25),((VitalName)cnt).ToString());
			//_toon.GetPrimaryAttribute(cnt).BaseValue=
			GUI.Label(new Rect(115,40+25*(cnt+7),30 ,25),_toon.GetVital(cnt).AdjustedBaseValue.ToString());
		}
	}
	void DisplaySkills(){
			for(var cnt= 0; cnt< Enum.GetValues(typeof(SkillName)).Length;cnt++)
		{
			GUI.Label(new Rect(250,40+25*cnt,100,25),((SkillName)cnt).ToString());
			//_toon.GetPrimaryAttribute(cnt).BaseValue=
			GUI.Label(new Rect(355,40+25*cnt,30 ,25),_toon.GetSkill(cnt).AdjustedBaseValue.ToString());
		}
	}
}
