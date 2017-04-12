using DocumentPreparer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentPreparer.Retrievers
{
    public interface IPropertiesRetrievers
    {
        Dictionary<string, PropertyRetriever> Get();
    }
}
