using DocumentPreparer.Models;
using Novacode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentPreparer.Processers
{
    public interface ITemplateProcesser
    {
        DocX Process(string templatePath, DocumentModel generalInfo);
    }
}
