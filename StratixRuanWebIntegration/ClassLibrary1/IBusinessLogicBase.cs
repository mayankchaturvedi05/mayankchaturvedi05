using System;

namespace StratixRuanInterfaces
{
    public interface IBusinessLogicBase
    {
        long Number { get; set; }
        string Code { get; set; }
        string Description { get; set; }

        IBusinessLogicBase Parent { get; set; }
        bool IsNew { get;  }
        bool IsDeleted { get; }
        bool HasChanged { get; }

        DateTime? PostedOn { get; set; }
        DateTime? PostedAt { get; set; }
        long? PostedBy { get; set; }
        long? PostedStation { get; set; }

        DateTime? CreatedOn { get; set; }
        DateTime? CreatedAt { get; set; }
        long? CreatedBy { get; set; }
        long? CreatedStation { get; set; }

        DateTime? ChangedOn { get; set; }
        DateTime? ChangedAt { get; set; }
        long? ChangedStation { get; set; }
        long? ChangedBy { get; set; }

        DateTime? DeletedOn { get; set; }
        DateTime? DeletedAt { get; set; }
        long? DeletedStation { get; set; }
        long? DeletedBy { get; set; }

        bool Undelete(bool cascadeToChildren);

        string FieldFromColumn(string column);
        string ColumnFromField(string field);
        string DatabaseTable { get; }

        bool ValidateCode(string newCodeToValidate);
    }
}
