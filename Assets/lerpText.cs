using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lerpText : MonoBehaviour {

    private float white;
    private float red;

    private Text textField;

    [SerializeField]
    private float maxDuration = 0.1f;

    // Use this for initialization
    void Start()
    {

        //set black to 0 since we want it to be normal color initially
        white = 0.0f;

        //set red to 255 since we want it to go all the way to red
        red = 50.0f;

        //get component light of the gameobject
        textField = GetComponent<Text>();

        //ensure that maxDuration isn't 0 because if so, it will cause an infinite loop within the coroutine
        if (maxDuration != 0)
        {
            //start the lerping coroutine
            StartCoroutine(LerpColorRandomly());
        }
    }

    IEnumerator LerpColorRandomly()
    {

        yield return new WaitForSeconds(15.0f);

        textField.enabled = true;

        /*
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
                        float redValue = Mathf.Lerp(white, red, i / maxDuration);

                        textField.color = new Color(redValue, 0, 0);

                        //yield return null so that you can move to the next frame with deltaframe (time since the last frame) and we can actually see it happen
                        yield return null;
                    }


                }

                //snap the latest position of the plane to the final earthquake position to finish off the lerp because its likely that it ended exactly at the earthquakePosition
                textField.color = new Color(red, 0, 0);

                //for (float j = 0; j < maxDuration; j += Time.deltaTime) lerp from earthquake position to initial in span of maxDuration
                for (float j = 0; j < maxDuration; j += Time.deltaTime)
                {

                    if (maxDuration != 0)
                    {
                        float blackValue = Mathf.Lerp(red, white, j / maxDuration);

                        textField.color = new Color(blackValue, 0, 0);

                        //yield return null so that you can move to the next frame with deltaframe (time since the last frame) and we can actually see it happen
                        yield return null;
                    }

                }

                textField.color = new Color(white, 0, 0);
            }

        }*/

    }

    // Update is called once per frame
    void Update()
    {

    }
}
