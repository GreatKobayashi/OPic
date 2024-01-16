﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RiotApiController.Domain.Logics
{
    public static class JsonSerializerHelper
    {
        public static T Deserialize<T>(string filePath)
        {
            using (FileStream fileStream = File.OpenRead(filePath))
            {
                using (StreamReader reader = new StreamReader(fileStream, Encoding.UTF8))
                {
#pragma warning disable CS8603
                    return JsonSerializer.Deserialize<T>(reader.ReadToEnd());
#pragma warning restore CS8603
                }
            }
        }
    }
}