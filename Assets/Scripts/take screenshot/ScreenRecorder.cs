using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.InteropServices;

/// <summary>
/// This script is used to capture single/multiple screenshots
/// It should be added to the camera wanted to be the point of view
/// </summary>
public class ScreenRecorder : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void DownloadFile(byte[] array, int byteLength, string fileName);


    //for 1080p
    public int captureWidth = 1920;
    public int captureHeight = 1080;

    //to hide game objects during screenshots
    public GameObject hideGameObject;

    //for optimization to capture multiple screenshots
    public bool optimizeForManyScreenshots = true;

    //for extension type
    public enum Format { Raw, JPG, PNG, PPM };
    public Format format = Format.JPG;

    //folder to write output(defaults to data path)
    public string folder;

    //for screenshot itself
    private Rect rect;
    private RenderTexture renderTexture;
    private Texture2D screenshot;
    private int counter = 0;    //image no.

    //commands
    private bool captureScreenshot = false;
    private bool captureVedio = false;

    //create a unique filename using a one-up variable
    private string uniqueFilename(int width, int height)
    {
        //if folder isn't specified by now use a good default
        if (folder == null || folder.Length == 0)
        {
            folder = Application.persistentDataPath;
            if (Application.isEditor)
            {
                //to put screenshots in folder above asset path so unity doesn't index the files
                var stringPath = folder + "/..";
                folder = Path.GetFullPath(stringPath);
            }
            folder += "/screenshots";

            //make sure directory exists
            System.IO.Directory.CreateDirectory(folder);

            //count number of files of specified format in folder
            string mask = string.Format("hamadascreen_{0}x{1}*.{2}", width, height, format.ToString().ToLower());
            counter = Directory.GetFiles(folder, mask, SearchOption.TopDirectoryOnly).Length;
        }

        //use width, height, and counter for unique file name
        var filename = string.Format("{0}/screen_{1}x{2}_{3}.{4}", folder, width, height, counter, format.ToString().ToLower());

        //up counter for next call
        ++counter;

        //return unique filename
        return filename;
    }

    public void CaptureScreenschot()
    {
        captureScreenshot = true;
    }

    private void Update()
    {
        // use "k" for one screenshot, or hold "v" for continous screehots
        // this will be modified to use with save button in UI
        //--------------------------------------------------------
        captureScreenshot |= Input.GetKey("k");
        captureVedio = Input.GetKey("v");

        if (captureScreenshot || captureVedio)
        {
            captureScreenshot = false;

            //hide optional gameobject if set
            if (hideGameObject != null)
            {
                hideGameObject.SetActive(false);
            }

            //create screenschot objects if needed
            if (renderTexture == null)
            {
                //creates off-screen render texture that can be rendered into
                rect = new Rect(0, 0, captureWidth, captureHeight);
                renderTexture = new RenderTexture(captureWidth, captureHeight, 24);
                screenshot = new Texture2D(captureWidth, captureHeight, TextureFormat.RGB24, false);
            }

            //get main camera and manually render scene into rendertexture
            Camera camera = this.GetComponent<Camera>();    //this script added to the Camera
            camera.targetTexture = renderTexture;
            camera.Render();

            //render texture active and then read the pixels
            RenderTexture.active = renderTexture;
            screenshot.ReadPixels(rect, 0, 0);

            //reset active camera texture and render texture
            camera.targetTexture = null;
            RenderTexture.active = null;

            //get the unique filename
            string filename = uniqueFilename((int)rect.width, (int)rect.height);

            //pull in the file header/data bytes for the specified image format
            byte[] fileHeader = null;
            byte[] fileData = null;
            if (format == Format.Raw)
                fileData = screenshot.GetRawTextureData();
            else if (format == Format.PNG)
                fileData = screenshot.EncodeToPNG();
            else if (format == Format.JPG)
                fileData = screenshot.EncodeToJPG();
            else        //PPM
            {
                string headerStr = string.Format("P6\n{0} {1}\n225\n", rect.width, rect.height);
                fileHeader = System.Text.Encoding.ASCII.GetBytes(headerStr);
                fileData = screenshot.GetRawTextureData();

            }

            DownloadFile(fileData, fileData.Length, filename);

            //New thread to save the image to file
           // new System.Threading.Thread(() =>
           //{
           //    //create file and write optional header with image bytes
           //    var f = System.IO.File.Create(filename);
           //    if (fileHeader != null)
           //        f.Write(fileHeader, 0, fileHeader.Length);
           //    f.Write(fileData, 0, fileData.Length);
           //    f.Close();
           //    Debug.Log(string.Format("Wrote screenshot {0} of size {1}", filename, fileData.Length));
           //}).Start();


            //unhide optiona gameobject if set
            if (hideGameObject != null)
            {
                hideGameObject.SetActive(true);
            }

            //for cleanup things for multiple screen shots        if needed
            if (optimizeForManyScreenshots == false)
            {
                Destroy(renderTexture);
                renderTexture = null;
                screenshot = null;
            }
        }
    }
}
