﻿using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using HospitalManagement.iOS;
using HospitalManagement;

[assembly: Dependency(typeof(SQLiteDb))]

namespace HospitalManagement.iOS
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); 
            var path = Path.Combine(documentsPath, "MySQLite.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}

