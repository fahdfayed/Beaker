using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compoundController : MonoBehaviour
{

    public bool explosive;
    public bool flammable;
    public bool oxidizing;
    public bool gasesUnderPressure;
    public bool corrosive;
    public bool severeAcuteToxicity;
    public bool toxicityAndIrritation;
    public bool healthHazard;
    public bool environmentalHazard;

    public GameObject flammableSprite;
    public GameObject toxicityAndIrritationSprite;
    public GameObject healthHazardSprite;
    public GameObject environmentalHazardSprite;

    private Plane dragPlane;
    private Vector3 offset;
    private Camera myMainCamera;
    private Vector3 curPos;
    private bool dragging = false;



    // Start is called before the first frame update
    void Awake()
    {
        myMainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        dragPlane = new Plane(myMainCamera.transform.forward, transform.position);
        Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);

        float planeDist;
        dragPlane.Raycast(camRay, out planeDist);
        offset = transform.position - camRay.GetPoint(planeDist);
    }
    void OnMouseDrag()
    {
        Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);
        curPos = transform.position;
        float planeDist;
        dragPlane.Raycast(camRay, out planeDist);
        transform.position = camRay.GetPoint(planeDist) + offset;

        if (curPos != transform.position)
        {
            dragging = true;
        }

    }


    // Update is called once per frame
    void Update()
    {
        if (flammable)
        {
            flammableSprite.SetActive(true);
        }
        if (toxicityAndIrritation)
        {
            toxicityAndIrritationSprite.SetActive(true);
        }
        if (healthHazard)
        {
            healthHazardSprite.SetActive(true);
        }
        if (environmentalHazard)
        {
            environmentalHazardSprite.SetActive(true);
        }
    }
}
