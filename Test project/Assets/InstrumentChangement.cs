using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InstrumentChangement : MonoBehaviour
{
    public DrumKit Drums;
    public XylophoneInitializer Xylophone;

    private int PreviousInstrument = 0;
    private TMP_Dropdown DropDown;

    private void Start()
    {
        DropDown = GetComponent<TMP_Dropdown>();
    }

    public void ChangeInstrument()
    {
        if(DropDown.value != PreviousInstrument)
        {
            PreviousInstrument = DropDown.value;
            if(PreviousInstrument == 0)
            {
                Xylophone.Hide();
                Xylophone.gameObject.SetActive(false);
                Drums.OnInstrumentChangeToDrumKit();
            }
            else
            {
                Drums.Hide();
                Xylophone.gameObject.SetActive(true);
                Xylophone.OnInstrumentChangeToXylophone();
            }
        }
    }
}
