using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;
using System;

public class QRScanner : MonoBehaviour {



   

    static public Texture2D CameraRenderTextureSnapshot(Camera Cam, RenderTexture rt)
    {

        RenderTexture temp = Cam.targetTexture;
        Cam.targetTexture = rt;
        RenderTexture.active = rt;
        Cam.Render();

        Texture2D tex = new Texture2D(rt.width, rt.height);
        tex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        tex.Apply(); //Applies changes to texture, I guess

        Cam.targetTexture = temp;
        RenderTexture.active = temp;
        
        return tex;
    }
    
    static public Texture2D GetRTPixels(RenderTexture rt)
    {
        // Remember currently active render texture
        //RenderTexture currentActiveRT = RenderTexture.active;

        // Set the supplied RenderTexture as the active one
        //RenderTexture.active = rt;

        // Create a new Texture2D and read the RenderTexture image into it
        Texture2D tex = new Texture2D(rt.width, rt.height);
        tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);

        // Restore previously active render texture
        //RenderTexture.active = currentActiveRT;
        return tex;
    }

    //Scan Texture for Barcodes
    static public string ScanTexture(Texture2D texTarget)
    {
        try
        {
            IBarcodeReader barcodeReader = new BarcodeReader();
            // decode the current frame
            var result = barcodeReader.Decode(texTarget.GetPixels32(),
              texTarget.width, texTarget.height);

            //Material asd = renderTarget.GetComponent<MeshRenderer>().material;
            //asd.SetTexture(asd.GetTexturePropertyNameIDs()[0], texTarget);
            //renderTarget.GetComponent<MeshRenderer>().material = asd;

            Debug.Log("Trying" + "X: " + texTarget.width + " Y: " + texTarget.height);

            if (result != null)
            {
                Debug.Log("DECODED TEXT FROM QR: " + result.Text);
                //scanText = result.Text;
               
                return result.Text;
            }
        }
        catch (Exception ex) { Debug.LogWarning(ex.Message); }
        return null;
    }

    //Webcam (low performance)

    public RenderTexture cameraRenderTex;
    private WebCamTexture camTexture;
    private Rect screenRect;
    public string scanText;

    void Start()
    {
        //initWebCam();


    }


    private void initWebCam()
    {
        //Webcam (low performance)
        screenRect = new Rect(0, 0, Screen.width, Screen.height);
        camTexture = new WebCamTexture();
        camTexture.requestedHeight = Screen.height / 3;
        camTexture.requestedWidth = Screen.width / 3;
        if (camTexture != null)
        {
            camTexture.Play();
        }
    }
    
   //void OnGUI()
   //{
   //    // drawing the camera on screen
   //    //GUI.DrawTexture(screenRect, camTexture, ScaleMode.ScaleToFit);
   //    // do the reading — you might want to attempt to read less often than you draw on the screen for performance sake
   //    try
   //    {
   //        IBarcodeReader barcodeReader = new BarcodeReader();
   //        // decode the current frame
   //        var result = barcodeReader.Decode(camTexture.GetPixels32(),
   //          camTexture.width, camTexture.height);
   //       
   //    
   //        
   //        if (result != null)
   //        {
   //            Debug.Log("DECODED TEXT FROM QR: " +result.Text);
   //            scanText = result.Text;
   //        }
   //    }
   //    catch (Exception ex) { Debug.LogWarning(ex.Message); }
   //}
}
