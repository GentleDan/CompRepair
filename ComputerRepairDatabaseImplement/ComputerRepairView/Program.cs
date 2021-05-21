using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using ComputerRepairBusinessLogic.BusinessLogic;
using ComputerRepairBusinessLogic.Interfaces;
using ComputerRepairDatabaseImplement.Implements;

namespace ComputerRepairView
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
            currentContainer.RegisterType<IContractStorage, ContractStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICustomerBaseStorage, CustomerBaseStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEmployeeStorage, EmployeeStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMaterialsStorage, MaterialsStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPaymentStorage, PaymentStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IServicesStorage, ServicesStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ContractLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<CustomerBaseLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<EmployeeLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<MaterialsLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<PaymentLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ServicesLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
