using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakePlane : MonoBehaviour {

    private Vector3 initialPosition;
    private Vector3 earthquakePosition;

    private float randomDistanceX;
    private float randomDistanceY;
    private float randomDistanceZ;

    public float maxOffset = 0.1f;

    public float maxDuration = 0.1f;

    public float shakeDelay = 45.0f;

    // Use this for initialization
    void Start () {

        //set the initialPosition so we can always make the plane go back to the start
        initialPosition = transform.position;

        //ensure that maxDuration isn't 0 because if so, it will cause an infinite loop within the coroutine
        if (maxDuration != 0)
        {
            //start the lerping coroutine
            StartCoroutine(LerpPlaneRandomly());
        }
    }

    IEnumerator LerpPlaneRandomly()
    {

        yield return new WaitForSeconds(shakeDelay);

        //while true so that it always runs
        while (true)
        {

            

            //ensure that maxDuration isn't 0 because if so, it will cause an infinite loop within the coroutine
            if (maxDuration != 0)
            {

                //get a random value for X
                randomDistanceX = Random.Range(-maxOffset, maxOffset);

                //get a random value for Y
                randomDistanceY = Random.Range(-maxOffset, maxOffset);

                //get a random value for Z
                randomDistanceZ = Random.Range(-maxOffset, maxOffset);

                //set earthquakePosition = new Vector(initialPosition.x + X, initialPosition.y + Y, initialPosition.z + Z);
                earthquakePosition = new Vector3(initialPosition.x + randomDistanceX, initialPosition.y + randomDistanceY, initialPosition.z + randomDistanceZ);

                //for (float i = 0; i < maxDuration; i += Time.deltaTime) lerp from initial position to final in span of maxDuration
                for (float i = 0; i < maxDuration; i += Time.deltaTime)
                {

                    //lerp from initial position to the earthquake position at i / maxDuration
                    if (maxDuration != 0)
                    {
                        Vector3 newPosition = Vector3.Lerp(initialPosition, earthquakePosition, i / maxDuration);

                        //sets the position of the plane to the new lerped position
                        transform.position = newPosition;

                        //yield return null so that you can move to the next frame with deltaframe (time since the last frame) and we can actually see it happen
                        yield return null;
                    }
                    

                }

                //snap the latest position of the plane to the final earthquake position to finish off the lerp because its likely that it ended exactly at the earthquakePosition
                transform.position = earthquakePosition;

                //for (float j = 0; j < maxDuration; j += Time.deltaTime) lerp from earthquake position to initial in span of maxDuration
                for (float j = 0; j < maxDuration; j += Time.deltaTime)
                {

                    if (maxDuration != 0)
                    {
                        //lerp from earthquake position to the initial position at i / maxDuration
                        Vector3 newPosition = Vector3.Lerp(earthquakePosition, initialPosition, j / maxDuration);

                        //yield return null so that you can move to the next frame with deltaframe (time since the last frame) and we can actually see it happen
                        transform.position = newPosition;

                        //yield return null so that you can move to the next frame with deltaframe (time since the last frame) and we can actually see it happen
                        yield return null;
                    }
                    
                }

                //snap the latest position of the plane to the final earthquake position to finish off the lerp because its likely that it ended exactly at the earthquakePosition
                transform.position = initialPosition;
            }

        }

    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}
}
