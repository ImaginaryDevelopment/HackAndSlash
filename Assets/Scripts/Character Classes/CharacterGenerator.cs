using UnityEngine;
using System.Collections;
using System;
public class CharacterGenerator : MonoBehaviour {
	PlayerCharacter _toon;
	const int STARTING_POINTS=350;
	const int MIN_STARTING_ATTRIBUTE_VALUE=10;
	const int STARTING_VALUE = 50;
	int pointsLeft=STARTING_POINTS;
	const int OFFSET= 5;
	const int LINE_HEIGHT = 20;
	const int STAT_LABEL_WIDTH = 100;
	const int BASEVALUE_LABEL_WIDTH = 30;
	int statStartingY = 40;
	
	
	public bool UseButtonStyle;
	
	public GUISkin mySkin;
	
	int attributeValueCount;
	// Use this for initialization
	void Start () {
		_toon = new PlayerCharacter();
		_toon.Awake();
		attributeValueCount=Enum.GetValues(typeof(AttributeName)).Length;
		for(var cnt= 0; cnt<attributeValueCount ;cnt++)
		{
			_toon.GetPrimaryAttribute(cnt).BaseValue=STARTING_VALUE;
			pointsLeft-=(STARTING_VALUE - MIN_STARTING_ATTRIBUTE_VALUE);
		}	
		
		_toon.StatUpdate();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI() {
		GUI.skin=mySkin;
		DisplayName();
		DisplayPointsLeft();
		var right=DisplayAttributes();
		
		DisplayVitals();
		DisplaySkills(right+OFFSET*2);
	}
	
	void DisplayName(){
		GUI.Label(new Rect(OFFSET,OFFSET,50,LINE_HEIGHT),"Name:");
		_toon.Name= GUI.TextField(new Rect(65,OFFSET,100,LINE_HEIGHT),_toon.Name);
	}
	void DisplayPointsLeft(){
		GUI.Label(new Rect(250,OFFSET,100,LINE_HEIGHT),"Points Left: " + pointsLeft);
		
	}
	
	/// <returns>
	/// the right coordinate
	/// </returns>
	int DisplayAttributes(){
		
		var right=0;
		for(var cnt= 0; cnt< Enum.GetValues(typeof(AttributeName)).Length;cnt++)
		{
			int lineTop=statStartingY+LINE_HEIGHT*cnt;
			
			GUI.Label(new Rect(OFFSET,lineTop,STAT_LABEL_WIDTH,LINE_HEIGHT),((AttributeName)cnt).ToString());
			//_toon.GetPrimaryAttribute(cnt).BaseValue=
			GUI.Label(new Rect(STAT_LABEL_WIDTH+OFFSET,lineTop,BASEVALUE_LABEL_WIDTH ,LINE_HEIGHT),_toon.GetPrimaryAttribute(cnt).AdjustedBaseValue.ToString());
			
			int buttonWidth=LINE_HEIGHT; //square
			int buttonLeft=OFFSET+STAT_LABEL_WIDTH+BASEVALUE_LABEL_WIDTH;
			if(GUI.Button(new Rect(buttonLeft,lineTop,buttonWidth,LINE_HEIGHT),"-"))
			{
				if( _toon.GetPrimaryAttribute(cnt).BaseValue> MIN_STARTING_ATTRIBUTE_VALUE){
					_toon.GetPrimaryAttribute(cnt).BaseValue--;
					pointsLeft++;	
					_toon.StatUpdate();
				}
				
			}
			if(GUI.Button(new Rect(buttonLeft+LINE_HEIGHT+OFFSET,lineTop,buttonWidth,LINE_HEIGHT),"+") && pointsLeft > 0)
			{
				_toon.GetPrimaryAttribute(cnt).BaseValue++;
				pointsLeft--;
				_toon.StatUpdate();
			}
			if(right == 0)
				right=buttonLeft+LINE_HEIGHT+OFFSET+LINE_HEIGHT;
		}
		
		return right;
	}
	
	void DisplayVitals(){
		for(var cnt= 0; cnt< Enum.GetValues(typeof(VitalName)).Length;cnt++)
		{
			GUI.Label(new Rect(OFFSET,statStartingY+LINE_HEIGHT*(cnt+attributeValueCount),STAT_LABEL_WIDTH,LINE_HEIGHT),((VitalName)cnt).ToString());
			//_toon.GetPrimaryAttribute(cnt).BaseValue=
			GUI.Label(new Rect(OFFSET+STAT_LABEL_WIDTH,statStartingY+LINE_HEIGHT*(cnt+attributeValueCount),BASEVALUE_LABEL_WIDTH ,LINE_HEIGHT),
				_toon.GetVital(cnt).AdjustedBaseValue.ToString());
		}
	}
	void DisplaySkills(int left){
		
		
		for(var cnt= 0; cnt< Enum.GetValues(typeof(SkillName)).Length;cnt++)
		{
			int top=40+LINE_HEIGHT*cnt;
			GUI.Label(new Rect(left,top,STAT_LABEL_WIDTH,LINE_HEIGHT),((SkillName)cnt).ToString());
			//_toon.GetPrimaryAttribute(cnt).BaseValue=
			GUI.Label(new Rect(left+STAT_LABEL_WIDTH+OFFSET,top,30 ,LINE_HEIGHT),_toon.GetSkill(cnt).AdjustedBaseValue.ToString());
		}
	}
}
