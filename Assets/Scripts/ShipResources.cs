using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ShipResources
{
	// Переменные жизней корабля
	public static int shipHealthMax = 3;

	// Логические флаги для игровой логики
	public static bool healthLock = false;
	public static bool inputLock = false;

	// Статическое поле событие
	public static event Action<string, int> OnShipDie;

	// Регистр созданных кораблей
	public static Dictionary<string, int> ShipRegister = new Dictionary<string, int>();

	public static void RegisterNewShip(string name)
	{
		ShipRegister[name] = shipHealthMax;
	}

	public static int GetRegisteredShip(string name)
	{
		return ShipRegister[name];
	}

	public static void SetRegisteredShip(string name, int health)
	{
		ShipRegister[name] = health;
	}

	public static void ReduceHealth(string name)
	{
		if(!healthLock)
		{
			// В противном случае - обновляем значение жизней
			ShipRegister[name]--;

			// Вызываем событие гибели корабля
			Debug.Log(name + " object invoked event");
			OnShipDie?.Invoke(name, ShipRegister[name]);
		}
	}
}
