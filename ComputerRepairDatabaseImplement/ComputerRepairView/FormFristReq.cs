using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComputerRepairBusinessLogic.BusinessLogic;
using Unity;

namespace ComputerRepairView
{
    public partial class FormFristReq : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly EmployeeLogic employeeLogic;
        private readonly CustomerBaseLogic customerBaseLogic;
        private readonly ServicesLogic servicesLogic;
        public FormFristReq(EmployeeLogic employeeLogic, CustomerBaseLogic customerBaseLogic, ServicesLogic servicesLogic)
        {
            InitializeComponent();
            this.employeeLogic = employeeLogic;
            this.customerBaseLogic = customerBaseLogic;
            this.servicesLogic = servicesLogic;
        }
        private void LoadData()
        {
            try
            {
                var employee = employeeLogic.Read(null);
                var customer = customerBaseLogic.Read(null);
                var services = servicesLogic.Read(null);
                if (employee != null && customer != null && services != null)
                {
                    dataGridViewFirstReq.DataSource = employee;
                    dataGridViewFirstReq.DataSource = customer;
                    dataGridViewFirstReq.DataSource = services;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
