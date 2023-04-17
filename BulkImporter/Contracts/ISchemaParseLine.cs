using System.Data;

namespace BulkImporter.Contracts;
public interface ISchemaParseLine : IDisposable
{
    public DataTable DataTable {get;}
    public void Reader(string line);
}
