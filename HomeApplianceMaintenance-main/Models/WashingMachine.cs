using System;

namespace HomeApplianceMaintenance.Models
{
    // فئة الغسالة ترث من الفئة المجردة Device
    public class WashingMachine : Device
    {
        // ميزة خاصة بالغسالة: عدد قطع التبديل التالفة المستبدلة
        private int _replacedPartsCount;

        public int ReplacedPartsCount
        {
            get => _replacedPartsCount;
            set => _replacedPartsCount = value >= 0 ? value : 0;
        }

        public WashingMachine(string serialNumber, string model, double baseCost, int replacedPartsCount)
            : base(serialNumber, model, baseCost)
        {
            _replacedPartsCount = replacedPartsCount;
        }

        // --- تعدد الأشكال (Polymorphism) ---
        // حساب التكلفة: التكلفة الأساسية + 25$ عن كل قطعة تبديل
        public override double CalculateRepairCost()
        {
            return BaseCost + (_replacedPartsCount * 25.0);
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"   [Washing Machine] Replaced Parts: {_replacedPartsCount} | Total Cost: {CalculateRepairCost()}$");
        }
    }
}
