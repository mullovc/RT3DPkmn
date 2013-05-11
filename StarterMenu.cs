using UnityEngine;
using System.Collections;

public class StarterMenu : MonoBehaviour {
	
	public Pokedex 	pokedex;
	string[] Names = new string[500];
	
	public int 		starterIndex;
	public int 		enemyIndex;
	GameObject		myPokemonModel;
	GameObject		enemyPokemonModel;
	
	Vector2 		scrollPosition;
	
	void Start ()
	{
		Camera.main.transform.eulerAngles = new Vector3(0,180,0);
		DontDestroyOnLoad(this.transform);
		
		for(int i = 1; i <= 493; i++)
		{
			Names[i] = getPokemonName(i);
		}
	}
	
	void OnGUI()
	{
		GUI.skin.button.fontSize = 20;
		GUI.skin.button.alignment = TextAnchor.MiddleLeft;
		scrollPosition = GUI.BeginScrollView(new Rect(0,0,Screen.width - 5,Screen.height - 0),scrollPosition,new Rect(0,0,Screen.width - 25,Screen.height * 27.2f));
		
		for(int i = 1; i <= 493; i++)
		{
			GUILayout.BeginHorizontal();
			
			if(GUILayout.Button(i + " " + Names[i]))
			{
				starterIndex = i;
				if(myPokemonModel != null)
					Destroy(myPokemonModel);
				myPokemonModel = Instantiate(pokedex.model[i],new Vector3(10,-5,-40),Quaternion.identity) as GameObject;
			}
			
			GUILayout.Space(Screen.width - 320);
			
			if(GUILayout.Button(i + " " + Names[i]))
			{
				enemyIndex = i;
				if(enemyPokemonModel != null)
					Destroy(enemyPokemonModel);
				enemyPokemonModel = Instantiate(pokedex.model[i],new Vector3(-10,-5,-40),Quaternion.identity) as GameObject;
			}
			
			GUILayout.EndHorizontal();
			
		}
		
		GUI.EndScrollView();
		
		GUI.skin.button.alignment = TextAnchor.MiddleCenter;
		
		if(GUI.Button(new Rect(Screen.width / 2 - 100,Screen.height * 0.8f,200,80),"Start"))
		{
			if(enemyIndex != 0 && starterIndex != 0)
				Application.LoadLevel(1);
		}
	}
	
	string getPokemonName(int index)
	{
		GameObject a = new GameObject();
		a.AddComponent<Stats>();
		Stats pokemon = a.GetComponent<Stats>();
		pokemon = pokedex.pokedex(pokemon,index,false);
		string Name;
		if(pokemon != null)
		{
			Name = pokemon.Name;
		}
		else
		{
			Name = "";
		}
		Destroy(a.gameObject);
		return Name;
	}
	
	void Update ()
	{
		
	}
}
