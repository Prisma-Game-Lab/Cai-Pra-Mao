using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSlider : MonoBehaviour
{
    [SerializeField] private AudioConfig _ac;
    [SerializeField] private Slider s;

    // Start is called before the first frame update
    void Start()
    {
        if (s != null)
        {
            _ac = FindObjectOfType<AudioConfig>();
            _ac.volumeSlider = s;
            s.onValueChanged.AddListener(delegate { UpdateSound(); });
        }
    }

    public void UpdateSound()
    {
        _ac.UpdateSound();
    }
}
