namespace KioscoInformaticoDesktop.Views
{
    partial class VentasView
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dateTimeFecha = new DateTimePicker();
            lblFecha = new Label();
            cBFormasPago = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            cBClientes = new ComboBox();
            panel1 = new Panel();
            btnAgregar = new Button();
            label6 = new Label();
            numSubTotal = new NumericUpDown();
            label5 = new Label();
            numCantidad = new NumericUpDown();
            label4 = new Label();
            numPrecio = new NumericUpDown();
            label3 = new Label();
            cBProductos = new ComboBox();
            btnCancelar = new Button();
            GridDetalleVenta = new DataGridView();
            btnQuitar = new Button();
            btnFinalizarVenta = new Button();
            label7 = new Label();
            numericUpDown1 = new NumericUpDown();
            label8 = new Label();
            numericUpDown2 = new NumericUpDown();
            label9 = new Label();
            numericUpDown3 = new NumericUpDown();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSubTotal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GridDetalleVenta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            SuspendLayout();
            // 
            // dateTimeFecha
            // 
            dateTimeFecha.Enabled = false;
            dateTimeFecha.Format = DateTimePickerFormat.Short;
            dateTimeFecha.Location = new Point(812, 12);
            dateTimeFecha.Name = "dateTimeFecha";
            dateTimeFecha.Size = new Size(122, 27);
            dateTimeFecha.TabIndex = 0;
            dateTimeFecha.Value = new DateTime(2024, 10, 22, 14, 44, 46, 0);
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 10F);
            lblFecha.Location = new Point(748, 12);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(58, 23);
            lblFecha.TabIndex = 1;
            lblFecha.Text = "Fecha:";
            // 
            // cBFormasPago
            // 
            cBFormasPago.FormattingEnabled = true;
            cBFormasPago.Location = new Point(12, 75);
            cBFormasPago.Name = "cBFormasPago";
            cBFormasPago.Size = new Size(278, 28);
            cBFormasPago.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(12, 49);
            label1.Name = "label1";
            label1.Size = new Size(130, 23);
            label1.TabIndex = 3;
            label1.Text = "Forma de pago:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(314, 49);
            label2.Name = "label2";
            label2.Size = new Size(67, 23);
            label2.TabIndex = 5;
            label2.Text = "Cliente:";
            // 
            // cBClientes
            // 
            cBClientes.FormattingEnabled = true;
            cBClientes.Location = new Point(314, 75);
            cBClientes.Name = "cBClientes";
            cBClientes.Size = new Size(323, 28);
            cBClientes.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(btnAgregar);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(numSubTotal);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(numCantidad);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(numPrecio);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cBProductos);
            panel1.Location = new Point(12, 109);
            panel1.Name = "panel1";
            panel1.Size = new Size(922, 71);
            panel1.TabIndex = 8;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(800, 14);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(120, 49);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(559, 1);
            label6.Name = "label6";
            label6.Size = new Size(79, 23);
            label6.TabIndex = 13;
            label6.Text = "SubTotal:";
            // 
            // numSubTotal
            // 
            numSubTotal.DecimalPlaces = 2;
            numSubTotal.Enabled = false;
            numSubTotal.Location = new Point(559, 27);
            numSubTotal.Maximum = new decimal(new int[] { -1593835520, 466537709, 54210, 0 });
            numSubTotal.Name = "numSubTotal";
            numSubTotal.Size = new Size(169, 27);
            numSubTotal.TabIndex = 12;
            numSubTotal.TextAlign = HorizontalAlignment.Right;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(438, 0);
            label5.Name = "label5";
            label5.Size = new Size(83, 23);
            label5.TabIndex = 13;
            label5.Text = "Cantidad:";
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(438, 26);
            numCantidad.Maximum = new decimal(new int[] { -1593835520, 466537709, 54210, 0 });
            numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(104, 27);
            numCantidad.TabIndex = 12;
            numCantidad.TextAlign = HorizontalAlignment.Right;
            numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidad.ValueChanged += numCantidad_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(298, 0);
            label4.Name = "label4";
            label4.Size = new Size(61, 23);
            label4.TabIndex = 11;
            label4.Text = "Precio:";
            // 
            // numPrecio
            // 
            numPrecio.DecimalPlaces = 2;
            numPrecio.Enabled = false;
            numPrecio.Location = new Point(298, 26);
            numPrecio.Maximum = new decimal(new int[] { -1593835520, 466537709, 54210, 0 });
            numPrecio.Name = "numPrecio";
            numPrecio.Size = new Size(122, 27);
            numPrecio.TabIndex = 10;
            numPrecio.TextAlign = HorizontalAlignment.Right;
            numPrecio.ValueChanged += numPrecio_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(84, 23);
            label3.TabIndex = 9;
            label3.Text = "Producto:";
            // 
            // cBProductos
            // 
            cBProductos.FormattingEnabled = true;
            cBProductos.Location = new Point(3, 26);
            cBProductos.Name = "cBProductos";
            cBProductos.Size = new Size(273, 28);
            cBProductos.TabIndex = 8;
            cBProductos.SelectedIndexChanged += cBProductos_SelectedIndexChanged;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(12, 451);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 29);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // GridDetalleVenta
            // 
            GridDetalleVenta.AllowUserToAddRows = false;
            GridDetalleVenta.AllowUserToDeleteRows = false;
            GridDetalleVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            GridDetalleVenta.DefaultCellStyle = dataGridViewCellStyle1;
            GridDetalleVenta.Location = new Point(15, 191);
            GridDetalleVenta.Name = "GridDetalleVenta";
            GridDetalleVenta.ReadOnly = true;
            GridDetalleVenta.RowHeadersWidth = 51;
            GridDetalleVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridDetalleVenta.Size = new Size(780, 239);
            GridDetalleVenta.TabIndex = 10;
            GridDetalleVenta.DataBindingComplete += GridDetalleVenta_DataBindingComplete;
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(814, 272);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(120, 49);
            btnQuitar.TabIndex = 14;
            btnQuitar.Text = "Quitar";
            btnQuitar.UseVisualStyleBackColor = true;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // btnFinalizarVenta
            // 
            btnFinalizarVenta.Location = new Point(814, 431);
            btnFinalizarVenta.Name = "btnFinalizarVenta";
            btnFinalizarVenta.Size = new Size(120, 49);
            btnFinalizarVenta.TabIndex = 15;
            btnFinalizarVenta.Text = "Finalizar Venta";
            btnFinalizarVenta.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(259, 433);
            label7.Name = "label7";
            label7.Size = new Size(52, 23);
            label7.TabIndex = 15;
            label7.Text = "Neto:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Enabled = false;
            numericUpDown1.Location = new Point(259, 459);
            numericUpDown1.Maximum = new decimal(new int[] { -1593835520, 466537709, 54210, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(122, 27);
            numericUpDown1.TabIndex = 14;
            numericUpDown1.TextAlign = HorizontalAlignment.Right;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F);
            label8.Location = new Point(393, 433);
            label8.Name = "label8";
            label8.Size = new Size(40, 23);
            label8.TabIndex = 17;
            label8.Text = "IVA:";
            // 
            // numericUpDown2
            // 
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown2.Enabled = false;
            numericUpDown2.Location = new Point(393, 459);
            numericUpDown2.Maximum = new decimal(new int[] { -1593835520, 466537709, 54210, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(122, 27);
            numericUpDown2.TabIndex = 16;
            numericUpDown2.TextAlign = HorizontalAlignment.Right;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F);
            label9.Location = new Point(525, 433);
            label9.Name = "label9";
            label9.Size = new Size(46, 23);
            label9.TabIndex = 19;
            label9.Text = "Total";
            // 
            // numericUpDown3
            // 
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown3.Enabled = false;
            numericUpDown3.Location = new Point(525, 459);
            numericUpDown3.Maximum = new decimal(new int[] { -1593835520, 466537709, 54210, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(122, 27);
            numericUpDown3.TabIndex = 18;
            numericUpDown3.TextAlign = HorizontalAlignment.Right;
            // 
            // VentasView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(946, 492);
            ControlBox = false;
            Controls.Add(label9);
            Controls.Add(numericUpDown3);
            Controls.Add(label8);
            Controls.Add(numericUpDown2);
            Controls.Add(label7);
            Controls.Add(numericUpDown1);
            Controls.Add(btnFinalizarVenta);
            Controls.Add(btnQuitar);
            Controls.Add(GridDetalleVenta);
            Controls.Add(btnCancelar);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(cBClientes);
            Controls.Add(label1);
            Controls.Add(cBFormasPago);
            Controls.Add(lblFecha);
            Controls.Add(dateTimeFecha);
            Name = "VentasView";
            StartPosition = FormStartPosition.CenterParent;
            Text = "VentasView";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSubTotal).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)GridDetalleVenta).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimeFecha;
        private Label lblFecha;
        private ComboBox cBFormasPago;
        private Label label1;
        private Label label2;
        private ComboBox cBClientes;
        private Panel panel1;
        private Label label3;
        private ComboBox cBProductos;
        private Button btnCancelar;
        private Label label4;
        private NumericUpDown numPrecio;
        private Label label5;
        private NumericUpDown numCantidad;
        private Label label6;
        private NumericUpDown numSubTotal;
        private Button btnAgregar;
        private DataGridView GridDetalleVenta;
        private Button btnQuitar;
        private Button btnFinalizarVenta;
        private Label label7;
        private NumericUpDown numericUpDown1;
        private Label label8;
        private NumericUpDown numericUpDown2;
        private Label label9;
        private NumericUpDown numericUpDown3;
    }
}