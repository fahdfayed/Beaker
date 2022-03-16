using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;

public class compoundButtonController : MonoBehaviour
{
    public GameObject compound;
    public TextMeshProUGUI cName;
    compoundController compCon;
    public Image img;

    public void Assign(GameObject c)
    {
        compound = c;
        char[] split = compound.name.ToCharArray();
        split = split.Take(12).ToArray();
        string cropped = (string.Join("", split));
        cName.text = cropped + "...";
        compCon = c.GetComponent<compoundController>();
        cName.color = Color.white;
        img.color = new Color(compCon.col.r,compCon.col.g,compCon.col.b,1);

        this.name = c.name + "Button";
    }
    public void Spawn()
    {
        GameObject comp = Instantiate(compound, Vector2.zero, Quaternion.identity);
        comp.SendMessage("setName", compound.name);
    }
}
