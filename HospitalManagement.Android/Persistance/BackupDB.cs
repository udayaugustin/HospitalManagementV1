﻿using System;
using System.IO;
using HospitalManagement.Droid.Persistance;
using Xamarin.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HospitalManagement.Model.ResponseModel;

[assembly: Dependency(typeof(BackupDB))]

namespace HospitalManagement.Droid.Persistance
{
    public class BackupDB : IBackupDB
    {
        public async Task<bool> SyncDBAsync(string username)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MySQLite.db3");
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/x-www-form-urlencoded");
            var url = Constants.UploadFileUrl;
            
            using (var reader = new StreamReader(path))
            using (var content = new MultipartFormDataContent())
            {
                var data = reader.BaseStream;
                content.Add(new StreamContent(data), "fileToUpload", "MySQLite_" + DateTime.Now.ToString("d-MMM-yyyy-HH:mm:ss") + ".db3");
                content.Add(new StringContent(username), "Mobile");                

                var status = await httpClient.PostAsync(url, content);

                var response = await status.Content.ReadAsStringAsync();
                var backupResponse =  JsonConvert.DeserializeObject<BackupResponse>(response);

                if (status.IsSuccessStatusCode)
                {
                    if(backupResponse.Status == "success")
                        return true;
                }
            }

            return false;            
        }
    }
}