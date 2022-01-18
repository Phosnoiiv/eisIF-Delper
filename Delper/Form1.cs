using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EverISay.LoveLive.SIF.Delper {
    public partial class Form1:Form {
        public Form1() {
            InitializeComponent();
        }

        private void OpenFormCard1(object sender, EventArgs e) {
            FormCard1 form = new FormCard1 {
                MdiParent = this,
            };
            form.Show();
        }
    }
}
