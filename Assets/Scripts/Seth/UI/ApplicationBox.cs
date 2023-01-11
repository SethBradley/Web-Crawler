using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ApplicationBox : MonoBehaviour
{
    public TMP_Text titleText;
    void Awake()
    {
        titleText = transform.Find("Title Text").GetComponent<TMP_Text>();
    }

    public void SetTitle(string title) => titleText.text = title;
}
