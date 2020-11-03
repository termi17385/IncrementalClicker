using incrementalClicker.player;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private Toggle fullscreen;
    [SerializeField] private Toggle autoLoad;
    [SerializeField] private Toggle autoSave;
    [SerializeField] private bool _autoLoad, _autoSave, _fullscreen;
    [SerializeField] private AudioSource buttons;
    [SerializeField] private AudioMixer mixer;
    public Slider musicVolume; 
    public Slider sfxVolume;
    #endregion


    private void Awake()
    {
        LoadPlayerPrefs(); 
    }

    private void Start()
    {
        FullscreenCheck();
    }

    private void Update()
    {
        _AutoLoad();
        _AutoSave();
        FullscreenCheck();
    }




    public void PlayGame()
    {
        SceneManager.LoadScene("Clicker");
    }


    public void _AutoLoad()
    {
        PlayerStats.autoLoad = _autoLoad;
        if (autoLoad.isOn)
        {
            _autoLoad = true;
        }
        else
        {
            _autoLoad = false;
        }
    }

    public void _AutoSave()
    {
        PlayerStats.autoSave = _autoSave;
        if (autoSave.isOn)
        {
            _autoSave = true;
        }
        else
        {
            _autoSave = false;
        }
    }

    public void FullscreenCheck()
    {
        //FullScreenChecking
        if (!PlayerPrefs.HasKey("fullscreen"))         // checking if fullscreen is saved or not
        {
            PlayerPrefs.SetInt("fullscreen", 0);
            Screen.fullScreen = false;
        }
        else
        {
            if (PlayerPrefs.GetInt("fullscreen") == 0) // if fullscreen is not on (0)
            {
                Screen.fullScreen = false;             // fullscreen false
            }
            else
            {
                Screen.fullScreen = true;              // else fullscreen true
            }
        }

    }

    public void SetFullScreen(bool fullscreen)
    {
        // sets the scene to full screen when called
        Screen.fullScreen = fullscreen;
        _fullscreen = fullscreen;
    }

    public void SetMusicVolume(float value)
    {
        mixer.SetFloat("Music", value);
    }

    public void SetSFXVolume(float value)
    {
        mixer.SetFloat("SFX", value);
    }

    public void SavePlayerPrefs()
    {
        // saves the players preferences

        // saves fullscreen

        if (fullscreen.isOn) // if fullscreen is toggled
        {
            PlayerPrefs.SetInt("fullscreen", 1);  // value is set to 1
        }
        else
        {
            PlayerPrefs.SetInt("fullscreen", 0);  // else its set to 0
        }

        float musicVol;
        if (mixer.GetFloat("Music", out musicVol)) // will check if a float is outputted by the mixer
        {
            PlayerPrefs.SetFloat("Music", musicVol); // sets the outputted value
        }

        float sfxVol;
        if (mixer.GetFloat("SFX", out sfxVol)) // will check if a float is outputted by the mixer
        {
            PlayerPrefs.SetFloat("SFX", sfxVol);  // sets the outputted value
        }

        PlayerPrefs.Save(); // will save the stored preferences
    }

    public void LoadPlayerPrefs()
    {
        // Loads the players saved preferences

        if (PlayerPrefs.GetInt("fullscreen") == 0)  // if fullscreen isnt on
        {
            fullscreen.isOn = false;                // dont turn on fullscreen
        }
        else
        {
            fullscreen.isOn = true;                 // turn on fullscreen
        }

        // for loading music
        float musicVol = PlayerPrefs.GetFloat("Music");
        musicVolume.value = musicVol;
        mixer.SetFloat("Music", musicVol);

        // for loading SFX
        float sfxVol = PlayerPrefs.GetFloat("SFX");
        sfxVolume.value = musicVol;
        mixer.SetFloat("SFX", sfxVol);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR

        EditorApplication.ExitPlaymode(); // exits playmode when using the editor

#endif
        Application.Quit(); // used to quit to desktop when running the build
    }
}
