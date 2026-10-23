using System;
using HomeApplianceMaintenance.Interfaces;

namespace HomeApplianceMaintenance.Models
{
    // الفئة المجردة تطبق الواجهة وتحتوي على الخصائص المشتركة
    public abstract class Device : IDevice
    {
        // --- التغليف (Encapsulation) ---
        // جميع الحقول خاصة (private) ولا يمكن الوصول إليها مباشرة من الخارج
        private readonly string _serialNumber; 
        private readonly string _model;
        private string _maintenanceStatus;
        private double _baseCost;

        // --- الخصائص (Properties) للتحكم بالوصول ---
        
        // رقم الجهاز التسلسلي: للقراءة فقط بعد إنشاء الكائن (لا يحتوي على set)
        public string SerialNumber => _serialNumber;

        // موديل الجهاز: للقراءة فقط بعد الإنشاء
        public string Model => _model;

        // حالة الصيانة: يمكن قراءتها وتعديلها (مثال: قيد الإصلاح، جاهز)
        public string MaintenanceStatus
        {
            get => _maintenanceStatus;
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _maintenanceStatus = value;
            }
        }

        // التكلفة الأساسية للجهاز (محمية لتراها الفئات الابنة فقط)
        protected double BaseCost
        {
            get => _baseCost;
            set => _baseCost = value > 0 ? value : 0; // التأكد من عدم إدخال قيمة سالبة
        }

        // مشيد الفئة (Constructor) لتهيئ القيم الثابتة عند الإنشاء
        protected Device(string serialNumber, string model, double baseCost)
        {
            _serialNumber = serialNumber;
            _model = model;
            _baseCost = baseCost;
            _maintenanceStatus = "Under Review"; // الحالة الافتراضية عند دخول المركز
        }

        // --- التجريد (Abstraction) ---
        // دالة مجردة واحدة على الأقل لحساب تكلفة الإصلاح (ستعيد الفئات الابنة تعريفها)
        public abstract double CalculateRepairCost();

        // تطبيق دالة عرض التفاصيل المشتركة
        public virtual void DisplayDetails()
        {
            Console.WriteLine($"[Device] Serial: {SerialNumber} | Model: {Model} | Status: {MaintenanceStatus}");
        }
    }
}
