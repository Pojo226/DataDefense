﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour {

	//Spawns the AI
	public AISpawner AISpawner;

	float timePassed;

	private void Start () {
		
		FixedValues.gameTime = 30.00f;
	}
	
	private void Update()
	{
		if (Application.loadedLevelName == "GameScene1") {

			//adjust the time
			FixedValues.gameTime -= Time.deltaTime;

			//check if there is still time left
			if (FixedValues.gameTime >= 0) {
				//check the enemy number
				if (FixedValues.enemyNum <= 0) {
					
					FixedValues.waveNum++;

					FixedValues.gameTime = FixedValues.Max_Time;

					//spawn according to the wave number
					AISpawner.ConfigureNextSpawn (FixedValues.Enemy_Types.Data, Random.Range(FixedValues.waveNum + 3, (FixedValues.waveNum * 2) + 4));
					AISpawner.ConfigureNextSpawn (FixedValues.Enemy_Types.Program, Random.Range((FixedValues.waveNum / 4) + 2, (FixedValues.waveNum * 2) + 3));
					AISpawner.ConfigureNextSpawn (FixedValues.Enemy_Types.Virus, Random.Range((FixedValues.waveNum / 2) + 1, (FixedValues.waveNum / 2) + FixedValues.waveNum) + 2);
					AISpawner.SpawnWave ();

					//old spawning function
					/*
					switch(FixedValues.waveNum)
					{
					case 1:
						FixedValues.gameTime = FixedValues.Max_Time;
						
						AISpawner.ConfigureNextSpawn (FixedValues.Enemy_Types.Data, 10);
						AISpawner.ConfigureNextSpawn (FixedValues.Enemy_Types.Program, 3);
						AISpawner.ConfigureNextSpawn (FixedValues.Enemy_Types.Virus, 4);
						AISpawner.SpawnWave ();
						break;
					case 2:
						FixedValues.gameTime = FixedValues.Max_Time;
						
						AISpawner.ConfigureNextSpawn (FixedValues.Enemy_Types.Data, 2);
						AISpawner.ConfigureNextSpawn (FixedValues.Enemy_Types.Program, 5);
						AISpawner.ConfigureNextSpawn (FixedValues.Enemy_Types.Virus, 3);
						AISpawner.SpawnWave ();
						break;
					case 3:
						FixedValues.gameTime = FixedValues.Max_Time;
						
						AISpawner.ConfigureNextSpawn (FixedValues.Enemy_Types.Data, 4);
						AISpawner.ConfigureNextSpawn (FixedValues.Enemy_Types.Program, 7);
						AISpawner.ConfigureNextSpawn (FixedValues.Enemy_Types.Virus, 4);
						AISpawner.SpawnWave ();
						break;
					case 4:
						FixedValues.gameTime = FixedValues.Max_Time;
						
						AISpawner.ConfigureNextSpawn (FixedValues.Enemy_Types.Data, 6);
						AISpawner.ConfigureNextSpawn (FixedValues.Enemy_Types.Program, 9);
						AISpawner.ConfigureNextSpawn (FixedValues.Enemy_Types.Virus, 5);
						AISpawner.SpawnWave ();
						break;
					case 5:
						FixedValues.gameTime = FixedValues.Max_Time;
						
						AISpawner.ConfigureNextSpawn (FixedValues.Enemy_Types.Data, 8);
						AISpawner.ConfigureNextSpawn (FixedValues.Enemy_Types.Program, 10);
						AISpawner.ConfigureNextSpawn (FixedValues.Enemy_Types.Virus, 6);
						AISpawner.SpawnWave ();
						break;
					default:
						FixedValues.gameTime = FixedValues.Max_Time;
						break;
					}*/
				}else {
					
					
				}
			} else {
				//Game Over
				Application.LoadLevel ("GameOver");
			}
		}
		if (Application.loadedLevelName == "GameOver") {
			//Press space to restart
			if (Input.GetButtonDown("A_" + 1) ||Input.GetButtonDown("A_" + 2) ||Input.GetButtonDown("A_" + 3) ||Input.GetButtonDown("A_" + 4) || Input.GetKey(KeyCode.Space))
			{				
				//reset values
				FixedValues.waveNum = 0;				
				FixedValues.enemyNum = 0;
				
				FixedValues.superScanVals[0] = 0;
				FixedValues.superScanVals[1] = 0;
				FixedValues.superScanVals[2] = 0;			
				FixedValues.superScanVals[3] = 0;
				
				FixedValues.playerScores[0] = 0;
				FixedValues.playerScores[1] = 0;
				FixedValues.playerScores[2] = 0;
				FixedValues.playerScores[3] = 0;

				//return to title
				Application.LoadLevel("TitleScreen");
				Debug.Log("Player" + "Pushed" + ": A");
			}
		}
		if (Application.loadedLevelName == "GetReady") {


			timePassed += Time.deltaTime;


			if (timePassed > 3.0f)
			{
				Application.LoadLevel("GameScene1");
			}
		}
	}

	public void PlayButton()
	{
		Application.LoadLevel ("GetReady");
	}

	
	public void InstructionButton()
	{
		Application.LoadLevel ("ControlScreen");
	}	

	public void HomeButton()
	{
		Application.LoadLevel ("TitleScreen");
	}

}