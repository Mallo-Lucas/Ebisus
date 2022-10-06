using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFade : MonoBehaviour
{
    [SerializeField] private Image blackScreen;
    [SerializeField] private float fadeSpeed;
    [SerializeField] private bool test;

    private bool _cameraFadeOn;

    private void Update()
    {
        if (test != _cameraFadeOn)
        {
            StartCoroutine(CameraFadeCorrutine());
        }
    }

    private IEnumerator CameraFadeCorrutine()
    {
        Color newScreenColor = blackScreen.color;

        switch (_cameraFadeOn)
        {
            case false:
                while(newScreenColor.a < 1)
                {
                    newScreenColor.a += fadeSpeed * Time.deltaTime;
                    blackScreen.color = newScreenColor;
                    yield return null;
                }
                newScreenColor.a = 1;
                blackScreen.color = newScreenColor;
                _cameraFadeOn = true;
                break;
            case true:
                while (newScreenColor.a > 0)
                {
                    newScreenColor.a -= fadeSpeed * Time.deltaTime;
                    blackScreen.color = newScreenColor;
                    yield return null;
                }
                newScreenColor.a = 0;
                blackScreen.color = newScreenColor;
                _cameraFadeOn = false;
                break;
        }
    }
}
