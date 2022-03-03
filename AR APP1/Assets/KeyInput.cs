using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFileBrowser;
using System.IO;

public class KeyInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ShowLoadDialogCoroutine());
        }
    }

	IEnumerator ShowLoadDialogCoroutine()
	{
		// Show a load file dialog and wait for a response from user
		// Load file/folder: both, Allow multiple selection: true
		// Initial path: default (Documents), Initial filename: empty
		// Title: "Load File", Submit button text: "Load"
		FileBrowser.SetFilters(false, ".mp3");
		yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.Files, true, null, null, "Load MP3 File", "Load");

		// Dialog is closed
		// Print whether the user has selected some files/folders or cancelled the operation (FileBrowser.Success)
		Debug.Log(FileBrowser.Success);

		if (FileBrowser.Success)
		{
			// Print paths of the selected files (FileBrowser.Result) (null, if FileBrowser.Success is false)
			string destinationPath = Path.Combine(FileBrowserHelpers.GetDirectoryName(FileBrowser.Result[0]), FileBrowserHelpers.GetFilename(FileBrowser.Result[0]));
			Debug.Log(destinationPath);

			//load file
			GameObject speakerL = GameObject.Find("Speaker_L");
			AudioSource audioL = speakerL.GetComponent<AudioSource>();
			GameObject speakerR = GameObject.Find("Speaker_R");
			AudioSource audioR = speakerR.GetComponent<AudioSource>();
			string url = string.Format("file://{0}", destinationPath);
			WWW www = new WWW(url);
			audioL.clip = NAudioPlayer.FromMp3Data_L(www.bytes);
			audioL.Play();
			audioR.clip = NAudioPlayer.FromMp3Data_R(www.bytes);
			audioR.Play();
		}
	}
}
