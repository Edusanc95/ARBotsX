using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class ManageGame : MonoBehaviour
{
    // Constants
    public static double short_distance = 0.12;
    public static double long_distance = 0.17;

    // Variables
    bool robots_are_on_screen = false;
    bool signal_is_on_screen = false;

    // Images
    public Sprite robot1_punch_image_neutral;
    public Sprite robot1_missile_image_neutral;

    public Sprite robot1_punch_image_pressed;
    public Sprite robot1_missile_image_pressed;

    public Sprite robot2_punch_image_neutral;
    public Sprite robot2_missile_image_neutral;

    public Sprite robot2_punch_image_pressed;
    public Sprite robot2_missile_image_pressed;

    public Sprite punch_image_disabled;
    public Sprite missile_image_disabled;

    private Dictionary<string, KeyCode> keys =
        new Dictionary<string, KeyCode>();

    GameObject Robot1;
    GameObject Robot2;
    GameObject Signal;

    GameObject Robot1PunchButton;
    GameObject Robot1MissileButton;

    GameObject Robot2PunchButton;
    GameObject Robot2MissileButton;

    // Start is called before the first frame update
    void Start()
    {
        Robot1 = this.transform.GetChild(1).gameObject;
        Robot2 = this.transform.GetChild(2).gameObject;
        Signal = this.transform.GetChild(3).gameObject;

        GameObject MobileButtons = this.transform.GetChild(4).gameObject;
        Robot1PunchButton = MobileButtons.transform.GetChild(0).gameObject;
        Robot1MissileButton = MobileButtons.transform.GetChild(1).gameObject;
        Robot2PunchButton = MobileButtons.transform.GetChild(2).gameObject;
        Robot2MissileButton = MobileButtons.transform.GetChild(3).gameObject;

        keys.Add("short_attack_robot1", KeyCode.A);
        keys.Add("long_attack_robot1", KeyCode.S);

        keys.Add("short_attack_robot2", KeyCode.Z);
        keys.Add("long_attack_robot2", KeyCode.X);

    }

    // Update is called once per frame
    void Update()   
    {

        double dist = Vector3.Distance(
            Robot1.GetComponent<ARTrackedObject>().transform.position,
            Robot2.GetComponent<ARTrackedObject>().transform.position);

        robots_are_on_screen = (
            Robot1.GetComponent<ARTrackedObject>().GetTrackable()
                  .Visible
            &&
            Robot2.GetComponent<ARTrackedObject>().GetTrackable()
                  .Visible
            );

        signal_is_on_screen = Signal.GetComponent<ARTrackedObject>()
            .GetTrackable().Visible;

        Debug.Log("Position of Robot1 " + Robot1.
            GetComponent<ARTrackedObject>().transform.position);

        Debug.Log("Position of Robot2 " + Robot2.
            GetComponent<ARTrackedObject>().transform.position);

        Debug.Log("Distance between the two: " + dist);

        if (dist <= short_distance && robots_are_on_screen && !signal_is_on_screen)
        {

            if (Input.GetKeyDown(keys["short_attack_robot1"]) ||
                CrossPlatformInputManager.GetButton("Punch1"))
            {
                if (Robot1.GetComponent<ManageStats>().ready)
                {
                    Robot2.GetComponent<ManageStats>().remaining_health
                        = Robot2.GetComponent<ManageStats>().remaining_health - 30;
                    Robot1.GetComponent<ManageStats>().restart_timer_attack();
                }
                Robot1PunchButton.GetComponent<Image>().sprite =
                robot1_punch_image_pressed;
            } else
            {
                Robot1PunchButton.GetComponent<Image>().sprite =
                robot1_punch_image_neutral;
            }

            if (Input.GetKeyDown(keys["short_attack_robot2"]) ||
                CrossPlatformInputManager.GetButton("Punch2"))
            {
                if (Robot2.GetComponent<ManageStats>().ready)
                {
                    Robot1.GetComponent<ManageStats>().remaining_health
                    = Robot1.GetComponent<ManageStats>().remaining_health - 30;
                    Robot2.GetComponent<ManageStats>().restart_timer_attack();
                }
                Robot2PunchButton.GetComponent<Image>().sprite =
                robot2_punch_image_pressed;
            } else
            {
                Robot2PunchButton.GetComponent<Image>().sprite =
                robot2_punch_image_neutral;
            }

        } else
        {
            Robot1PunchButton.GetComponent<Image>().sprite =
                punch_image_disabled;
            Robot2PunchButton.GetComponent<Image>().sprite =
                punch_image_disabled;
        }
        
        if (dist <= long_distance && robots_are_on_screen && !signal_is_on_screen)
        {
           

            if (Input.GetKeyDown(keys["long_attack_robot1"]) ||
                CrossPlatformInputManager.GetButton("Missile1"))
            {
                if (Robot1.GetComponent<ManageStats>().ready)
                {
                    Robot2.GetComponent<ManageStats>().remaining_health
                    = Robot2.GetComponent<ManageStats>().remaining_health - 15;
                    Robot1.GetComponent<ManageStats>().restart_timer_attack();
                }
                Robot1MissileButton.GetComponent<Image>().sprite =
                robot1_missile_image_pressed;
            } else
            {
                Robot1MissileButton.GetComponent<Image>().sprite =
                robot1_missile_image_neutral;
            }


            if (Input.GetKeyDown(keys["long_attack_robot2"]) ||
                CrossPlatformInputManager.GetButton("Missile2"))
            {
                if (Robot2.GetComponent<ManageStats>().ready)
                {
                    Robot1.GetComponent<ManageStats>().remaining_health
                    = Robot1.GetComponent<ManageStats>().remaining_health - 15;
                    Robot2.GetComponent<ManageStats>().restart_timer_attack();
                }
                Robot2MissileButton.GetComponent<Image>().sprite =
                robot2_missile_image_pressed;
            } else
            {
                Robot2MissileButton.GetComponent<Image>().sprite =
                robot2_missile_image_neutral;
            }
        } else
        {
            Robot1MissileButton.GetComponent<Image>().sprite =
                missile_image_disabled;
            Robot2MissileButton.GetComponent<Image>().sprite =
                missile_image_disabled;
        }
        
    }
}
