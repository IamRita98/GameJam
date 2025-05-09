using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamControl : MonoBehaviour
{ 
    //variables for mouse control
    public float mouseSens;
    public float smoothing;

    //Vector2's & vector3's, while commonly used to store variable that relate to locations on a matrix, map, or plane, are more simply just a way to store 2/3 numbers together.
    //So while you'll often see them used to store X,Y/,Z values, they can be used for any instance where something needs multiple values at once.
    private Vector2 mouseLook;
    private Vector2 smoothV2;

    //playerGO short for player Game Object, or, the player character. GameObject is a reference to ANY object in Unity. The player, the camera, an uninteractable banana asset,
    //even the object that is going to be holding our audio player, these can all be referenced through GameObject.
    private GameObject playerGO;

    private void Awake()
    {
        //The Start() and Awake() functions are both called before any update methods are called. Awake is specifically called as soon as the script is loaded for the first time.
        //Both of them are only ever called a single time, this makes them great for initializing variables, such as finding a reference to our GameObject playerGO.

        //Theres a few ways to find references to a GO. The easiest for a non-programmer is to make the variable above Public then in this script componenet attached to the gameobject this script
        //is on there will be an empty section for it. You can click and drag the game object you're referencing into that blank space to set the reference. The most common way to reference
        //a game object in code is:
        // playerGO = GameObject.FindGameObjectWithTag("ExampleTag"); Tags are set on a GameObject at the very top of the inspector, this is also where you set the physics layer.
        //However, in this case, our Camera is a child of our player GO in the hierarchy, so we can reference it in another way:
        playerGO = this.transform.parent.gameObject;
    }

    private void Update()
    {
        //Temp variable that we re-fetch every frame when Update is called to reflect how the mouse is moving.
        //Note that we have to declare a "new" vector2 anytime you want to declare a vector2 variable. You would not use 'new' if it was an pre-defined vector2, such as 
        //vector2.Up which is defined as (0,1) or 0 in the x position, and positive 1 in the y position.
        Vector2 md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        //I'm not going to lie, idrk 100% what's going on here, I found this script online because I've never done first person controls. I believe whats happening
        //is that we're applying the sens and smoothing to our previous values so that the movement is at a capped/regulted speed regrdless of how fst the mouse moves. So our previous md var
        //are being scaled to our sens and smoothing values
        md = Vector2.Scale(md, new Vector2(mouseSens * smoothing, mouseSens * smoothing));

        //Interpolating between the camera's rotation and our actual mouse movements. This is where the smoothing is actually applied to take out the jaggedness
        //Interpolation is the act of taking a value, such as the distance between where we are currently look and where we should be looking after the mouse movement has been input,
        //as distributing that values out over a set time-- So instead of going from x=1 to x=20 instantly, we make it go something like x+2 every .2 seconds until x=20. Just as an example
        //Lerp is short for Linear Interpretation, meaning that the value is changing at a set rate, as opposed to dynamic interpretation where something might start slow then accelerate
        //until it reaches it's destination.
        smoothV2.x = Mathf.Lerp(smoothV2.x, md.x, 1f / smoothing);
        smoothV2.y = Mathf.Lerp(smoothV2.y, md.y, 1f / smoothing);

        //Apply our Lerp'd value to the mouseLook variable for use below
        mouseLook += smoothV2;

        //Finally, we apply all of our variable/Lerping to rotate the camera as we move our mouse. Not entirely sure why it's -mouse look, but this is giving us the angle of rotation for the cam
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);

        //Then we apply that rotation to the player as well. In the Unity editor we have the Y rotation locked so we shouldn't have the player rotating around off of the ground(hopefully)
        playerGO.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, playerGO.transform.up);
    }
}
