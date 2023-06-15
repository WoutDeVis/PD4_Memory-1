using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace Memory.Data
{
    public class ImageRepository : Singleton<ImageRepository>
    {

        private string _urlMemoryImages = "http://localhost/MemoryGameAPI/api/Image";

        public void ProccesImageIds(Action<List<int>> processIds)
        {
            StartCoroutine(GetImageIds(processIds));
        }

        private IEnumerator GetImageIds(Action<List<int>> processIds)
        {
            UnityWebRequest uwrids = UnityWebRequest.Get(_urlMemoryImages + "/ids");
            yield return uwrids.SendWebRequest();
            if (uwrids.result != UnityWebRequest.Result.Success)
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
            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("ImageRepository.GetProcessMaterials: " + uwr.error);
            }
            else
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(uwr);
                processTexture(texture);
            }
        }


        public void AddCombination(int imageId)
        {
            StartCoroutine(PostCombination(imageId));
        }

        private IEnumerator PostCombination(int imageId)
        {
            string url = _urlMemoryImages + "/combinations?imageId=" + imageId;

            UnityWebRequest uwr = UnityWebRequest.Post(url, "");
            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("ImageRepository.AddCombination: " + uwr.error);

            }
            else
            {
                string response = uwr.downloadHandler.text;
                int combinationId = int.Parse(response);

            }
        }

        public void AddScore(string player, int score, int time)
        {
            StartCoroutine(PostScore(player, score, time));
        }
        public IEnumerator PostScore(string player, int score, int time)
        {
            string url = _urlMemoryImages + "/score";

            DBScore score1 = new DBScore()
            {
                Player = player,
                Score1 = score,
                Time = time
            };


            string json = JsonConvert.SerializeObject(score1);
            UnityWebRequest uwr = UnityWebRequest.Put(url, json);
            uwr.SetRequestHeader("content-type", "application/json");
            uwr.method = "POST";
            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                string response = uwr.downloadHandler.text;
                int scoreId = int.Parse(response);
                Debug.Log("Score added with ID: " + scoreId);

            }
        }

    }


    public partial class DBImage
    {
        public int ID { get; set; }

        public string Name { get; set; } = null!;

        public byte[] Image1 { get; set; } = null!;
    }
    public partial class DBScore
    {
        public int Id { get; set; }

        public string Player { get; set; } = null!;

        public int Score1 { get; set; }

        public int Time { get; set; }
    }


}
