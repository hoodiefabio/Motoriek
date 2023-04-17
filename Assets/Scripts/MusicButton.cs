using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    [SerializeField] Image buttonImage;
    [SerializeField] AudioMixer mixer;
    private Color startColor;
    private Spawner spawner;
    private float volumeValue;
    // Start is called before the first frame update
    void Start()
    {
        spawner = FindObjectOfType<Spawner>();
        startColor = buttonImage.color;
 
    }

    private void Update()
    {
        mixer.GetFloat("Volume", out volumeValue);

       if (volumeValue == -80.0f)
            buttonImage.color = Color.grey;
       else
            buttonImage.color = startColor;
       
        if (spawner != null)
        {
            if (spawner.gameOver)
            {
                mixer.SetFloat("Volume", -80.0f);
            }
        }
    }

    public void ToggleMusic()
    {
        if (volumeValue == 00.0f)
        {
            mixer.SetFloat("Volume", -80.0f);
        }
        else
        {
            mixer.SetFloat("Volume", 00.0f);
        }

    }
}
