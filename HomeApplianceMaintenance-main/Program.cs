using System;
using HomeApplianceMaintenance.Models;
using HomeApplianceMaintenance.Services;

namespace HomeApplianceMaintenance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Welcome to Home Appliance Maintenance System ---\n");

            // 1. إنشاء مدير الصيانة
            MaintenanceManager manager = new MaintenanceManager();

            // 2. الاشتراك في الحدث (Event Subscription) لتلقي التنبيهات
            manager.OnStatusChanged += ShowNotification;

            // 3. إنشاء أجهزة تجريبية وتطبيق مفاهيم الوراثة والتغليف
            // ثلاجة تحتاج شحن غاز
            Refrigerator fridge = new Refrigerator("SN-1001", "Samsung TwinTech", 150.0, true);
            // غسالة تم تبديل قطعتين فيها
            WashingMachine washer = new WashingMachine("SN-1002", "LG DirectDrive", 200.0, 2);
            // مكيف قدرته كبيرة (أكبر من 18000 BTU)
            AirConditioner ac = new AirConditioner("SN-1003", "Gree Eco", 250.0, 24000);
            // جهاز برقم تسلسلي خاطئ لاختبار الفئة الثابتة للتحقق
            Refrigerator invalidDevice = new Refrigerator("WRONG-ID", "Generic", 100.0, false);

            Console.WriteLine("--- Registering Devices ---");
            manager.AddDevice(fridge);
            manager.AddDevice(washer);
            manager.AddDevice(ac);
            manager.AddDevice(invalidDevice); // سيطبع خطأ ولن يضيفه

            // 4. طباعة التقرير الأول (تعدد الأشكال وحساب التكاليف)
            manager.DisplayAllDevicesReport();

            // 5. تحديث الحالات واختبار نظام الأحداث (Events)
            Console.WriteLine("--- Updating Device Statuses (Testing Events) ---");
            manager.UpdateDeviceStatus("SN-1001", "Ready for Delivery");
            manager.UpdateDeviceStatus("SN-1002", "Repairing");

            // 6. طباعة التقرير النهائي بعد التحديث
            manager.DisplayAllDevicesReport();

            Console.ReadKey();
        }

        // الدالة التي يتم استدعاؤها تلقائياً عند إطلاق الحدث
        static void ShowNotification(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
