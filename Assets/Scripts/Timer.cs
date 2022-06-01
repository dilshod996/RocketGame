using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] float accomplishTime = 30f;
    public Image myimage;
    public TextMeshProUGUI mytext;
    Crashed mycrash;
    [SerializeField] int healthAmount = 5;
    void Start()
    {
        mycrash = FindObjectOfType<Crashed>();


    }

    // Update is called once per frame
    void Update()
    {
        myimage.fillAmount -= Time.deltaTime / accomplishTime;
        mytext.text = healthAmount.ToString();
        if (myimage.fillAmount < 0.3 ) 
        {

            myimage.color = new Color32(229, 15, 31, 255);
        }
        if(myimage.fillAmount == 0)
        {

            SceneManager.LoadScene(0);
        }
        

    }
}
