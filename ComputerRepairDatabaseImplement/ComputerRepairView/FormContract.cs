using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using ComputerRepairBusinessLogic.BusinessLogic;
using ComputerRepairBusinessLogic.BindingModels;

namespace ComputerRepairView
{
    public partial class FormContract : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public EmployeeLogic eLogic;
        public CustomerBaseLogic cLogic;
        public PaymentLogic pLogic;
        public MaterialsLogic mLogic;
        public ServicesLogic sLogic;
        public ContractLogic conogic;
        public int Id { set => id = value; }
        private int? id;
        public FormContract(EmployeeLogic eLogic, CustomerBaseLogic cLogic, PaymentLogic pLogic, MaterialsLogic mLogic, ServicesLogic sLogic, ContractLogic conogic)
        {
            InitializeComponent();
            this.eLogic = eLogic;
            this.cLogic = cLogic;
            this.pLogic = pLogic;
            this.mLogic = mLogic;
            this.sLogic = sLogic;
            this.conogic = conogic;
        }

        private void FormContract_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var employee = eLogic.Read(null);
                if (employee != null)
                {
                    comboBoxEmployee.DataSource = employee;
                }
                var customer = cLogic.Read(null);
                if (customer != null)
                {
                    comboBoxCustomer.DataSource = employee;
                }
                var material = eLogic.Read(null);
                if (material != null)
                {
                    comboBoxMaterial.DataSource = employee;
                }
                var service = eLogic.Read(null);
                if (service != null)
                {
                    comboBoxService.DataSource = employee;
                }
                var payment = eLogic.Read(null);
                if (payment != null)
                {
                    comboBoxPayment.DataSource = employee;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                conogic.CreateOrUpdate(new ContractBindingModel
                {
                    Id = id,
                    DateOfConclusion = dateTimePickerConclusion.Value,
                    CustomerBaseId = comboBoxCustomer.SelectedValue,
                    EmployeeId = comboBoxEmployee.SelectedValue,
                    PaymentId = comboBoxPayment.SelectedValue
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
