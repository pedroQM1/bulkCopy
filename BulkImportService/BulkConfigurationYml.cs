using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkImportService
{
    public class BulkConfigurationYml
    {

        public string ConnectionString { get; set; }
        public List<SchemaSection> SchemaSection { get; set; }
    }
    public class SchemaSection{
        
        public string FilePath { get; set; }
    }
}
