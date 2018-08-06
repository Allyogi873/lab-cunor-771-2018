namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCadToBin = new System.Windows.Forms.Button();
            this.txtEntrada = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSalida = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBinToCad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCadToBin
            // 
            this.btnCadToBin.Location = new System.Drawing.Point(572, 53);
            this.btnCadToBin.Name = "btnCadToBin";
            this.btnCadToBin.Size = new System.Drawing.Size(174, 71);
            this.btnCadToBin.TabIndex = 0;
            this.btnCadToBin.Text = "Cadena a Binario";
            this.btnCadToBin.UseVisualStyleBackColor = true;
            this.btnCadToBin.Click += new System.EventHandler(this.btnCadToBin_Click);
            // 
            // txtEntrada
            // 
            this.txtEntrada.Location = new System.Drawing.Point(50, 53);
            this.txtEntrada.Multiline = true;
            this.txtEntrada.Name = "txtEntrada";
            this.txtEntrada.Size = new System.Drawing.Size(516, 109);
            this.txtEntrada.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mensaje Original";
            // 
            // txtSalida
            // 
            this.txtSalida.Location = new System.Drawing.Point(50, 235);
            this.txtSalida.Multiline = true;
            this.txtSalida.Name = "txtSalida";
            this.txtSalida.Size = new System.Drawing.Size(516, 109);
            this.txtSalida.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Salida:";
            // 
            // btnBinToCad
            // 
            this.btnBinToCad.Location = new System.Drawing.Point(572, 151);
            this.btnBinToCad.Name = "btnBinToCad";
            this.btnBinToCad.Size = new System.Drawing.Size(174, 71);
            this.btnBinToCad.TabIndex = 5;
            this.btnBinToCad.Text = "Binario a Cadena";
            this.btnBinToCad.UseVisualStyleBackColor = true;
            this.btnBinToCad.Click += new System.EventHandler(this.btnBinToCad_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 517);
            this.Controls.Add(this.btnBinToCad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSalida);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEntrada);
            this.Controls.Add(this.btnCadToBin);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCadToBin;
        private System.Windows.Forms.TextBox txtEntrada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSalida;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBinToCad;
    }
}

