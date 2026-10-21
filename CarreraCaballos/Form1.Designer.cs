namespace CarreraCaballos
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
            btnEmpezar = new Button();
            btnReiniciar = new Button();
            progressCaballo1 = new ProgressBar();
            progressCaballo2 = new ProgressBar();
            progressCaballo3 = new ProgressBar();
            progressCaballo4 = new ProgressBar();
            lblCaballo1 = new Label();
            lblCaballo2 = new Label();
            lblCaballo3 = new Label();
            lblCaballo4 = new Label();
            lblResultado = new Label();
            SuspendLayout();
            // 
            // btnEmpezar
            // 
            btnEmpezar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEmpezar.Location = new Point(53, 27);
            btnEmpezar.Name = "btnEmpezar";
            btnEmpezar.Size = new Size(129, 47);
            btnEmpezar.TabIndex = 0;
            btnEmpezar.Text = "Empezar";
            btnEmpezar.UseVisualStyleBackColor = true;
            btnEmpezar.Click += btnEmpezar_Click_1;
            // 
            // btnReiniciar
            // 
            btnReiniciar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReiniciar.Location = new Point(224, 27);
            btnReiniciar.Name = "btnReiniciar";
            btnReiniciar.Size = new Size(129, 47);
            btnReiniciar.TabIndex = 1;
            btnReiniciar.Text = "Reiniciar";
            btnReiniciar.UseVisualStyleBackColor = true;
            btnReiniciar.Click += btnReiniciar_Click_1;
            // 
            // progressCaballo1
            // 
            progressCaballo1.Location = new Point(151, 100);
            progressCaballo1.Name = "progressCaballo1";
            progressCaballo1.Size = new Size(466, 45);
            progressCaballo1.TabIndex = 2;
            // 
            // progressCaballo2
            // 
            progressCaballo2.Location = new Point(151, 184);
            progressCaballo2.Name = "progressCaballo2";
            progressCaballo2.Size = new Size(466, 45);
            progressCaballo2.TabIndex = 3;
            // 
            // progressCaballo3
            // 
            progressCaballo3.Location = new Point(151, 263);
            progressCaballo3.Name = "progressCaballo3";
            progressCaballo3.Size = new Size(466, 45);
            progressCaballo3.TabIndex = 4;
            // 
            // progressCaballo4
            // 
            progressCaballo4.Location = new Point(151, 345);
            progressCaballo4.Name = "progressCaballo4";
            progressCaballo4.Size = new Size(466, 45);
            progressCaballo4.TabIndex = 5;
            // 
            // lblCaballo1
            // 
            lblCaballo1.AutoSize = true;
            lblCaballo1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCaballo1.Location = new Point(53, 115);
            lblCaballo1.Name = "lblCaballo1";
            lblCaballo1.Size = new Size(53, 15);
            lblCaballo1.TabIndex = 6;
            lblCaballo1.Text = "Caballo1";
            // 
            // lblCaballo2
            // 
            lblCaballo2.AutoSize = true;
            lblCaballo2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCaballo2.Location = new Point(53, 201);
            lblCaballo2.Name = "lblCaballo2";
            lblCaballo2.Size = new Size(53, 15);
            lblCaballo2.TabIndex = 7;
            lblCaballo2.Text = "Caballo2";
            // 
            // lblCaballo3
            // 
            lblCaballo3.AutoSize = true;
            lblCaballo3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCaballo3.Location = new Point(53, 280);
            lblCaballo3.Name = "lblCaballo3";
            lblCaballo3.Size = new Size(53, 15);
            lblCaballo3.TabIndex = 8;
            lblCaballo3.Text = "Caballo3";
            // 
            // lblCaballo4
            // 
            lblCaballo4.AutoSize = true;
            lblCaballo4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCaballo4.Location = new Point(53, 362);
            lblCaballo4.Name = "lblCaballo4";
            lblCaballo4.Size = new Size(53, 15);
            lblCaballo4.TabIndex = 9;
            lblCaballo4.Text = "Caballo4";
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResultado.Location = new Point(642, 237);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(40, 15);
            lblResultado.TabIndex = 10;
            lblResultado.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblResultado);
            Controls.Add(lblCaballo4);
            Controls.Add(lblCaballo3);
            Controls.Add(lblCaballo2);
            Controls.Add(lblCaballo1);
            Controls.Add(progressCaballo4);
            Controls.Add(progressCaballo3);
            Controls.Add(progressCaballo2);
            Controls.Add(progressCaballo1);
            Controls.Add(btnReiniciar);
            Controls.Add(btnEmpezar);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEmpezar;
        private Button btnReiniciar;
        private ProgressBar progressCaballo1;
        private ProgressBar progressCaballo2;
        private ProgressBar progressCaballo3;
        private ProgressBar progressCaballo4;
        private Label lblResultado;
        private Label lblCaballo2;
        private Label lblCaballo3;
        private Label lblCaballo4;
        private Label lblCaballo1;
    }
}
