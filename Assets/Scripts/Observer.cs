using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;
    public TextMeshProUGUI chargesText;
    //public GameObject playerObject;
    //public GameObject gameObjectPlayer;
    public GameObject transparencyPanel;

    bool m_IsPlayerInRange;

    public bool playerIsInvisible;//
    public bool timerIsRunning = false;
    public static int abilityCharges = 1;
    public static float abilityUptime = 5;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }
    void UpdateCharges()
    {
        string chargesCount = abilityCharges.ToString();
        chargesText.text = "Invisibility charges: "+ chargesCount;
    }

    void Start()
    {
        //chargesText = GetComponent<TextMeshProUGUI>();
        string chargesCount = abilityCharges.ToString();
        chargesText.text = "Invisibility charges: " + chargesCount;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && abilityCharges>0 && timerIsRunning==false)
        {
            abilityCharges--;
            timerIsRunning = true;
            playerIsInvisible = true;
            UpdateCharges();
            //playerObject.GetComponent<Renderer>().material.color = new Color(255.0f, 255.0f, 255.0f, 50.0f);
            //gameObjectPlayer.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
            transparencyPanel.SetActive(true);
        }
        if( timerIsRunning==true)
        {
            if (abilityUptime > 0)
            { 
                abilityUptime -= Time.deltaTime;
            }
            else
            {
                timerIsRunning=false;
                playerIsInvisible=false;
                transparencyPanel.SetActive(false);
                abilityUptime = 5;
            }
        }
        if (m_IsPlayerInRange) //
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player && playerIsInvisible == false)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}
