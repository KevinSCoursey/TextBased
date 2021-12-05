using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GraphicsMenu : MonoBehaviour
{
    private SystemData _systemData;

    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;

    void Awake()
    {
        UpdateResolutionOptions();
        
    }

    private void Start()
    {
        //Gets the singleton system data
        _systemData = SystemDataManager.Instance.Data;
    }


    /// <summary>
    /// Looks at game screen resolution and checks if it is equal to one of the options. If it is, set the dropdown to that value.
    /// If not, sets resolution to minimum value. Also adds all options to the dropdown menu and refreshes it.
    /// </summary>
    public void UpdateResolutionOptions()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> resolutionOptions = new List<string>();

        //List<string> resolutionOptions = new List<string>();
        int currentResolutionIndex = 0;
        Debug.Log($"Current screen dimensions are {Screen.width}x{Screen.height}.");
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            Debug.Log($"Added resolution {option} to the list of resolution options.");
            //resolutionOptions.Add(option);
            resolutionOptions.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
                Debug.Log($"Set the default resolution to {option}.");
            }

        }
        _systemData.ResolutionOptions = resolutionOptions;
        //resolutionDropdown.AddOptions(resolutionOptions);
        resolutionDropdown.AddOptions(_systemData.ResolutionOptions);
        if (currentResolutionIndex == 0)
        {
            Debug.Log($"Current resolution of {Screen.width}x{Screen.height} isn't compatible with the generated options. Setting default resolution to {resolutions[0].width}x{resolutions[0].height}.");
        }
        resolutionDropdown.value = currentResolutionIndex;
        _systemData.GameResolutionIndex = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }    
}
