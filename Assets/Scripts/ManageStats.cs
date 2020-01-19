using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageStats : MonoBehaviour
{
    //Constants
    static float cooldown_time = 3;

    //Variables
    public int remaining_health;
    public bool ready;
    public bool eliminated = false;
    float robot_time_since_last_attack = cooldown_time;

    public void restart_timer_attack()
    {
        robot_time_since_last_attack = 0;
    }

    void Update()
    {
        if (robot_time_since_last_attack >= cooldown_time)
        {
            ready = true;
        }
        else
        {
            ready = false;
        }

        if (GetComponentInParent<ManageStats>().remaining_health <= 0)
        {
            eliminated = true;
            ready = false;
        }
        robot_time_since_last_attack = robot_time_since_last_attack
                + Time.deltaTime;
    }
}