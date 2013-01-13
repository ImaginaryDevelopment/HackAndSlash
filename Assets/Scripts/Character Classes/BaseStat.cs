
//http://www.burgzergarcade.com/tutorials/game-design/011-unity3d-tutorial-character-statistics-17
public class BaseStat {

	public string Name{get;set;}
	
	
	public BaseStat(){
		LevelModifier = 1.1f; // 10 % more per level
		ExpToLevel=100;
		Name=string.Empty;
	}
	
#region Properties
	
	public int BaseValue{get;set;}  //base value of stats, goes up when we spend on it
	public int BuffValue{get;private set;} //amount added by buff(s)
	public float LevelModifier{get; set;} // modifier applied to the exp needed to raise the skill
	public int ExpToLevel{get; set;} // total amount of exp to raise this skill, per stat leveling system
	
#endregion
	
	int CalculateExpToLevel()
	{
		return (int)( ExpToLevel * LevelModifier);
	}
	
	public void LevelUp()
	{
		ExpToLevel=CalculateExpToLevel();
		BaseValue++;
	}
	
	public int AdjustedBaseValue	{ 		get{			return BaseValue+BuffValue;			}	}
}
