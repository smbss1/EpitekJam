using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuccessContent : MonoBehaviour
{
    public Text title;
    public Text description;
    
    public void MakeDetailSuccess(string title, string description)
    {
        this.title.text = title;
        this.description.text = description;
    }
}
