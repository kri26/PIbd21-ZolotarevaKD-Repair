﻿using RepairBusinessLogic.BusinessLogic;
using RepairBusinessLogic.Interfaces;
using RepairListImplement.Implements;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace RepairView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IMaterialLogic, MaterialLogic>(
                new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IRepairWorkLogic, RepairWorkLogic>(
                new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderLogic, OrderLogic>(
                new HierarchicalLifetimeManager());
            currentContainer.RegisterType<MainLogic>(
                new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
