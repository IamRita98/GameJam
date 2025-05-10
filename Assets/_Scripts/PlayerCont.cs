using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour
{
    //Public variable can been seen and changed in the Unity Editor underneath the script component attached to the gameobject in the Inspector. You can see I've set speed to a default 0
    //here but in the editor we can quickly change it for playtesting. If we want then once we have a final number we can make this private and pass it to class of Constants.
    public float speed = 0;

    private float horInput;
    private float vertInput;

    private void Start()
    {
        //Hides cursor on game start
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //Get players input-- GetAxis("Horizontal/Vertical") look at Unity's Edit > Project Settings > Input Manager to see what is mapped to those two strings. In this case, A/D, W/S & Arrow Keys
        //When A is held Horizontal becomes -1, when D is held it becomes postive 1, this turns into direction when multiplied by the other variables.
        //Strafing is taken into account, D + W would != 2 total. Speed is our controlled variable. & Time.deltaTime is multiplying by the time passed since the last frame was called--
        //This means that since the Update Method is called every frame the game runs a comp running a lot of frames per second and a comp running very few will normalize and end up with an equal
        //value, making sure the player moves the same distance/second regardless of fps
        horInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        vertInput = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        //We used Update to get the players Inputs then we pass those values to FixedUpdate where physics are handled.

        //This turns the cursor back on when the player presses Escape. It's important that we check for inputs in the Update function as it's being checked every frame of the game, as opposed to
        //FixedUpdate which we use for physics as is checked at a consistant rate, unrelated to the computers fps meaning that it could miss the frame that the player pressed an input, however it will
        //always have the physics continuing in those missed frames. You can find a better understanding of these two methods Update & FixedUpdate in the unity Documentation.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void FixedUpdate()
    {
        //Now that we have a value for inputs we can apply that value to the gameobject. If you go to the Unity Editor and click on our player GameObject, on the right in our Inspector tab,
        //you can see that one of the Components(Sections in the inspector) is labeled Transform. This is telling the code to look at the gameobject that this script is attached tos' transform
        //then we use the Translate method on the transform to slide it along the ground at a speed established using the values we got above. You can hover 'Translate' with your mouse to
        //see what values it expects from you. In this case, it wants to know the value's for x,y,z movement. We don't want to move up and down w/ wasd so we leave y as 0.
        transform.Translate(horInput, 0, vertInput);
    }
}
