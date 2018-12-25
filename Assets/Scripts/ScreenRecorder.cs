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
    public int captureWidth = Screen.width;
    public int captureHeight = Screen.height;

    //to hide game objects during screenshots
    public GameObject hideGameObject;

    //for extension type
    public enum Format { Raw, JPG, PNG, PPM };
    public Format format = Format.PNG;

    //folder to write output(defaults to data path)
    public string folder;

    //for screenshot itself
    private Rect rect;
    private RenderTexture renderTexture;
    private Texture2D screenshot;
    private int counter = 0;    //image no.

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

    public void Capture()
    {
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

        if (format == Format.PNG)
            fileData = screenshot.EncodeToPNG();

        DownloadFile(fileData, fileData.Length, filename);

        //unhide optiona gameobject if set
        if (hideGameObject != null)
        {
            hideGameObject.SetActive(true);
        }
    }
}
