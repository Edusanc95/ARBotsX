using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;


public class GetDistance : MonoBehaviour
{
    public Transform ARMarkerHiro;
    public Transform ARMarkerKanji;
    public double dist;
    Camera camera;

    private static double twodDistance(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
    }

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPosHiro = camera.WorldToScreenPoint(ARMarkerHiro.position);
        Debug.Log("hiro is " + screenPosHiro.x + " pixels from the left");
        Debug.Log("hiro is " + screenPosHiro.y + " pixels from the bottom ");

        Vector3 screenPosKanji = camera.WorldToScreenPoint(ARMarkerKanji .position);
        Debug.Log("kanji is " + screenPosKanji.x + " pixels from the left");
        Debug.Log("kanji is " + screenPosKanji.y + " pixels from the bottom ");

        dist = twodDistance(screenPosHiro.x, screenPosHiro.y,
            screenPosKanji.x, screenPosKanji.y);

        Debug.Log("Distance between the two: " + dist);
    }
}
