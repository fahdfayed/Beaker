using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class compoundSpawner : MonoBehaviour
{
    public List<GameObject> compoundsList;
    public List<GameObject> filteredList;
    public GameObject listAdder;
    public GameObject button;
    public GameObject search;

    public GameObject[] buttons;
    public ScrollRect scroll;

    public void Start()
    {
        makeGrid(compoundsList);
        scroll = GameObject.FindGameObjectWithTag("scroll").GetComponent<ScrollRect>();
    }
    void makeGrid(List<GameObject> compounds)
    {
        int listSize = compounds.Count;
        int count = 0;
        for (int i = 0; i < listSize; i++)
        {
            GameObject elem = Instantiate(button, listAdder.transform.position, Quaternion.identity);
            elem.transform.SetParent(this.gameObject.transform, false);
            elem.transform.position = listAdder.transform.position;
            elem.SendMessage("Assign", compounds[i]);

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

    void Search()
    {
        string searchText = search.GetComponent<TMP_InputField>().text;
        for (int i = 0; i < compoundsList.Count; i++)
        {
            if (compoundsList[i].name.Contains(searchText)) {
                filteredList.Add(compoundsList[i]);
            }
        }
        buttons = GameObject.FindGameObjectsWithTag ("button");
        foreach (GameObject child in buttons) {
            GameObject.Destroy(child.gameObject);    
        }
        listAdder.transform.localPosition = (new Vector2(-115, 40));
        makeGrid(filteredList);
        filteredList.Clear();
        if (this.transform.childCount < 8)
        {
            //scroll.enabled = false;
        }
        else
        {
            //scroll.enabled = true;
        }
    }
}
