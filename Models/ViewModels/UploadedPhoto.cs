﻿using System;
﻿using System.Diagnostics.CodeAnalysis;

namespace Models.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class UploadedPhoto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string GetPath
        {
            get { return String.Format("/Content/Photos/{0}", Name); }
        }
    }
}