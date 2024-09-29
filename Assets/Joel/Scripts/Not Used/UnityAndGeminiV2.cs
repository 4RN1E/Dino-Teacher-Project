using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

[System.Serializable]
public class UnityAndGeminiKey
{
    public string key;
}

[System.Serializable]
public class Response
{
    public Candidate[] candidates;
}

[System.Serializable]
public class Candidate
{
    public Content content;
}

[System.Serializable]
public class Content
{
    public Part[] parts;
}

[System.Serializable]
public class Part
{
    public string text;
}

namespace Suriyun { 
public class UnityAndGeminiV2: MonoBehaviour
{
    public TextAsset jsonApi;
    private string apiKey = ""; 
    private string apiEndpoint = "https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash-latest:generateContent"; // Edit it and choose your prefer model
    public string prompt = "What is your name?";

    public TextMeshProUGUI textObject;
    public AnimatorController animatorController;
        public AudioManager audioManager;

        void Start()
    {
        UnityAndGeminiKey jsonApiKey = JsonUtility.FromJson<UnityAndGeminiKey>(jsonApi.text);
        apiKey = jsonApiKey.key;   
        StartCoroutine(DelayedRequests());
    }

     IEnumerator DelayedRequests()
    {
        StartCoroutine(SendRequestToGemini("Hello!"));          //Gemini Request put on Screen
        animatorController.SetInt("animation,4");               //Changes Animation
        audioManager.PlayCorrectSound();                        //Plays Correct Sound
        yield return new WaitForSeconds(5f);                    //Delay between each answer
        StartCoroutine(SendRequestToGemini("Goodbyr!"));
        animatorController.SetInt("animation,7");
        audioManager.PlayIncorrectSound();                      //Plays Incorrect Sound











    }

    public IEnumerator SendRequestToGemini(string promptText)
    {
        // Create JSON data
        
        string url = $"{apiEndpoint}?key={apiKey}";
     
        string jsonData = "{\"contents\": [{\"parts\": [{\"text\": \"{" + promptText + "}\"}]}]}";

        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData);

        // Create a UnityWebRequest with the JSON data
        using (UnityWebRequest www = new UnityWebRequest(url, "POST")){
            www.uploadHandler = new UploadHandlerRaw(jsonToSend);
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success) {
                Debug.LogError(www.error);
            } else {
                Debug.Log("Request complete!");
                Response response = JsonUtility.FromJson<Response>(www.downloadHandler.text);
                if (response.candidates.Length > 0 && response.candidates[0].content.parts.Length > 0)
                    {
                        string text = response.candidates[0].content.parts[0].text;
                
                    textObject.text = text;
                        Debug.Log(text);
                    }
                else
                {
                    Debug.Log("No text found.");
                }


            }
        }
    }

}
}