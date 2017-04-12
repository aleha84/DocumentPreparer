using DocumentPreparer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentPreparer.Processers
{
    public interface IProcesser
    {
        DocumentModel Process(string inputPath);
    }
}
