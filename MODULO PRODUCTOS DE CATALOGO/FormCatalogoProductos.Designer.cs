namespace MODULO_PRODUCTOS_DE_CATALOGO
{
    partial class FormCatalogoProductos
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnComprar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboP = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.flp = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(33, 31);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(70, 25);
            this.lblNombre.TabIndex = 81;
            this.lblNombre.Text = "label1";
            this.lblNombre.Visible = false;
            // 
            // btnComprar
            // 
            this.btnComprar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))));
            this.btnComprar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComprar.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnComprar.ForeColor = System.Drawing.Color.White;
            this.btnComprar.Location = new System.Drawing.Point(814, 122);
            this.btnComprar.Margin = new System.Windows.Forms.Padding(6);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(230, 108);
            this.btnComprar.TabIndex = 80;
            this.btnComprar.Text = "COMPRAR";
            this.btnComprar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnComprar.UseVisualStyleBackColor = false;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::MODULO_PRODUCTOS_DE_CATALOGO.Properties.Resources.cierre;
            this.pictureBox1.Location = new System.Drawing.Point(960, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 78;
            this.pictureBox1.TabStop = false;
            // 
            // comboP
            // 
            this.comboP.FormattingEnabled = true;
            this.comboP.Location = new System.Drawing.Point(310, 186);
            this.comboP.Margin = new System.Windows.Forms.Padding(6);
            this.comboP.Name = "comboP";
            this.comboP.Size = new System.Drawing.Size(404, 33);
            this.comboP.TabIndex = 77;
            this.comboP.SelectedIndexChanged += new System.EventHandler(this.comboP_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 186);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 31);
            this.label2.TabIndex = 76;
            this.label2.Text = "Seleccione proveedor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(25)))), ((int)(((byte)(47)))));
            this.label3.Location = new System.Drawing.Point(24, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(645, 73);
            this.label3.TabIndex = 75;
            this.label3.Text = "Catalogo de Laptops";
            // 
            // flp
            // 
            this.flp.AutoScroll = true;
            this.flp.Location = new System.Drawing.Point(37, 267);
            this.flp.Margin = new System.Windows.Forms.Padding(6);
            this.flp.Name = "flp";
            this.flp.Size = new System.Drawing.Size(991, 453);
            this.flp.TabIndex = 79;
            // 
            // FormCatalogoProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 735);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.flp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormCatalogoProductos";
            this.Text = "FormCatalogoProductos";
            this.Load += new System.EventHandler(this.FormCatalogoProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flp;
    }
}