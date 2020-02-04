using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.Postgresql.Models.Inputs
{
    public class UploadedElectronResource
    {
        public string ResourceName { get; set; }
        public IFormFile ResourcePdf { get; set; }
    }
}
