namespace BulkInsert.Context;

public class ElectricityBill
{
    public long BillId { get; set; }
    public long CustomerID { get; set; }
    public DateTime BillingPeriodStart { get; set; }
    public DateTime BillingPeriodEnd { get; set; }
    public decimal TotalUsageKWh { get; set; }
}
