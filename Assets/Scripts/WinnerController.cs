
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Threading;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinnerController : MonoBehaviourPunCallbacks
{
    
    public GameObject canvWinner;
    public GameObject canvLoser;
    public GameObject canvRip;

    public PhotonView pv;
    public GameObject hatProba;

    public Text copesWin;
    public Text copesLose;

    public Text moneyText;

    public static int trophys;
    public static int trophysTotal;

    void Start()
    {
        trophys = 0;
        trophysTotal = 0;
        updateMoney();
    }

    void OnCollisionEnter2D(Collision2D obj) {

        
        if (obj.collider.tag == "rip")
        {


            if (photonView.IsMine)
            {
                StartCoroutine(activateRip());

            }
            


        }

        /*
        if (obj.collider.tag == "coin")
        {
            if (photonView.IsMine)
            {
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) + 1);
                updateMoney();
                coins.destroyCoin();
                
            }


        }
        */

    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "coin")
        {

            if (photonView.IsMine)
            {
                pv.RPC("activateHat", RpcTarget.AllBufferedViaServer);
                

                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 1);
                updateMoney();
                Destroy(collision.gameObject);
            }

            
        }

        if (collision.tag == "End")
        {

            if (photonView.IsMine)
            {
                trophys = Random.Range(20, 30);
                copesWin.text = "+" + trophys;
                trophysTotal = PlayerPrefs.GetInt("TrophysTotal") + trophys;
                PlayerPrefs.SetInt("TrophysTotal", trophysTotal);

                canvWinner.SetActive(true);


            }
            else if (!photonView.IsMine)
            {
                trophys = Random.Range(10, 20);
                copesLose.text = "-" + trophys;
                trophysTotal = PlayerPrefs.GetInt("TrophysTotal") - trophys;
                PlayerPrefs.SetInt("TrophysTotal", trophysTotal);

                canvLoser.SetActive(true);
                StartCoroutine(loserMethod());


            }

            StartCoroutine(waitDisconnect());

        }
    }

    [PunRPC]
    void activateHat()
    {
        hatProba.SetActive(true);
    }


    private IEnumerator waitDisconnect()
    {
    
    yield return new WaitForSeconds (6);
    DisconnectPlayer();
    
    }

    

    private IEnumerator loserMethod()
    {
    
    yield return new WaitForSeconds (4);
    
    DisconnectPlayer();
  
    }
    

    public void DisconnectPlayer(){

        StartCoroutine(DisconnectAndLoad());
    }

    IEnumerator DisconnectAndLoad()
    {   
        
        PhotonNetwork.LeaveRoom();
        
        while (PhotonNetwork.InRoom) 
            yield return null;

        SceneManager.LoadScene("MainMenu");
    }

    private IEnumerator activateRip()
    {
        canvRip.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        transform.position = new Vector2(-14, 0);
        canvRip.SetActive(false);


    }

    public static int GetTrophys()
    {
        return trophys;
    }

    public void updateMoney()
    {
        moneyText.text = PlayerPrefs.GetInt("Money").ToString();
    }


}
