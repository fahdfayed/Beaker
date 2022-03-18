using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mixerManager : MonoBehaviour
{
    public int count;
    public Animator anim;
    public bool appeared;
    public GameObject left;
    public GameObject right;
    private compoundController compL;
    private compoundController compR;

    public GameObject noText;

    private void Awake()
    {
        noText = GameObject.FindGameObjectWithTag("invalid");
    }

    void newObjLeft(GameObject compound) 
    {
        count += 1;
        left = compound;
        if(count == 2)
        {
            appeared = true;
            anim.SetTrigger("appear");
            compL = left.GetComponent<compoundController>();
        }
    }
    void newObjRight(GameObject compound)
    {
        count += 1;
        right = compound;
        if (count == 2)
        {
            appeared = true;
            anim.SetTrigger("appear");
            compR = right.GetComponent<compoundController>();
        }
    }

    void objExit()
    {
        count -= 1;
        if (count != 2)
        {
            if (appeared)
            {
                anim.SetTrigger("disappear");
                appeared = false;
            }
        }
    }

    void combine()
    {
        if (count == 2)
        {
            left.SendMessage("shrink");
            right.SendMessage("shrink");

            if (compL.reactions.Contains(right))
            {
                if (compR.reactions.Contains(left))
                {
                    //mix
                }
            }
            else
            {
                StartCoroutine(noReaction());
            }
        }
    }

    IEnumerator noReaction()
    {

        if (noText.activeInHierarchy == false)
        {
            noText.SetActive(true);
        }
        noText.transform.position = new Vector2(0,noText.transform.position.y);
        yield return new WaitForSeconds(1f);
        noText.SetActive(false);
        yield return null;
    }
}
