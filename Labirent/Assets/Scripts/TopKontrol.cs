using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//      Haydar ayaþta oynadý
public class TopKontrol : MonoBehaviour{

    public UnityEngine.UI.Button btn;
    public UnityEngine.UI.Text zaman, can, durum;
    private Rigidbody rg;
    public float Hiz = 10.0f;
    float zamanSayaci =10;
    int canSayaci = 4;
    bool oyunDevam = true;
    bool oyunTamam = false;
    // Start is called before the first frame update
    void Start()    {
        can.text = canSayaci + "";
        rg = GetComponent <Rigidbody>();
    }

    // Update is called once per frame
    void Update()    {
        if (oyunDevam && !oyunTamam) {
        zamanSayaci -= Time.deltaTime;
        zaman.text = (int)zamanSayaci + ""; 
        }
        else if(!oyunTamam)
        {
            durum.text = "Oyun Tamamlanmadý";
            btn.gameObject.SetActive(true);
        }
        
        if (zamanSayaci < 0) {
            oyunDevam = false; 
        }
    }

    void FixedUpdate()    {
        if (oyunDevam && !oyunTamam) { 
            float yatay = Input.GetAxis("Horizontal");
            float dikey = Input.GetAxis("Vertical");
            Vector3 kuvvet = new Vector3(-dikey, 0, yatay);
            rg.AddForce(kuvvet * Hiz);
        }
        else
        {
            rg.velocity = Vector3.zero;
            rg.angularVelocity = Vector3.zero;
        }
    }

    void OnCollisionEnter(Collision cls)
    {
        string objIsimi = cls.gameObject.name;
        if (objIsimi.Equals("Bitis"))
        {
            oyunTamam = true;
            durum.text = "Oyun Tamamlandý Tebrikler";
            btn.gameObject.SetActive(true);
        }
        else if(!objIsimi.Equals("Oyun Zemini") && !objIsimi.Equals("Bitis"))
        {
            canSayaci -= 1;
            can.text = canSayaci + "";
            if (canSayaci == 0)
                oyunDevam = false;
        }
    }
}
