using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CameraDoorScript
{
	public class CameraInteractor : MonoBehaviour
	{
		public float DistanceOpen = 3;
		public GameObject text;
		TMP_Text textText;
		string doorText = "Open Door";
		string sandwichText = "Make Sandwich";
		string washingMachineText = "Start Washing Machine";
		string lightSwitchText = "Flip Switch";
		string bedTimeText = "Go to Bed";
		string noteText = "Read Note";
		string catText = "Pet Cat";

		GameManager gameManager;
		PlayerCont playerCont;

		// Use this for initialization
		void Start()
		{
			textText = text.GetComponent<TMP_Text>();
			gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
			playerCont = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCont>();
		}

		// Update is called once per frame
		void Update()
		{
			RaycastHit hit;
			if (Physics.Raycast(transform.position, transform.forward, out hit, DistanceOpen))
			{
				//Check if what was hit by Raycast has the Door script, if it does set the text 
				if (hit.transform.GetComponent<DoorScript.Door>() && playerCont.playerCanMove)
				{
					textText.SetText(doorText);
					text.SetActive(true);

					if (Input.GetKeyDown(KeyCode.E)) //If Player presses E on Door, run door script OpenDoor()
						hit.transform.GetComponent<DoorScript.Door>().OpenDoor();
				}

				//Check if sandwich script is attached to GO
				else if (hit.transform.GetComponent<SandwichGame>() && gameManager.sandwichMade == false && playerCont.playerCanMove)
				{
					textText.SetText(sandwichText);
					text.SetActive(true);

					if (Input.GetKeyDown(KeyCode.E))
					{
						hit.transform.GetComponent<SandwichGame>().StartSandwichGame();
					}
				}

				else if (hit.transform.GetComponent<WashingMachineGame>() && gameManager.washingMachineStarted == false && playerCont.playerCanMove)
				{
					textText.SetText(washingMachineText);
					text.SetActive(true);

					if (Input.GetKeyDown(KeyCode.E))
					{
						hit.transform.GetComponent<WashingMachineGame>().StartWashingMachineGame();
					}
				}

				else if (hit.transform.GetComponent<LightSwitchController>() && playerCont.playerCanMove)
				{
					textText.SetText(lightSwitchText);
					text.SetActive(true);

					if (Input.GetKeyDown(KeyCode.E))
					{
						hit.transform.GetComponent<LightSwitchController>().ToggleLightSwitch();
					}
				}

				else if (hit.transform.GetComponent<BedTime>() && playerCont.playerCanMove && gameManager.ReadyToSleep())
				{
					textText.SetText(bedTimeText);
					text.SetActive(true);

					if (Input.GetKeyDown(KeyCode.E))
					{
						hit.transform.GetComponent<BedTime>().Sleep();
					}
				}

				else if (hit.transform.GetComponent<ReadNote>() && playerCont.playerCanMove)
				{
					textText.SetText(noteText);
					text.SetActive(true);

					if (Input.GetKeyDown(KeyCode.E))
					{
						hit.transform.GetComponent<ReadNote>().ShowNote();
					}
				}

				else if (hit.transform.GetComponent<CatMeow>())
				{
					textText.SetText(catText);
					text.SetActive(true);

					if (Input.GetKeyDown(KeyCode.E))
					{
						hit.transform.GetComponent<CatMeow>().Meow();
					}
				}
				else if (hit.transform.GetComponent<HousePuzzle>()&& playerCont.playerCanMove&&!gameManager.slidingPuzzleSolved)
				{
					textText.SetText("Solve Puzzle");
					text.SetActive(true);
					if (Input.GetKeyDown(KeyCode.E))
					{
						hit.transform.GetComponent<HousePuzzle>().StartPuzzle();
                    }
                }

				else
				{
					text.SetActive(false);
				}
			}
			else
			{
				text.SetActive(false);
			}
		}
	}
}
