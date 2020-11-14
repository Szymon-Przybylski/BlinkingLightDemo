using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasInstructionsController : MonoBehaviour
{
    [SerializeField] private Text startupInformationText;
    void Start()
    {
        startupInformationText = GetComponent<Text>();
        Time.timeScale = 0;
    }
    
    void Update()
    {
        if(Input.anyKeyDown)
        {
            Time.timeScale = 1;
            Destroy(gameObject);
        }
    }
}
