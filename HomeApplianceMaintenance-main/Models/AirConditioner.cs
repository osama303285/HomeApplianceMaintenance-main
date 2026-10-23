using System;

namespace HomeApplianceMaintenance.Models
{
    // فئة المكيف ترث من الفئة المجردة Device
    public class AirConditioner : Device
    {
        // ميزة خاصة بالمكيف: قوة المكيف بالـ BTU (مثال: 12000 أو 24000 وحدة)
        private int _coolingCapacityBtu;

        public int CoolingCapacityBtu
        {
            get => _coolingCapacityBtu;
            set => _coolingCapacityBtu = value > 0 ? value : 12000;
        }

        public AirConditioner(string serialNumber, string model, double baseCost, int coolingCapacityBtu)
            : base(serialNumber, model, baseCost)
        {
            _coolingCapacityBtu = coolingCapacityBtu;
        }

        // --- تعدد الأشكال (Polymorphism) ---
        // حساب التكلفة: الأجهزة ذات السعة الكبيرة (أكبر من 18000 BTU) يضاف عليها 30$ صعوبة عمل
        public override double CalculateRepairCost()
        {
            double capacitySurcharge = _coolingCapacityBtu > 18000 ? 30.0 : 0.0;
            return BaseCost + capacitySurcharge;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"   [Air Conditioner] Capacity: {_coolingCapacityBtu} BTU | Total Cost: {CalculateRepairCost()}$");
        }
    }
}
