using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CreateChaos : MonoBehaviour
{
    public bool pressed = false;

    private void Update()
    {
        PostProcessVolume volume = gameObject.GetComponent<PostProcessVolume>();
        ColorGrading colorGrad;

        volume.profile.TryGetSettings(out colorGrad);

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            pressed = !pressed;
        }

        if (pressed)
            colorGrad.hueShift.value++;
        else
            colorGrad.hueShift.value = 0;
    }
}
