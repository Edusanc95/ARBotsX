using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowStatus : MonoBehaviour
{

    void Update()
    {
        bool ready = GetComponentInParent<ManageStats>().ready;
        bool player_eliminated = GetComponentInParent<ManageStats>().eliminated;
      

        // Set the text of the attached Text mesh
        if  (player_eliminated)
        {
            GetComponent<TextMesh>().text = "Destroyed";
        }
        else if (ready)
        {
            GetComponent<TextMesh>().text = "Ready!";
        }
        else
        {
            GetComponent<TextMesh>().text = "Charging...";
        }
        
    }
}
