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
    public partial class FormSecondRec : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly EmployeeLogic employeeLogic;
        private readonly ContractLogic contractLogic;
        public FormSecondRec(EmployeeLogic employeeLogic, ContractLogic contractLogic)
        {
            InitializeComponent();
            this.employeeLogic = employeeLogic;
            this.contractLogic = contractLogic;
        }
        private void LoadData()
        {
            try
            {
                var employee = employeeLogic.Read(null);
                var contract = contractLogic.Read(null);
                if (employee != null  && contract != null)
                {
                    dataGridViewFirstReq.DataSource = employee;
                    dataGridViewFirstReq.DataSource = contract;
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
