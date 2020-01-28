using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.Postgresql.Models.Outputs
{
    public class SearchButtonResult
    {
        public List<DetailedResource> HardCopy { get; set; }
        public List<DetailedResource> Electron { get; set; }
    }
}
