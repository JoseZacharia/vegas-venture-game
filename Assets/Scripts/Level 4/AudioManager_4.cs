using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager_4 : MonoBehaviour
{

	public static AudioManager_4 instance;

	public AudioMixerGroup mixerGroup;

	public Sound_4[] sounds;

	void Awake()
	{
		//if (instance != null)
		//{
		//	Destroy(gameObject);
		//}
		//else
		//{
		//	instance = this;
		//	DontDestroyOnLoad(gameObject);
		//}

		foreach (Sound_4 s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}
	}

    private void Start()
    {
		//Play("Spaceship cruising");
    }
    public void Play(string sound)
	{
		Sound_4 s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + sound + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		if (s.alreadyPlaying == false)
		{
			s.source.Play();
			if (s.isNotLoop == false)
				s.alreadyPlaying = true;
		}


	}
	public void StopPlaying(string sound)
	{
		Sound_4 s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + sound + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Stop();
		s.alreadyPlaying = false;
	}

}
