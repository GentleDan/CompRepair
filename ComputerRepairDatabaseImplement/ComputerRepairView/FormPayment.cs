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
    public partial class FormPayment : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set => id = value; }
        private readonly PaymentLogic logic;
        private int? id;
        public FormPayment(PaymentLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void FormPayment_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = logic.Read(new PaymentBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        dateTimePicker.Text = view.DateOfPayment.ToString();
                        textBoxSum.Text = view.Summ.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                logic.CreateOrUpdate(new PaymentBindingModel
                {
                    Id = id,
                    DateOfPayment = dateTimePicker.Value,
                    Summ = Convert.ToDecimal(textBoxSum.Text)
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
