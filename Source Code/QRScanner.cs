using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
//[ExecuteInEditMode]
public class QRScanner : MonoBehaviour
{
    WebCamTexture webcamTexture;
    string QrCode = string.Empty;

    void Start()
    {
        var renderer = GetComponent<RawImage>();
        webcamTexture = new WebCamTexture(512, 512);
        renderer.texture = webcamTexture;
        StartCoroutine(GetQRCode());
    }

    IEnumerator GetQRCode()
    {
        IBarcodeReader barCodeReader = new BarcodeReader();
        webcamTexture.Play();
        var snap = new Texture2D(webcamTexture.width, webcamTexture.height, TextureFormat.ARGB32, false);
        while (string.IsNullOrEmpty(QrCode))
        {
            try
            {
                snap.SetPixels32(webcamTexture.GetPixels32());
                var Result = barCodeReader.Decode(snap.GetRawTextureData(), webcamTexture.width, webcamTexture.height, RGBLuminanceSource.BitmapFormat.ARGB32);
                if (Result != null)
                {
                    QrCode = Result.Text;
                    if (!string.IsNullOrEmpty(QrCode))
                    {
                        Debug.Log("DECODED TEXT FROM QR: " + QrCode);
                        break;
                    }
                }
            }
            catch (Exception ex) { Debug.LogWarning(ex.Message); }
            yield return null;
        }
        webcamTexture.Stop();
    }
    
    public GUIStyle style;
    public GUIStyle button;
    private void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        Rect rect = new Rect(0, -300, w, h); // x, y, width, height
        string text = QrCode;
        GUI.Label(rect, text, style);

        GUI.color = new Color(0.9f, 0.7f, 0.1f, 1.0f);
        
        if (GUI.Button(new Rect(215, 800, 150, 100), "Go to Link",button))
        {
            Application.OpenURL(text);
        }
    }
}
