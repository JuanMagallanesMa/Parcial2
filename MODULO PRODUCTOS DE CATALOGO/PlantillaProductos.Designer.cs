namespace MODULO_PRODUCTOS_DE_CATALOGO
{
    partial class PlantillaProductos
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnMas = new System.Windows.Forms.Button();
            this.btnMenos = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDescripcion = new System.Windows.Forms.TextBox();
            this.lblNombre_Producto = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.cbCarrito = new System.Windows.Forms.CheckBox();
            this.imagenProducto = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagenProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))));
            this.panel1.Controls.Add(this.txtCantidad);
            this.panel1.Controls.Add(this.btnMas);
            this.panel1.Controls.Add(this.btnMenos);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.cbCarrito);
            this.panel1.Controls.Add(this.imagenProducto);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(946, 344);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txtCantidad
            // 
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtCantidad.Location = new System.Drawing.Point(108, 256);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 55);
            this.txtCantidad.TabIndex = 13;
            this.txtCantidad.Text = "1";
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnMas
            // 
            this.btnMas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMas.BackgroundImage = global::MODULO_PRODUCTOS_DE_CATALOGO.Properties.Resources.add_6399334;
            this.btnMas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMas.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.btnMas.Location = new System.Drawing.Point(208, 248);
            this.btnMas.Margin = new System.Windows.Forms.Padding(0);
            this.btnMas.Name = "btnMas";
            this.btnMas.Size = new System.Drawing.Size(58, 58);
            this.btnMas.TabIndex = 12;
            this.btnMas.UseVisualStyleBackColor = true;
            this.btnMas.Click += new System.EventHandler(this.btnMas_Click);
            // 
            // btnMenos
            // 
            this.btnMenos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMenos.BackgroundImage = global::MODULO_PRODUCTOS_DE_CATALOGO.Properties.Resources.minus_9872149;
            this.btnMenos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMenos.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.btnMenos.Location = new System.Drawing.Point(52, 248);
            this.btnMenos.Margin = new System.Windows.Forms.Padding(0);
            this.btnMenos.Name = "btnMenos";
            this.btnMenos.Size = new System.Drawing.Size(58, 58);
            this.btnMenos.TabIndex = 11;
            this.btnMenos.Text = "-";
            this.btnMenos.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMenos.UseVisualStyleBackColor = true;
            this.btnMenos.Click += new System.EventHandler(this.btnMenos_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(155)))), ((int)(((byte)(184)))));
            this.panel2.Controls.Add(this.lblDescripcion);
            this.panel2.Controls.Add(this.lblNombre_Producto);
            this.panel2.Controls.Add(this.lblPrecio);
            this.panel2.Location = new System.Drawing.Point(300, 98);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(604, 229);
            this.panel2.TabIndex = 10;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(155)))), ((int)(((byte)(184)))));
            this.lblDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblDescripcion.ForeColor = System.Drawing.Color.White;
            this.lblDescripcion.Location = new System.Drawing.Point(18, 135);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblDescripcion.Multiline = true;
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(568, 71);
            this.lblDescripcion.TabIndex = 8;
            // 
            // lblNombre_Producto
            // 
            this.lblNombre_Producto.AutoSize = true;
            this.lblNombre_Producto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblNombre_Producto.ForeColor = System.Drawing.Color.White;
            this.lblNombre_Producto.Location = new System.Drawing.Point(12, 12);
            this.lblNombre_Producto.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNombre_Producto.Name = "lblNombre_Producto";
            this.lblNombre_Producto.Size = new System.Drawing.Size(337, 37);
            this.lblNombre_Producto.TabIndex = 1;
            this.lblNombre_Producto.Text = "Nombre del producto";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblPrecio.ForeColor = System.Drawing.Color.White;
            this.lblPrecio.Location = new System.Drawing.Point(12, 63);
            this.lblPrecio.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(106, 36);
            this.lblPrecio.TabIndex = 2;
            this.lblPrecio.Text = "Precio";
            // 
            // cbCarrito
            // 
            this.cbCarrito.AutoSize = true;
            this.cbCarrito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbCarrito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCarrito.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCarrito.Image = global::MODULO_PRODUCTOS_DE_CATALOGO.Properties.Resources.compra;
            this.cbCarrito.Location = new System.Drawing.Point(604, 6);
            this.cbCarrito.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbCarrito.Name = "cbCarrito";
            this.cbCarrito.Size = new System.Drawing.Size(71, 48);
            this.cbCarrito.TabIndex = 4;
            this.cbCarrito.UseVisualStyleBackColor = true;
            this.cbCarrito.CheckedChanged += new System.EventHandler(this.cbCarrito_CheckedChanged);
            // 
            // imagenProducto
            // 
            this.imagenProducto.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.imagenProducto.Location = new System.Drawing.Point(52, 31);
            this.imagenProducto.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.imagenProducto.Name = "imagenProducto";
            this.imagenProducto.Size = new System.Drawing.Size(214, 185);
            this.imagenProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imagenProducto.TabIndex = 0;
            this.imagenProducto.TabStop = false;
            // 
            // PlantillaProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "PlantillaProductos";
            this.Size = new System.Drawing.Size(946, 344);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagenProducto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imagenProducto;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.CheckBox cbCarrito;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label lblNombre_Producto;
        public System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox lblDescripcion;
        private System.Windows.Forms.Button btnMenos;
        private System.Windows.Forms.Button btnMas;
        private System.Windows.Forms.TextBox txtCantidad;
    }
}
