﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DownloadImage : ScriptableObject
{

    // Use this for initialization
    void Start()
    {

    }

    //private void Update()
    //{
    //    StartCoroutine(StartDownloadImage());
    //}
	//
    //public void DownloadImageAndAddToRenderTarget()
    //{
    //    StartCoroutine(StartDownloadImage());
    //}
    //public GameObject plane;

    //public string url = "3dvision.se/customer/iot/iot.png";

    public IEnumerator StartDownloadImage(GameObject renderTarget, string url)
    {
        // Start a download of the given URL
        using (WWW www = new WWW(url))
        {
            // Wait for download to complete
            yield return www;

            // assign texture
            // Renderer renderer = GetComponent<Renderer>();
            // renderer.material.mainTexture = www.texture;
            Texture2D wwwTexture = www.texture;
            Sprite daSprite = Sprite.Create(wwwTexture, new Rect(0, 0, wwwTexture.width, wwwTexture.height), new Vector2(0.5f, 0.5f));
            Image targetImg = renderTarget.GetComponent<Image>();
            targetImg.sprite = daSprite;
            Material asd = renderTarget.GetComponent<MeshRenderer>().material;
            asd.SetTexture(asd.GetTexturePropertyNameIDs()[0], www.texture);
            renderTarget.GetComponent<MeshRenderer>().material = asd;
            // GUI.Label(new Rect(0, 0, 100, 100), www.texture.ToString());
            Debug.Log(www.texture);
        }
    }
}

