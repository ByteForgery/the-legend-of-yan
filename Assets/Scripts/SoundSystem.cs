using UnityEngine;
using UnityEngine.Audio;

public class SoundSystem : MonoBehaviour
{
    private const string MASTER_VOLUME_KEY = "MasterVolume";
    private const string SFX_VOLUME_KEY = "SFXVolume";
    private const string MUSIC_VOLUME_KEY = "MusicVolume";
    
    public static SoundSystem Instance { get; private set; }

    public AudioMixer audioMixer;

    public float MasterVolume
    {
        get
        {
            audioMixer.GetFloat(MASTER_VOLUME_KEY, out float db);
            return dbToValue(db);
        }
        set
        {
            audioMixer.SetFloat(MASTER_VOLUME_KEY, valueToDb(value));
        }
    }

    public float SFXVolume
    {
        get
        {
            audioMixer.GetFloat(SFX_VOLUME_KEY, out float db);
            return dbToValue(db);
        }
        set
        {
            audioMixer.SetFloat(SFX_VOLUME_KEY, valueToDb(value));
        }
    }

    public float MusicVolume
    {
        get
        {
            audioMixer.GetFloat(MUSIC_VOLUME_KEY, out float db);
            return dbToValue(db);
        }
        set
        {
            audioMixer.SetFloat(MUSIC_VOLUME_KEY, valueToDb(value));
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
            Destroy(gameObject);
    }

    private static float dbToValue(float db) => Mathf.Pow(10f, db / 20f);
    private static float valueToDb(float value) => value > 0f ? Mathf.Log10(value) * 20f : -80f;
}
