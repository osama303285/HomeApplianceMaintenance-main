// Reviewed and updated by: Eman (eman_331031)
    space HomeApplianceMaintenance.Interfaces
{
    // الواجهة تحدد العمليات الأساسية المشتركة بين جميع الأجهزة
    public interface IDevice
    {
        string SerialNumber { get; }
        string Model { get; }
        string MaintenanceStatus { get; set; }
        
        // دالة لعرض تفاصيل الجهاز
        void DisplayDetails();
    }
}
