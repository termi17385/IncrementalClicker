using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSaveAndLoad : MonoBehaviour
{
    [SerializeField]
    private bool canSave;
    [SerializeField]
    private GameObject floppyDisk;

    private void Start()
    {
        canSave = false;
        floppyDisk.SetActive(false);
    }

    private void Update()
    {
        AutoSave();
    }

    private void AutoSave()
    {
        if (canSave == false)
        {
            StartCoroutine(Save());
            canSave = true;
        }
    }


    IEnumerator Save()
    {
        SaveSystem.SaveGame();
        floppyDisk.SetActive(true);
        yield return new WaitForSeconds(10);
        floppyDisk.SetActive(false);
        yield return new WaitForSeconds(300);
        canSave = false;
    }
}
