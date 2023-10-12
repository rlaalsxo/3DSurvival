using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource[] audioSources;
    [SerializeField] AudioMixer masterMixer;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider sfxSlider;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        float sound;
        masterMixer.GetFloat("BGM", out sound);
        bgmSlider.value = sound;
        masterMixer.GetFloat("SFX", out sound);
        sfxSlider.value = sound;
    }
    public void BGMControl()
    {
        float sound = bgmSlider.value;
        if (sound == -40f) masterMixer.SetFloat("BGM", -80);
        else masterMixer.SetFloat("BGM", sound);
    }
    public void SFXControl()
    {
        float sound = sfxSlider.value;
        if (sound == -40f) masterMixer.SetFloat("SFX", -80);
        else masterMixer.SetFloat("SFX", sound);
    }
    public void AudioOff()
    {
        masterMixer.SetFloat("BGM", -80);
        masterMixer.SetFloat("SFX", -80);
    }
    public void AudioOn()
    {
        float bgm = bgmSlider.value;
        float sfx = sfxSlider.value;
        masterMixer.SetFloat("BGM", bgm);
        masterMixer.SetFloat("SFX", sfx);
    }
}
