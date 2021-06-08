using System.Data.Linq.Mapping;

namespace StratixRuanInterfaces
{
    public interface IHaveNumberCodeDescription
    {
        long Number { get; set; }
        [Column(DbType = "VarChar(32)")]
        string Code { get; set; }
        string Description { get; set; }
    }

    public interface IHasSelectedNumberCodeDescription
    {
        IHaveNumberCodeDescription SelectedItem { get; }
    }
}
