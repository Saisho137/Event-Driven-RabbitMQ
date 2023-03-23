namespace PublicadorSistemaTransaccional
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tbCuentaOrigen = new TextBox();
            tbCuentaInscrita = new TextBox();
            tbCedula = new TextBox();
            Button = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 48);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 0;
            label1.Text = "Cuenta Origen";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 96);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 1;
            label2.Text = "Cuenta Inscrita";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 148);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 2;
            label3.Text = "Cédula Titular";
            // 
            // tbCuentaOrigen
            // 
            tbCuentaOrigen.Location = new Point(158, 45);
            tbCuentaOrigen.Name = "tbCuentaOrigen";
            tbCuentaOrigen.Size = new Size(200, 23);
            tbCuentaOrigen.TabIndex = 5;
            // 
            // tbCuentaInscrita
            // 
            tbCuentaInscrita.Location = new Point(158, 93);
            tbCuentaInscrita.Name = "tbCuentaInscrita";
            tbCuentaInscrita.Size = new Size(200, 23);
            tbCuentaInscrita.TabIndex = 6;
            // 
            // tbCedula
            // 
            tbCedula.Location = new Point(158, 145);
            tbCedula.Name = "tbCedula";
            tbCedula.Size = new Size(200, 23);
            tbCedula.TabIndex = 7;
            // 
            // Button
            // 
            Button.Location = new Point(158, 204);
            Button.Name = "Button";
            Button.Size = new Size(75, 23);
            Button.TabIndex = 8;
            Button.Text = "Inscribir";
            Button.UseVisualStyleBackColor = true;
            Button.Click += Button_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(411, 258);
            Controls.Add(Button);
            Controls.Add(tbCedula);
            Controls.Add(tbCuentaInscrita);
            Controls.Add(tbCuentaOrigen);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbCuentaOrigen;
        private TextBox tbCuentaInscrita;
        private TextBox tbCedula;
        private Button Button;
    }
}