using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowImageOnScreen : MonoBehaviour {


    private RenderTexture renderTex;
    public float screenResolutionMultiplier = 0.5f;

    //For now is a plane with a material, but that will change
    public GameObject renderTarget;

    public Camera gameCam;

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
            Image img = renderTarget.GetComponent<Image>();
            //Super test
            if(img != null)
                img.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0,0));

            Material asd = renderTarget.GetComponent<MeshRenderer>().material;
            if(asd != null)
            {
                asd.SetTexture(asd.GetTexturePropertyNameIDs()[0], www.texture);
                renderTarget.GetComponent<MeshRenderer>().material = asd;
            }

            
            // GUI.Label(new Rect(0, 0, 100, 100), www.texture.ToString());
            //Debug.Log(www.texture);
        }
    }

    private void Start()
    {
        //renderTex.height = Screen.height;
        //renderTex.width = Screen.width;
        renderTex = new RenderTexture((int)((float)Screen.width * screenResolutionMultiplier), (int)((float)Screen.height * screenResolutionMultiplier), 24);

    }

    public void DownloadImageAndAddToRenderTarget(GameObject renderTarget, string url)
    {
        StartCoroutine(StartDownloadImage(renderTarget, url));
    }

    float updateTimer = 0;
	// Update is called once per frame
	void Update () {
        updateTimer += Time.deltaTime;
        if(updateTimer > 0.03)
        {
            updateTimer = 0;

            //StartCoroutine(StartScanRoutine());
            QRScanner.CameraRenderTextureSnapshot(gameCam, renderTex);
            string QRText = QRScanner.ScanTexture(QRScanner.CameraRenderTextureSnapshot(gameCam, renderTex));
            if (QRText != null)
              DownloadImageAndAddToRenderTarget(renderTarget, QRText);
            //Debug.Log("Framerate: " + 1 / Time.deltaTime);
        }
    }
}
