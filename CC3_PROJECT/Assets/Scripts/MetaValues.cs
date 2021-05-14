using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//For tracking meta information
public class MetaValues : MonoBehaviour
{
    public static MetaValues instance;
    public static int kills = 0;
    public Text textKills;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        kills = 0;
    }

    private void Update()
    {
        textKills.text = kills.ToString();
    }

    public void SetText(string _text)
    {
        textKills.text = _text;
    }
}
