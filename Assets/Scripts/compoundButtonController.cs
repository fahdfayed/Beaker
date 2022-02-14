using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class compoundButtonController : MonoBehaviour
{
    public GameObject compound;
    public TextMeshProUGUI cName;

    public void Assign(GameObject c)
    {
        compound = c;
        char[] split = compound.name.ToCharArray();
        split = split.Take(7).ToArray();
        string cropped = (string.Join("", split));
        cName.text = cropped;
    }
    public void Spawn()
    {
        Instantiate(compound, Vector2.zero, Quaternion.identity);
    }
}
