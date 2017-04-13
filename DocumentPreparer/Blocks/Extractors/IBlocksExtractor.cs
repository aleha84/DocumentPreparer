using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentPreparer.Blocks.Extractors
{
    public interface IBlocksExtractor
    {
        IDictionary<string, string> GetBlocks(string path);
    }
}
