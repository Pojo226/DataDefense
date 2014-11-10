﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour {

	//Wave number
	public int waveNum;

	//Spawns the AI
	public AISpawner AISpawner;

	private void Start () {
		
		FixedValues.gameTime = 30.00f;
		waveNum = 0;
	}
	
	private void Update()
	{
		if (Application.loadedLevelName == "GameScene1") {

			//adjust the time
			FixedValues.gameTime -= Time.deltaTime;

			//check if there is still time left
			if (FixedValues.gameTime >= 0) {
				//check the enemy number
				if (AISpawner.enemyNum == 0) {
					
					waveNum++;
					
					//spawn according to the wave number
					switch(waveNum)
					{
					case 1:
						FixedValues.gameTime = FixedValues.Max_Time;
						
						AISpawner.ConfigureNextSpawn (FixedValues.Enemy_Types.Data, 1);
						AISpawner.ConfigureNextSpawn (FixedValues.Enemy_Types.Program, 5);
						AISpawner.ConfigureNextSpawn (FixedValues.Enemy_Types.Virus, 7);
						AISpawner.SpawnWave ();
						break;
					case 2:
						FixedValues.gameTime = FixedValues.Max_Time;
						
						AISpawner.ConfigureNextSpawn (FixedValues.Enemy_Types.Data, 8);
						AISpawner.ConfigureNextSpawn (FixedValues.Enemy_Types.Program, 6);
						AISpawner.ConfigureNextSpawn (FixedValues.Enemy_Types.Virus, 3);
						AISpawner.SpawnWave ();
						break;
					default:
						FixedValues.gameTime = FixedValues.Max_Time;
						break;
					}
				}else {
					
					
				}
			} else {
				//Game Over
				waveNum = 0;
				Application.LoadLevel ("GameOver");
			}
		}
		if (Application.loadedLevelName == "GameOver") {
			//Press space to restart
			if (Input.GetButtonDown("A_" + 1) ||Input.GetButtonDown("A_" + 2) ||Input.GetButtonDown("A_" + 3) ||Input.GetButtonDown("A_" + 4) || Input.GetKey(KeyCode.Space))
			{
				Application.LoadLevel("GameScene1");
				Debug.Log("Player" + "Pushed" + ": A");
			}
		}
	}
}