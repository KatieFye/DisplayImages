using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using DisplayImages.Models;
using Newtonsoft.Json;


namespace DisplayImages
{
    public class RetrieveData
    {
        public WebClient client { get; set; }
        public RetrieveData()
        {
            client = new WebClient();
        }
        public  void FirstAlbumThumnailByAlbumId(UserModel model)
        {
            PhotoModel photo = new PhotoModel();
            var photos = client.DownloadString("https://jsonplaceholder.typicode.com/photos?albumId=" + model.albums.First().id);
            photo = JsonConvert.DeserializeObject<List<PhotoModel>>(photos).First();
            model.photo = photo;
        }

        public  void AlbumInfoByUserId(List<UserModel> model)
        {
            foreach (var user in model)
            {
                var albums = client.DownloadString("https://jsonplaceholder.typicode.com/albums?userId=" + user.id);
                user.albums = JsonConvert.DeserializeObject<List<AlbumsModel>>(albums);
            }
        }

        public List<UserModel> UserInfo()
        {
            var text = client.DownloadString("https://jsonplaceholder.typicode.com/users");
            return JsonConvert.DeserializeObject<List<UserModel>>(text);
        }

        public UserModel UserInfoByUserId(int id)
        {
            var user = client.DownloadString("https://jsonplaceholder.typicode.com/users/" + id);
            return JsonConvert.DeserializeObject<UserModel>(user);
        }

        public List<PhotoModel> PhotosByAlbumId(int id)
        {
            var photo = client.DownloadString("https://jsonplaceholder.typicode.com/photos?albumId=" + id);
            return JsonConvert.DeserializeObject<List<PhotoModel>>(photo);
        }

        public List<UserPostsModel> PostsByUserId(int id)
        {
            var posts = client.DownloadString("https://jsonplaceholder.typicode.com/posts?userId=" + id);
            return JsonConvert.DeserializeObject<List<UserPostsModel>>(posts);
        }

        public string AlbumTitleByAlbumId(int id)
        {
            AlbumsModel model = new AlbumsModel();
            var albums = client.DownloadString("https://jsonplaceholder.typicode.com/albums?id=" + id);
            model = JsonConvert.DeserializeObject<List<AlbumsModel>>(albums).First();
            return model.title;
        }


    }
}