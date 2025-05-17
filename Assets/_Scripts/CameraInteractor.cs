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

		// Use this for initialization
		void Start()
		{
			textText = text.GetComponent<TMP_Text>();
		}

		// Update is called once per frame
		void Update()
		{
			RaycastHit hit;
			if (Physics.Raycast(transform.position, transform.forward, out hit, DistanceOpen))
			{
				//Check if what was hit by Raycast has the Door script, if it does set the text 
				if (hit.transform.GetComponent<DoorScript.Door>())
				{
					textText.SetText(doorText);
					text.SetActive(true);

					if (Input.GetKeyDown(KeyCode.E)) //If Player presses E on Door, run door script OpenDoor()
						hit.transform.GetComponent<DoorScript.Door>().OpenDoor();
				}
				//Check if sandwich script is attached to GO
				else if (hit.transform.GetComponent<SandwichGame>())
				{
					textText.SetText(sandwichText);
					text.SetActive(true);

					if (Input.GetKeyDown(KeyCode.E))
					{
						//Make mouse visible, make player unable to move, and run sandwich
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
