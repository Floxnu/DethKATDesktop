using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatTimer : MonoBehaviour
{
    //sets up variables, floats and a list.
    bool timing = false;
    bool recording = false;

    List<float> beats = new List<float>();

    int listNumber = 0;

    float time = 0;

    float total;

    string list = string.Empty;

    //Starts recording values

    private void Start()
    {
        recording = true;

    }


    private void Update()
    {
        //Alternates between recording the time and storing it in the list of times.
        if(timing == false && recording == true && Input.GetKeyDown(KeyCode.Space))
        {
            timing = true;
        } else if (timing == true && recording == true && Input.GetKeyDown(KeyCode.Space))

        {
            print(time);
            timing = false;
            total += time;
            beats.Add(time);
            time = 0;
            ++listNumber;
            
        }

        if (timing == true)
        {
            time += Time.deltaTime;
        }

        //prints the list of beat times.
        if (Input.GetKeyDown(KeyCode.P))
        {

            foreach (var beat in beats)
            {
                
                list += beat + ", ";
            }
            print("Beat List");
            print(list);
        }
    }

}
