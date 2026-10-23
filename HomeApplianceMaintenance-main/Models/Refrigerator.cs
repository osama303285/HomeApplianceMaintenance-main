using System;

namespace HomeApplianceMaintenance.Models
{
    // فئة الثلاجة ترث من الفئة المجردة Device (وراثة)
    public class Refrigerator : Device
    {
        // ميزة خاصة بالثلاجة: هل تحتاج شحن غاز الفريون؟
        private bool _needsGasRefill;

        public bool NeedsGasRefill
        {
            get => _needsGasRefill;
            set => _needsGasRefill = value;
        }

        // مشيد الفئة يمرر القيم الأساسية للأب عبر كلمة base
        public Refrigerator(string serialNumber, string model, double baseCost, bool needsGasRefill)
            : base(serialNumber, model, baseCost)
        {
            _needsGasRefill = needsGasRefill;
        }

        // --- تعدد الأشكال (Polymorphism) ---
        // إعادة تعريف دالة حساب التكلفة بناءً على الميزات الخاصة بالثلاجة
        public override double CalculateRepairCost()
        {
            // التكلفة = التكلفة الأساسية + 50$ إضافية إذا كانت تحتاج شحن غاز
            double extraCharge = _needsGasRefill ? 50.0 : 0.0;
            return BaseCost + extraCharge;
        }

        // إعادة تعريف دالة عرض التفاصيل لتشمل الميزات الخاصة
        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"   [Refrigerator] Needs Gas Refill: {(_needsGasRefill ? "Yes" : "No")} | Total Cost: {CalculateRepairCost()}$");
        }
    }
}
