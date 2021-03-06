﻿using Cursovaya.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Cursovaya.DAL
{
    class Dao
    {
        FileCabinet fileCabinet;
        const string filePath = "fileCabinet.bin";

        public Dao(FileCabinet store)
        {
            this.fileCabinet = store;
        }

        public void Save()
        {
            using (Stream stream = File.Create(filePath))
            {
                var serializer = new BinaryFormatter();
                serializer.Serialize(stream, fileCabinet);
            }
        }

        public void Load()
        {
            using (Stream stream = File.OpenRead(filePath))
            {
                var serializer = new BinaryFormatter();
                FileCabinet st = (FileCabinet)serializer.Deserialize(stream);
                Copy(st.Criminals, fileCabinet.Criminals);
                Copy(st.CriminalGangs, fileCabinet.CriminalGangs);                
            }

            void Copy<T>(List<T> from, List<T> to)
            {
                to.Clear();
                to.AddRange(from);
            }
        }
    }
}
