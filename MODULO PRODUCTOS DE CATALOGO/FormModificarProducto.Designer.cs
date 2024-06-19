namespace MODULO_PRODUCTOS_DE_CATALOGO
{
    partial class FormModificarProducto
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
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.imagen = new System.Windows.Forms.PictureBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnSubirFoto = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtPrecio = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnModificarProducto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagen)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(25)))), ((int)(((byte)(47)))));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(22, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(585, 73);
            this.label3.TabIndex = 72;
            this.label3.Text = "Modificar Producto";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::MODULO_PRODUCTOS_DE_CATALOGO.Properties.Resources.cierre;
            this.pictureBox2.Location = new System.Drawing.Point(974, 19);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(84, 77);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 69;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtProducto);
            this.groupBox1.Controls.Add(this.txtNombreProducto);
            this.groupBox1.Controls.Add(this.imagen);
            this.groupBox1.Controls.Add(this.txtTotal);
            this.groupBox1.Controls.Add(this.btnSubirFoto);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtDescripcion);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.TxtPrecio);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtProveedor);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCantidad);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(35, 235);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(980, 481);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MODIFICAR PRODUCTO";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(272, 95);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 36);
            this.label1.TabIndex = 66;
            this.label1.Text = "Nombre del producto:";
            // 
            // txtProducto
            // 
            this.txtProducto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtProducto.Enabled = false;
            this.txtProducto.Location = new System.Drawing.Point(278, 48);
            this.txtProducto.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(76, 32);
            this.txtProducto.TabIndex = 67;
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNombreProducto.Location = new System.Drawing.Point(580, 95);
            this.txtNombreProducto.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(372, 32);
            this.txtNombreProducto.TabIndex = 65;
            this.txtNombreProducto.TextChanged += new System.EventHandler(this.txtNombreProducto_TextChanged);
            // 
            // imagen
            // 
            this.imagen.BackColor = System.Drawing.Color.Silver;
            this.imagen.Location = new System.Drawing.Point(24, 47);
            this.imagen.Margin = new System.Windows.Forms.Padding(6);
            this.imagen.Name = "imagen";
            this.imagen.Size = new System.Drawing.Size(207, 176);
            this.imagen.TabIndex = 62;
            this.imagen.TabStop = false;
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(411, 261);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(130, 32);
            this.txtTotal.TabIndex = 53;
            // 
            // btnSubirFoto
            // 
            this.btnSubirFoto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSubirFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))));
            this.btnSubirFoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubirFoto.FlatAppearance.BorderColor = System.Drawing.Color.DarkMagenta;
            this.btnSubirFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubirFoto.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubirFoto.ForeColor = System.Drawing.Color.White;
            this.btnSubirFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubirFoto.Location = new System.Drawing.Point(10, 235);
            this.btnSubirFoto.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSubirFoto.Name = "btnSubirFoto";
            this.btnSubirFoto.Size = new System.Drawing.Size(244, 58);
            this.btnSubirFoto.TabIndex = 56;
            this.btnSubirFoto.Text = "Subir foto";
            this.btnSubirFoto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSubirFoto.UseVisualStyleBackColor = false;
            this.btnSubirFoto.Click += new System.EventHandler(this.btnSubirFoto_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(272, 261);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 36);
            this.label2.TabIndex = 52;
            this.label2.Text = "TOTAL:";
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtDescripcion.Location = new System.Drawing.Point(221, 334);
            this.TxtDescripcion.Margin = new System.Windows.Forms.Padding(6);
            this.TxtDescripcion.Multiline = true;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(748, 112);
            this.TxtDescripcion.TabIndex = 50;
            this.TxtDescripcion.TextChanged += new System.EventHandler(this.TxtDescripcion_TextChanged);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(654, 203);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 36);
            this.label9.TabIndex = 32;
            this.label9.Text = "Cantidad:";
            // 
            // TxtPrecio
            // 
            this.TxtPrecio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtPrecio.Location = new System.Drawing.Point(411, 203);
            this.TxtPrecio.Margin = new System.Windows.Forms.Padding(6);
            this.TxtPrecio.Name = "TxtPrecio";
            this.TxtPrecio.Size = new System.Drawing.Size(130, 32);
            this.TxtPrecio.TabIndex = 49;
            this.TxtPrecio.TextChanged += new System.EventHandler(this.TxtPrecio_TextChanged);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(31, 372);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(180, 36);
            this.label10.TabIndex = 48;
            this.label10.Text = "Descripcion:";
            // 
            // txtProveedor
            // 
            this.txtProveedor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtProveedor.Enabled = false;
            this.txtProveedor.Location = new System.Drawing.Point(464, 151);
            this.txtProveedor.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(488, 32);
            this.txtProveedor.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(272, 203);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 36);
            this.label7.TabIndex = 47;
            this.label7.Text = "Precio:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(272, 146);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 36);
            this.label6.TabIndex = 38;
            this.label6.Text = "Proveedor:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCantidad.Location = new System.Drawing.Point(822, 203);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(130, 32);
            this.txtCantidad.TabIndex = 39;
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBuscar.Location = new System.Drawing.Point(35, 192);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(479, 31);
            this.txtBuscar.TabIndex = 70;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.DarkMagenta;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(540, 155);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(244, 73);
            this.btnBuscar.TabIndex = 71;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(29, 137);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(404, 36);
            this.label8.TabIndex = 66;
            this.label8.Text = "Ingrese nombre del producto:";
            // 
            // btnModificarProducto
            // 
            this.btnModificarProducto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnModificarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))));
            this.btnModificarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificarProducto.FlatAppearance.BorderColor = System.Drawing.Color.DarkMagenta;
            this.btnModificarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarProducto.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarProducto.ForeColor = System.Drawing.Color.White;
            this.btnModificarProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarProducto.Location = new System.Drawing.Point(792, 155);
            this.btnModificarProducto.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnModificarProducto.Name = "btnModificarProducto";
            this.btnModificarProducto.Size = new System.Drawing.Size(244, 73);
            this.btnModificarProducto.TabIndex = 67;
            this.btnModificarProducto.Text = "Modificar";
            this.btnModificarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificarProducto.UseVisualStyleBackColor = false;
            this.btnModificarProducto.Click += new System.EventHandler(this.btnModificarProducto_Click);
            // 
            // FormModificarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1080, 735);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnModificarProducto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "FormModificarProducto";
            this.Text = "FormModificarProducto";
            this.Load += new System.EventHandler(this.FormModificarProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.PictureBox imagen;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnSubirFoto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtPrecio;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnModificarProducto;
    }
}