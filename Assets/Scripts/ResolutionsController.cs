using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResolutionsController : MonoBehaviour
{

    [SerializeField] Toggle fullscreenToggle;

    bool canChangeFullscreen = false;

    [SerializeField] Hashtable m_ResolutionValues = new Hashtable();

    [SerializeField] List<TMP_Dropdown.OptionData> m_ResolutionList = new List<TMP_Dropdown.OptionData>();

    [SerializeField] TMP_Dropdown resDropdown;

    void Start()
    {
        canChangeFullscreen = false;

        int resValue = 0;

        resDropdown = GetComponent<TMP_Dropdown>();
        resDropdown.ClearOptions();

        Resolution[] m_Resolutions = Screen.resolutions;

        foreach (var res in m_Resolutions)
        {
            //g_ResolutionValues.Add("Width");
            TMP_Dropdown.OptionData newRes = new TMP_Dropdown.OptionData();
            newRes.text = res.width + "x" + res.height + ", " + res.refreshRate + "hz";

            resDropdown.options.Add(newRes);
            if (res.width == Screen.width)
            {

                resDropdown.value = resValue;

            }

            resValue++;
        }

        Debug.Log(Screen.width);

        if (Screen.fullScreen)
        {
            fullscreenToggle.isOn = true;
            canChangeFullscreen = true;
        }
        else
        {
            fullscreenToggle.isOn = false;
            canChangeFullscreen = true;
        }

    }

    public void ChangeFullscreen()
    {
        if (canChangeFullscreen)
        {
            Debug.Log("Fullscreen: " + Screen.fullScreen);
            Screen.fullScreen = !Screen.fullScreen;
        }
    }

    public void ChangeResolution()
    {
        Resolution[] m_Resolutions = Screen.resolutions;

        Screen.SetResolution(m_Resolutions[resDropdown.value].width, m_Resolutions[resDropdown.value].height, Screen.fullScreen);

        Debug.Log("Resolucao atual: " + m_Resolutions[resDropdown.value].width + "x" + m_Resolutions[resDropdown.value].height);
    }


}
