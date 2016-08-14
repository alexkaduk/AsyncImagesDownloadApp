using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncImagesDownloadApp
{
    class Data
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string TextBoxComponentName { get; set; }
        public string ImageComponentName { get; set; }
        public string DownloadedImagePath { get; set; }

        public byte[] DownLoadedImageContent;
    }
}
