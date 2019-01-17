﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DownloadImage : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    private void Update()
    {
        StartCoroutine(StartDownloadImage());
    }

    public GameObject plane;

    public string url = "3dvision.se/customer/iot/iot.png";

    IEnumerator StartDownloadImage()
    {
        // Start a download of the given URL
        using (WWW www = new WWW(url))
        {
            // Wait for download to complete
            yield return www;

            // assign texture
            // Renderer renderer = GetComponent<Renderer>();
            // renderer.material.mainTexture = www.texture;
            Material asd = plane.GetComponent<MeshRenderer>().material;
            asd.SetTexture(asd.GetTexturePropertyNameIDs()[0], www.texture);
            plane.GetComponent<MeshRenderer>().material = asd;
            // GUI.Label(new Rect(0, 0, 100, 100), www.texture.ToString());
            Debug.Log(www.texture);
        }
    }
}
