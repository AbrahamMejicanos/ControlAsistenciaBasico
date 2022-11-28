namespace CapaPresentacion
{
    partial class Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTurno = new System.Windows.Forms.Button();
            this.btnSucursal = new System.Windows.Forms.Button();
            this.btnEmpleados = new System.Windows.Forms.Button();
            this.btnMarcaje = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTurno
            // 
            this.btnTurno.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTurno.Location = new System.Drawing.Point(12, 12);
            this.btnTurno.Name = "btnTurno";
            this.btnTurno.Size = new System.Drawing.Size(192, 124);
            this.btnTurno.TabIndex = 0;
            this.btnTurno.Text = "IR A TURNOS";
            this.btnTurno.UseVisualStyleBackColor = true;
            this.btnTurno.Click += new System.EventHandler(this.btnTurno_Click);
            // 
            // btnSucursal
            // 
            this.btnSucursal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSucursal.Location = new System.Drawing.Point(12, 208);
            this.btnSucursal.Name = "btnSucursal";
            this.btnSucursal.Size = new System.Drawing.Size(192, 124);
            this.btnSucursal.TabIndex = 1;
            this.btnSucursal.Text = "IR A SUCURSALES";
            this.btnSucursal.UseVisualStyleBackColor = true;
            this.btnSucursal.Click += new System.EventHandler(this.btnSucursal_Click);
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEmpleados.Location = new System.Drawing.Point(252, 12);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Size = new System.Drawing.Size(192, 124);
            this.btnEmpleados.TabIndex = 2;
            this.btnEmpleados.Text = "IR A EMPLEADOS";
            this.btnEmpleados.UseVisualStyleBackColor = true;
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // btnMarcaje
            // 
            this.btnMarcaje.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMarcaje.Location = new System.Drawing.Point(252, 208);
            this.btnMarcaje.Name = "btnMarcaje";
            this.btnMarcaje.Size = new System.Drawing.Size(192, 124);
            this.btnMarcaje.TabIndex = 3;
            this.btnMarcaje.Text = "MARCAJE";
            this.btnMarcaje.UseVisualStyleBackColor = true;
            this.btnMarcaje.Click += new System.EventHandler(this.btnMarcaje_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 344);
            this.Controls.Add(this.btnMarcaje);
            this.Controls.Add(this.btnEmpleados);
            this.Controls.Add(this.btnSucursal);
            this.Controls.Add(this.btnTurno);
            this.Name = "Principal";
            this.Text = "Principal";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnTurno;
        private Button btnSucursal;
        private Button btnEmpleados;
        private Button btnMarcaje;
    }
}