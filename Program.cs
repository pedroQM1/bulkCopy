


using BulkImporter;
using ImportManagerer;



var connection = @"Persist Security Info=False;User ID=sqlserver;Password=dfZj7Dw!i$KIn7udQTddRNl@f#b3qWV;Initial Catalog=EmprestimoConvalescente;Data Source=35.224.95.73;MultipleActiveResultSets=true";
var filePath = @"C:\Users\topvi\Downloads\teste111.csv";


var configuration = new BulkImportConfiguration()
{
    ConnectionString= connection,
    DeistinationTable = "GrupoEquipamento",
};

using (var import = ImportManager.CreateImportCsvWhitTypeClass<SchemaGrupo>(configuration))
{
    import.ImportFile(filePath);
}


Console.ReadLine();

public class SchemaGrupo 
{
    public int Id { get; set; }
    public string GrupoEconomicoID { get; set; }
    public bool Ativo { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CriadoPor { get; set; }
    public string AlteradoPor { get; set; }
    public string Descricao { get; set; }
    public int Status { get; set; }

}









