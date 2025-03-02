﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

	public GameObject evilVegetable;
	[Range(0,120)] public float spawnInterval = 3.0f;
	public int maxSimultaneous = 3;

	private List<GameObject> lstGardenVegetables;
	private float timer = 0;
	private int enemyQuantity = 0;

	void Start () {
		ListPlantedVegetables ();
	}

	// Update is called once per frame
	void Update () {
		
		if (timer > 0) {
			timer -= Time.deltaTime;
			return;
		}

		Spawn ();
	}

	void ListPlantedVegetables () {
		lstGardenVegetables = new List<GameObject> ();
		foreach (GameObject go in GameObject.FindGameObjectsWithTag ("Vegetable")) {
			lstGardenVegetables.Add (go);
		}
	}

	void Spawn () {
		// Start timer
		timer = spawnInterval;

		// Get the current quantity of enemies
		enemyQuantity = GameObject.FindGameObjectsWithTag ("Enemy").Length;

		// Refresh the list of planted vegetables
		ListPlantedVegetables ();

		// Verify if exists much enemies as the max simultaneous
		if (enemyQuantity >= maxSimultaneous || lstGardenVegetables.Count == 0) // This counting can turn a bootleneck 
			return;
		
		// Choose a vegetable to replace
		GameObject poorVegetableMarkedToSpawnOver = lstGardenVegetables[Random.Range(0, lstGardenVegetables.Count)];

		// TODO : Implementar para não espawnear na luz!

		// Remove vegetable from list
		//lstGardenVegetables.Remove(poorVegetableMarkedToSpawnOver);

		// Spawn the evil vegetable in place of the ordinary vegetable
		Instantiate (evilVegetable, poorVegetableMarkedToSpawnOver.transform.position, Quaternion.identity);

		// Kill the poor vegetable
		//Destroy (poorVegetableMarkedToSpawnOver);
	}

}
