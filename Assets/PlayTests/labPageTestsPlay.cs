using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class labPageTests
    {
        public List<GameObject> compoundsList;
        // A Test behaves as an ordinary method
        [Test]
        public void labPageTestsExisting()
        {

            GameObject toTest = MonoBehaviour.Instantiate(Resources.Load<GameObject>("compoundListUI"));
            compoundSpawner comSpwn = GameObject.FindGameObjectWithTag("spawner").GetComponent<compoundSpawner>();

            compoundsList = comSpwn.compoundsList;
            int rnd = Random.Range(0, compoundsList.Count);
            GameObject compoundInList = compoundsList[rnd];
            TMP_InputField searchBar = GameObject.FindGameObjectWithTag("search").GetComponent<TMP_InputField>();
            searchBar.text = compoundInList.name;
            compoundButtonController found = GameObject.FindGameObjectWithTag("button").GetComponent<compoundButtonController>();

            Assert.AreSame(found.compound,compoundInList);
        }
        [UnityTest]
        public IEnumerator labPageTestsNonExisting()
        {
            GameObject toTest = MonoBehaviour.Instantiate(Resources.Load<GameObject>("compoundListUI"));
            GameObject spwn = GameObject.FindGameObjectWithTag("spawner");
            compoundSpawner comSpwn = spwn.GetComponent<compoundSpawner>();

            compoundsList = comSpwn.compoundsList;
            int rnd = Random.Range(0, compoundsList.Count);
            GameObject compoundInList = compoundsList[rnd];
            TMP_InputField searchBar = GameObject.FindGameObjectWithTag("search").GetComponent<TMP_InputField>();
            searchBar.text = compoundInList.name + "RANDOMSTRING";
            yield return new WaitForSeconds(1);
            Assert.IsTrue(spwn.transform.childCount == 0);
            yield return null;
        }



        [Test]
        public void labPageTestsPartialMatch()
        {
            GameObject toTest = MonoBehaviour.Instantiate(Resources.Load<GameObject>("compoundListUI"));
            GameObject spwn = GameObject.FindGameObjectWithTag("spawner");
            TMP_InputField searchBar = GameObject.FindGameObjectWithTag("search").GetComponent<TMP_InputField>();
            searchBar.text = "potassium";
            Assert.IsTrue(spwn.transform.childCount == 3);
        }
    }
}
