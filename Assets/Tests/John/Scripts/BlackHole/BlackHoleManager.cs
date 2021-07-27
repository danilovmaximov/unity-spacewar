using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleManager : MonoBehaviour
{
	// Amount of generated Black Holes
	public int BlackHolesAmount = 0;

	// Black Hole Entity
	private GameObject BlackHoleEntity;
	// Black Hole Entities
	private GameObject[] BlackHoleEntities;
	// Render Textures for Black Holes

	void Awake()
	{
		// Downloading BlackHoleEntity
		// prefab from resources. We
		// will use it for instantiating
		// Black Holes during game cycle.
		BlackHoleEntity = Resources.Load("Prefabs/BlackHole/BlackHoleEntity", typeof(GameObject)) as GameObject;

		// Instantiating our arrays...
		BlackHoleEntities = new GameObject[BlackHolesAmount];

		for(int i = 0; i < BlackHolesAmount; i++)
		{
			// Instantiate exactly the amount
			// of black holes you need...
			BlackHoleEntities[i] = GameObject.Instantiate(BlackHoleEntity);
			BlackHoleEntities[i].name = "BlackHoleEntity";
		}
	}
}