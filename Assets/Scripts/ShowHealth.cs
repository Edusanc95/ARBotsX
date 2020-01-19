using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowHealth : MonoBehaviour
{
   
    void Update()
    {
        int remaining_health = GetComponentInParent<ManageStats>().remaining_health;
        // Set the text of the attached Text mesh
        GetComponent<TextMesh>().text = "Health: "+remaining_health;
    }
}
            