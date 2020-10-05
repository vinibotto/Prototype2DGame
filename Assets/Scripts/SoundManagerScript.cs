using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip BomDiaFamilia;
    public static AudioClip SextaFeiraAbencoada;
    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        BomDiaFamilia = Resources.Load<AudioClip>("Bom_Dia_Familia");
        SextaFeiraAbencoada = Resources.Load<AudioClip>("Sexta_Feira_Abencoada");
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySoundBomDia() 
    {
        audioSource.PlayOneShot(BomDiaFamilia);
    }

    public static void PlaySoundSextaFeira()
    {
        audioSource.PlayOneShot(SextaFeiraAbencoada);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
