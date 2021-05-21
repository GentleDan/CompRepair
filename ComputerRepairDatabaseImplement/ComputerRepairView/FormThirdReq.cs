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
    public partial class FormThirdReq : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly EmployeeLogic employeeLogic;
        private readonly PaymentLogic paymentLogic;
        public FormThirdReq(EmployeeLogic employeeLogic, PaymentLogic paymentLogic)
        {
            InitializeComponent();
            this.employeeLogic = employeeLogic;
            this.paymentLogic = paymentLogic;
        }
        private void LoadData()
        {
            try
            {
                var employee = employeeLogic.Read(null);
                var payment = paymentLogic.Read(null);
                if (employee != null && payment != null)
                {
                    dataGridViewFirstReq.DataSource = employee;
                    dataGridViewFirstReq.DataSource = payment;
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
