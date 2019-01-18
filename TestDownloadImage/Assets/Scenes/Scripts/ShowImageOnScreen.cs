using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowImageOnScreen : MonoBehaviour {


    public RenderTexture renderTex;

    public GameObject renderTarget;

    public QRScanner scanner;

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
            Material asd = renderTarget.GetComponent<MeshRenderer>().material;
            asd.SetTexture(asd.GetTexturePropertyNameIDs()[0], www.texture);
            renderTarget.GetComponent<MeshRenderer>().material = asd;
            // GUI.Label(new Rect(0, 0, 100, 100), www.texture.ToString());
            Debug.Log(www.texture);
        }
    }

    public void DownloadImageAndAddToRenderTarget(GameObject renderTarget, string url)
    {
        StartCoroutine(StartDownloadImage(renderTarget, url));
    }
	
	// Update is called once per frame
	void Update () {
       // if (QRScanner.ScanTexture(QRScanner.GetRTPixels(renderTex)) != null)
       //     DownloadImageAndAddToRenderTarget(renderTarget, scanner.scanText);
       // Debug.Log("Framerate: " + 1 / Time.deltaTime);
    }
}
