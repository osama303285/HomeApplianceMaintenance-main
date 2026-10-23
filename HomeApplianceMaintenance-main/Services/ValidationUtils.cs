using System;
using System.Text.RegularExpressions;

namespace HomeApplianceMaintenance.Services
{
    // فئة ثابتة (Static Class) لا يمكن إنشاء كائنات منها
    public static class ValidationUtils
    {
        // دالة ثابتة للتحقق من صيغة الرقم التسلسلي (يجب أن يبدأ بـ SN متبوعاً بأرقام)
        public static bool IsValidSerialNumber(string serialNumber)
        {
            if (string.IsNullOrWhiteSpace(serialNumber))
                return false;

            // التحقق باستخدام التعبير النمطي (Regex)
            return Regex.IsMatch(serialNumber, @"^SN-\d+$");
        }

        // دالة ثابتة للتأكد من أن القيمة المالية ليست سالبة
        public static bool IsValidCost(double cost)
        {
            return cost >= 0;
        }
    }
}
