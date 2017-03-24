using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerpLight : MonoBehaviour {

    private float black;
    private float red;

    private Light pointLight;

    [SerializeField]
    private float maxDuration = 0.1f;

    // Use this for initialization
    void Start()
    {

        //set black to 0 since we want it to be normal color initially
        black = 0.0f;

        //set red to 255 since we want it to go all the way to red
        red = 75.0f;

        //get component light of the gameobject
        pointLight = GetComponent<Light>();

        //ensure that maxDuration isn't 0 because if so, it will cause an infinite loop within the coroutine
        if (maxDuration != 0)
        {
            //start the lerping coroutine
            StartCoroutine(LerpPlaneRandomly());
        }
    }

    IEnumerator LerpPlaneRandomly()
    {

        yield return new WaitForSeconds(45.0f);

        //while true so that it always runs
        while (true)
        {

            //ensure that maxDuration isn't 0 because if so, it will cause an infinite loop within the coroutine
            if (maxDuration != 0)
            {
              
                //for (float i = 0; i < maxDuration; i += Time.deltaTime) lerp from initial position to final in span of maxDuration
                for (float i = 0; i < maxDuration; i += Time.deltaTime)
                {

                    //lerp from initial position to the earthquake position at i / maxDuration
                    if (maxDuration != 0)
                    {
                        float redValue = Mathf.Lerp(black, red, i / maxDuration);

                        pointLight.color = new Color(redValue, 0, 0);

                        //yield return null so that you can move to the next frame with deltaframe (time since the last frame) and we can actually see it happen
                        yield return null;
                    }


                }

                //snap the latest position of the plane to the final earthquake position to finish off the lerp because its likely that it ended exactly at the earthquakePosition
                pointLight.color = new Color(red, 0, 0);

                //for (float j = 0; j < maxDuration; j += Time.deltaTime) lerp from earthquake position to initial in span of maxDuration
                for (float j = 0; j < maxDuration; j += Time.deltaTime)
                {

                    if (maxDuration != 0)
                    {
                        float blackValue = Mathf.Lerp(red, black, j / maxDuration);

                        pointLight.color = new Color(blackValue, 0, 0);

                        //yield return null so that you can move to the next frame with deltaframe (time since the last frame) and we can actually see it happen
                        yield return null;
                    }

                }

                pointLight.color = new Color(black, 0, 0);
            }

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
