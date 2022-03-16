using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

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

    public GameObject explosiveSprite;
    public GameObject flammableSprite;
    public GameObject oxidizingSprite;
    public GameObject gasesUnderPressureSprite;
    public GameObject corrosiveSprite;
    public GameObject severeAcuteToxicitySprite;
    public GameObject toxicityAndIrritationSprite;
    public GameObject healthHazardSprite;
    public GameObject environmentalHazardSprite;

    private Plane dragPlane;
    private Vector3 offset;
    private Camera myMainCamera;
    private Vector3 curPos;
    private bool dragging = false;

    private int hazardCount;
    public List<GameObject> activeHazards;
    public List<GameObject> currentHazards;

    public Color col;
    private bool info = false;

    private TMP_Text compName;
    private TMP_Text compStruct;
    private TMP_Text compWeight;
    public string weight;
    public string formula;

    private GameObject compStructObj;
    private GameObject compWeightObj;

    // Start is called before the first frame update
    void Awake()
    {
        myMainCamera = Camera.main;
        this.GetComponent<SpriteRenderer>().color = new Color(col.r, col.g, col.b, 1);
        compName = this.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();

        compStructObj = this.transform.GetChild(1).gameObject;
        compWeightObj = this.transform.GetChild(2).gameObject;
        compStructObj.SetActive(false);
        compWeightObj.SetActive(false);

        compStruct = compStructObj.GetComponent<TMP_Text>();
        compWeight = compWeightObj.GetComponent<TMP_Text>();
       

        Hazards();

        if (weight != "") {
            compWeight.text = weight;
            compWeight.color = new Color(col.r, col.g, col.b, 1); 
        }
        if (weight != "")
        {
            compStruct.text = formula;
            compStruct.color = new Color(col.r, col.g, col.b, 1);
        }

    }

    void setName(string toSet)
    {
        char[] split = toSet.ToCharArray();
        split = split.Take(12).ToArray();
        string cropped = (string.Join("", split));
        if (cropped.Length >= 12)
        {
            compName.text = cropped + "...";
        }
        else 
        {
            compName.text = cropped;
        }
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
    private void OnMouseUp()
    {
        if (!dragging)
        {
            if (!info)
            {
                info = true;
                for (int i = 0; i < hazardCount; i++)
                {
                    currentHazards[i].SetActive(true);  
                }
                compStructObj.SetActive(true);
                compWeightObj.SetActive(true);
            }
            else if (info)
            {
                info = false;
                for (int i = 0; i < hazardCount; i++)
                {
                    currentHazards[i].SetActive(false);
                }
                compStructObj.SetActive(false);
                compWeightObj.SetActive(false);
            }
        }
        dragging = false;
    }


    void Hazards()
    {
        if (explosive)
        {
            activeHazards.Add(explosiveSprite);
            hazardCount += 1;
        }
        if (flammable)
        {
            activeHazards.Add(flammableSprite);
            hazardCount += 1;
        }
        if (oxidizing)
        {
            activeHazards.Add(oxidizingSprite);
            hazardCount += 1;
        }
        if (gasesUnderPressure)
        {
            activeHazards.Add(gasesUnderPressureSprite);
            hazardCount += 1;
        }
        if (corrosive)
        {
            activeHazards.Add(corrosiveSprite);
            hazardCount += 1;
        }
        if (severeAcuteToxicity)
        {
            activeHazards.Add(severeAcuteToxicitySprite);
            hazardCount += 1;
        }
        if (toxicityAndIrritation)
        {
            activeHazards.Add(toxicityAndIrritationSprite);
            hazardCount += 1;
        }
        if (healthHazard)
        {
            activeHazards.Add(healthHazardSprite);
            hazardCount += 1;
        }
        if (environmentalHazard)
        {
            activeHazards.Add(environmentalHazardSprite);
            hazardCount += 1;
        }


        if (hazardCount == 1)
        {
            GameObject haz1 = Instantiate(activeHazards[1], new Vector2(this.transform.position.x - 0.75f, 0), Quaternion.identity);
            haz1.transform.parent = this.transform;
            currentHazards[0] = haz1;
        }
        else if (hazardCount == 2) 
        {
            GameObject haz1 = Instantiate(activeHazards[1], new Vector2(this.transform.position.x - 0.75f, 0.25f), Quaternion.identity);
            haz1.transform.parent = this.transform;
            GameObject haz2 = Instantiate(activeHazards[2], new Vector2(this.transform.position.x - 0.75f, -0.25f), Quaternion.identity);
            haz2.transform.parent = this.transform;
            currentHazards[0] = haz1;
            currentHazards[1] = haz2;
        }
        else if (hazardCount == 3)
        {
            GameObject haz1 = Instantiate(activeHazards[1], new Vector2(this.transform.position.x - 0.75f, 0.5f), Quaternion.identity);
            haz1.transform.parent = this.transform;
            GameObject haz2 = Instantiate(activeHazards[2], new Vector2(this.transform.position.x - 0.75f, 0), Quaternion.identity);
            haz2.transform.parent = this.transform;
            GameObject haz3 = Instantiate(activeHazards[3], new Vector2(this.transform.position.x - 0.75f, -0.5f), Quaternion.identity);
            haz3.transform.parent = this.transform;
            currentHazards[0] = haz1;
            currentHazards[1] = haz2;
            currentHazards[2] = haz3;
        }
        else if (hazardCount == 4)
        {
            GameObject haz1 = Instantiate(activeHazards[1], new Vector2(this.transform.position.x - 0.75f, 0.75f), Quaternion.identity);
            haz1.transform.parent = this.transform;
            GameObject haz2 = Instantiate(activeHazards[2], new Vector2(this.transform.position.x - 0.75f, 0.25f), Quaternion.identity);
            haz2.transform.parent = this.transform;
            GameObject haz3 = Instantiate(activeHazards[3], new Vector2(this.transform.position.x - 0.75f, -0.25f), Quaternion.identity);
            haz3.transform.parent = this.transform;
            GameObject haz4 = Instantiate(activeHazards[4], new Vector2(this.transform.position.x - 0.75f, -0.75f), Quaternion.identity);
            haz4.transform.parent = this.transform;
            currentHazards[0] = haz1;
            currentHazards[1] = haz2;
            currentHazards[2] = haz3;
            currentHazards[3] = haz4;
        }
        else if (hazardCount == 5)
        {
            GameObject haz1 = Instantiate(activeHazards[1], new Vector2(this.transform.position.x - 0.75f, 1), Quaternion.identity);
            haz1.transform.parent = this.transform;
            GameObject haz2 = Instantiate(activeHazards[2], new Vector2(this.transform.position.x - 0.75f, 0.5f), Quaternion.identity);
            haz2.transform.parent = this.transform;
            GameObject haz3 = Instantiate(activeHazards[3], new Vector2(this.transform.position.x - 0.75f, 0), Quaternion.identity);
            haz3.transform.parent = this.transform;
            GameObject haz4 = Instantiate(activeHazards[4], new Vector2(this.transform.position.x - 0.75f, -0.5f), Quaternion.identity);
            haz4.transform.parent = this.transform;
            GameObject haz5 = Instantiate(activeHazards[5], new Vector2(this.transform.position.x - 0.75f, -1), Quaternion.identity);
            haz5.transform.parent = this.transform;
            currentHazards[0] = haz1;
            currentHazards[1] = haz2;
            currentHazards[2] = haz3;
            currentHazards[3] = haz4;
            currentHazards[4] = haz5;
        }
        else if (hazardCount == 6)
        {
            GameObject haz1 = Instantiate(activeHazards[1], new Vector2(this.transform.position.x - 0.75f, 1.25f), Quaternion.identity);
            haz1.transform.parent = this.transform;
            GameObject haz2 = Instantiate(activeHazards[2], new Vector2(this.transform.position.x - 0.75f, 0.75f), Quaternion.identity);
            haz2.transform.parent = this.transform;
            GameObject haz3 = Instantiate(activeHazards[3], new Vector2(this.transform.position.x - 0.75f, 0.25f), Quaternion.identity);
            haz3.transform.parent = this.transform;
            GameObject haz4 = Instantiate(activeHazards[4], new Vector2(this.transform.position.x - 0.75f, -0.25f), Quaternion.identity);
            haz4.transform.parent = this.transform;
            GameObject haz5 = Instantiate(activeHazards[5], new Vector2(this.transform.position.x - 0.75f, -0.75f), Quaternion.identity);
            haz5.transform.parent = this.transform;
            GameObject haz6 = Instantiate(activeHazards[6], new Vector2(this.transform.position.x - 0.75f, -1.25f), Quaternion.identity);
            haz6.transform.parent = this.transform;
            currentHazards[0] = haz1;
            currentHazards[1] = haz2;
            currentHazards[2] = haz3;
            currentHazards[3] = haz4;
            currentHazards[4] = haz5;
            currentHazards[5] = haz6;
        }
        else if (hazardCount == 7)
        {
            GameObject haz1 = Instantiate(activeHazards[1], new Vector2(this.transform.position.x - 0.75f, 1.5f), Quaternion.identity);
            haz1.transform.parent = this.transform;
            GameObject haz2 = Instantiate(activeHazards[2], new Vector2(this.transform.position.x - 0.75f, 1), Quaternion.identity);
            haz2.transform.parent = this.transform;
            GameObject haz3 = Instantiate(activeHazards[3], new Vector2(this.transform.position.x - 0.75f, 0.5f), Quaternion.identity);
            haz3.transform.parent = this.transform;
            GameObject haz4 = Instantiate(activeHazards[4], new Vector2(this.transform.position.x - 0.75f, 0), Quaternion.identity);
            haz4.transform.parent = this.transform;
            GameObject haz5 = Instantiate(activeHazards[5], new Vector2(this.transform.position.x - 0.75f, -0.5f), Quaternion.identity);
            haz5.transform.parent = this.transform;
            GameObject haz6 = Instantiate(activeHazards[6], new Vector2(this.transform.position.x - 0.75f, -1), Quaternion.identity);
            haz6.transform.parent = this.transform;
            GameObject haz7 = Instantiate(activeHazards[7], new Vector2(this.transform.position.x - 0.75f, -1.5f), Quaternion.identity);
            haz7.transform.parent = this.transform;
            currentHazards[0] = haz1;
            currentHazards[1] = haz2;
            currentHazards[2] = haz3;
            currentHazards[3] = haz4;
            currentHazards[4] = haz5;
            currentHazards[5] = haz6;
            currentHazards[6] = haz7;
        }
        else if (hazardCount == 8)
        {
            GameObject haz1 = Instantiate(activeHazards[1], new Vector2(this.transform.position.x - 0.75f, 1.75f), Quaternion.identity);
            haz1.transform.parent = this.transform;
            GameObject haz2 = Instantiate(activeHazards[2], new Vector2(this.transform.position.x - 0.75f, 1.25f), Quaternion.identity);
            haz2.transform.parent = this.transform;
            GameObject haz3 = Instantiate(activeHazards[3], new Vector2(this.transform.position.x - 0.75f, 0.75f), Quaternion.identity);
            haz3.transform.parent = this.transform;
            GameObject haz4 = Instantiate(activeHazards[4], new Vector2(this.transform.position.x - 0.75f, 0.25f), Quaternion.identity);
            haz4.transform.parent = this.transform;
            GameObject haz5 = Instantiate(activeHazards[5], new Vector2(this.transform.position.x - 0.75f, -0.25f), Quaternion.identity);
            haz5.transform.parent = this.transform;
            GameObject haz6 = Instantiate(activeHazards[6], new Vector2(this.transform.position.x - 0.75f, -0.75f), Quaternion.identity);
            haz6.transform.parent = this.transform;
            GameObject haz7 = Instantiate(activeHazards[7], new Vector2(this.transform.position.x - 0.75f, -1.25f), Quaternion.identity);
            haz7.transform.parent = this.transform;
            GameObject haz8 = Instantiate(activeHazards[8], new Vector2(this.transform.position.x - 0.75f, -1.75f), Quaternion.identity);
            haz8.transform.parent = this.transform;
            currentHazards[0] = haz1;
            currentHazards[1] = haz2;
            currentHazards[2] = haz3;
            currentHazards[3] = haz4;
            currentHazards[4] = haz5;
            currentHazards[5] = haz6;
            currentHazards[6] = haz7;
            currentHazards[7] = haz8;
        }
        else if (hazardCount == 9)
        {
            GameObject haz1 = Instantiate(activeHazards[1], new Vector2(this.transform.position.x - 0.75f, 2), Quaternion.identity);
            haz1.transform.parent = this.transform;
            GameObject haz2 = Instantiate(activeHazards[2], new Vector2(this.transform.position.x - 0.75f, 1.5f), Quaternion.identity);
            haz2.transform.parent = this.transform;
            GameObject haz3 = Instantiate(activeHazards[3], new Vector2(this.transform.position.x - 0.75f, 1), Quaternion.identity);
            haz3.transform.parent = this.transform;
            GameObject haz4 = Instantiate(activeHazards[4], new Vector2(this.transform.position.x - 0.75f, 0.5f), Quaternion.identity);
            haz4.transform.parent = this.transform;
            GameObject haz5 = Instantiate(activeHazards[5], new Vector2(this.transform.position.x - 0.75f, 0), Quaternion.identity);
            haz5.transform.parent = this.transform;
            GameObject haz6 = Instantiate(activeHazards[6], new Vector2(this.transform.position.x - 0.75f, -0.5f), Quaternion.identity);
            haz6.transform.parent = this.transform;
            GameObject haz7 = Instantiate(activeHazards[7], new Vector2(this.transform.position.x - 0.75f, -1), Quaternion.identity);
            haz7.transform.parent = this.transform;
            GameObject haz8 = Instantiate(activeHazards[8], new Vector2(this.transform.position.x - 0.75f, -1.5f), Quaternion.identity);
            haz8.transform.parent = this.transform;
            GameObject haz9 = Instantiate(activeHazards[9], new Vector2(this.transform.position.x - 0.75f, -2), Quaternion.identity);
            haz9.transform.parent = this.transform;
            currentHazards[0] = haz1;
            currentHazards[1] = haz2;
            currentHazards[2] = haz3;
            currentHazards[3] = haz4;
            currentHazards[4] = haz5;
            currentHazards[5] = haz6;
            currentHazards[6] = haz7;
            currentHazards[7] = haz8;
            currentHazards[8] = haz9;
        }
        for (int i = 0; i < hazardCount; i++)
        {
           currentHazards[i].SetActive(false);
        }

    }
    void shouldDestroy()
    {
        if (!dragging)
        {
            Destroy(this.gameObject);
        }

    }
}
