using System;
using System.Collections.Generic;
using HomeApplianceMaintenance.Interfaces;

namespace HomeApplianceMaintenance.Services
{
    // 1. تعريف التفويض (Delegate) الخاص بإشعارات حالة الصيانة
    public delegate void MaintenanceStatusHandler(string message);

    public class MaintenanceManager
    {
        // قائمة لإدارة الأجهزة باستخدام الواجهة المشتركة (تعدد أشكال)
        private readonly List<IDevice> _devices;

        // 2. تعريف الحدث (Event) الذي ينطلق عند تغير الحالة
        public event MaintenanceStatusHandler? OnStatusChanged;


        public MaintenanceManager()
        {
            _devices = new List<IDevice>();
        }

        // دالة لإضافة جهاز جديد للنظام بعد التحقق من رقمه التسلسلي
        public void AddDevice(IDevice device)
        {
            if (ValidationUtils.IsValidSerialNumber(device.SerialNumber))
            {
                _devices.Add(device);
                Console.WriteLine($"[Manager] Device {device.SerialNumber} added successfully.");
            }
            else
            {
                Console.WriteLine($"[Error] Invalid Serial Number format for {device.SerialNumber}. Must be (SN-XXXX)");
            }
        }

        // دالة لتحديث حالة الجهاز وإطلاق الحدث (Event) تلقائياً
        public void UpdateDeviceStatus(string serialNumber, string newStatus)
        {
            var device = _devices.Find(d => d.SerialNumber == serialNumber);
            if (device != null)
            {
                device.MaintenanceStatus = newStatus;
                
                // إطلاق الحدث إذا كان هناك من يشترك به (Notification Subscribed)
                OnStatusChanged?.Invoke($"[Alert] Device with Serial {serialNumber} status has been updated to: {newStatus}.");
            }
            else
            {
                Console.WriteLine($"[Manager] Device with Serial {serialNumber} not found.");
            }
        }

        // دالة تستخدم تعدد الأشكال لعرض تفاصيل جميع الأجهزة وحساب التكلفة الكلية
        public void DisplayAllDevicesReport()
        {
            Console.WriteLine("\n=== MAINTENANCE CENTER REPORT ===");
            double totalCenterCosts = 0;

            foreach (var device in _devices)
            {
                // استدعاء دالة عرض التفاصيل (تعدد أشكال ديناميكي)
                device.DisplayDetails();

                // تحويل الكائن بأمان للوصول لدالة حساب التكلفة الخاصة بكل فئة ابنة
                if (device is Models.Device baseDevice)
                {
                    totalCenterCosts += baseDevice.CalculateRepairCost();
                }
            }

            Console.WriteLine($"=================================");
            Console.WriteLine($"Total Expected Maintenance Revenue: {totalCenterCosts}$");
            Console.WriteLine("=================================\n");
        }
    }
}
