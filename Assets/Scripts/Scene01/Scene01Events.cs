using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene01Events : MonoBehaviour
{
    public GameObject fadeScreenIn;
    public GameObject charSeongsu;
    public GameObject charJeongho;

    [SerializeField] AudioSource girlSigh;
    [SerializeField] AudioSource girlGasp;

    [SerializeField] string textToSpeak;
    [SerializeField] int currentTextLength;
    [SerializeField] int textLength;
    [SerializeField] GameObject mainTextObject;
    [SerializeField] GameObject nextButton;
    [SerializeField] int eventPos = 0;
    [SerializeField] GameObject charName;



    void Update()
    {
        textLength = TextCreator.charCount;
    }

    
   




}
