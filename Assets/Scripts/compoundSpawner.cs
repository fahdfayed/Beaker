using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compoundSpawner : MonoBehaviour
{
    public List<GameObject> compoundsList;
    public GameObject listAdder;
    public GameObject button;

    public void Start() {
        makeGrid();
    }
    void makeGrid()
    {
        int listSize = compoundsList.Count;
        int count = 0;
        for (int i = 0; i < listSize; i++)
        {
            GameObject elem = Instantiate(button, listAdder.transform.position, Quaternion.identity);
            elem.transform.SetParent(this.gameObject.transform, false);
            elem.transform.position = listAdder.transform.position;
            elem.SendMessage("Assign", compoundsList[i]);

            count += 1;
            if (count == 4)
            {
                count = 0;
                listAdder.transform.localPosition = new Vector2(listAdder.transform.localPosition.x - 225, listAdder.transform.localPosition.y - 75);
                continue;
            }
            listAdder.transform.localPosition = new Vector2(listAdder.transform.localPosition.x + 75, listAdder.transform.localPosition.y);
        }
    }
}
