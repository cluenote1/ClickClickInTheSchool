using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btnsound : MonoBehaviour
{
    public AudioSource clickSound;
    // Start is called before the first frame update
    public void ClickSound()
    {
        clickSound.Play();
    }

    
}
