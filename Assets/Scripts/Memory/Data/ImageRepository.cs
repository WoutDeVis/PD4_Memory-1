using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class ImageRepository : Singleton<ImageRepository> 
{

    private string _urlMemoryImages = "http://localhost/MemoryGameAPI/api/Image";

    public void ProccesImageIds(Action<List<int>> processIds)
    {
        StartCoroutine(GetImageIds(processIds));
    }

    private IEnumerator GetImageIds(Action<List<int>> processIds)
    {
        UnityWebRequest uwrids = UnityWebRequest.Get(_urlMemoryImages+"/ids");
        yield return uwrids.SendWebRequest();
        if(uwrids.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("ImageRepository.GetImageIDs: " + uwrids.error);
        }
        else
        {
            
            string json = uwrids.downloadHandler.text;
            List<int> imagedbids = JsonConvert.DeserializeObject<List<int>>(json);
            //images = images.Where(i => !i.IsBack).ToList();



            //List<int> imagedbids = images.Select(i => i.ID).ToList();
            processIds(imagedbids);
        }
    }



    public void GetProcessTexture(int imgdbid, Action<Texture2D> processTexture)
    {
        StartCoroutine(GetTexture(imgdbid, processTexture));
    }

    private IEnumerator GetTexture(int imgdbid, Action<Texture2D> processTexture)
    {
        UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(_urlMemoryImages + "/" + imgdbid);
        yield return uwr.SendWebRequest();
        if(uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("ImageRepository.GetProcessMaterials: " + uwr.error);
        }
        else
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(uwr);
            processTexture(texture);
        }
    }
}






public partial class DBImage
{
    public int ID { get; set; }

    public string Name { get; set; } = null!;

    public byte[] Image1 { get; set; } = null!;
}
