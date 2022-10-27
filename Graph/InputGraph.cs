using System.Drawing;
using System.Windows.Forms;

namespace Graph
{
    public class InputGraph
    {      
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            #region Design
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(8, 8, 104, 20);
            textBox.SetBounds(12, 31, 283, 27);
            buttonOk.SetBounds(12, 65, 75, 30);
            buttonCancel.SetBounds(93, 65, 75, 30);

            label.AutoSize = true;

            form.ClientSize = new Size(307, 111);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            form.StartPosition = FormStartPosition.CenterParent;
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;
            #endregion

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
    }
}
