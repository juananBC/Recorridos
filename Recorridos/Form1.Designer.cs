

namespace Recorridos {
    partial class Form1 {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private const string ORIGEN = "Origen";
        private const string DESTINO = "Destino";
        private const string OBSTACULO = "Obstáculo";


        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.TableroPanel = new Recorridos.Graficos.PanelCustom();
            this.tamanoTablero = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.OrigenRB = new System.Windows.Forms.RadioButton();
            this.DestinoRB = new System.Windows.Forms.RadioButton();
            this.ObstaculoRB = new System.Windows.Forms.RadioButton();
            this.TipoNodo = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.tamanoTablero)).BeginInit();
            this.TipoNodo.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableroPanel
            // 
            this.TableroPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableroPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TableroPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TableroPanel.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.TableroPanel.Location = new System.Drawing.Point(12, 12);
            this.TableroPanel.Name = "TableroPanel";
            this.TableroPanel.Size = new System.Drawing.Size(776, 352);
            this.TableroPanel.TabIndex = 0;
            this.TableroPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.TableroPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TableroPanel_MouseDown);
            this.TableroPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MarcarObstaculo);
            this.TableroPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TableroPanel_MouseUp);
            this.TableroPanel.Resize += new System.EventHandler(this.TableroPanel_Resize);
            // 
            // tamanoTablero
            // 
            this.tamanoTablero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tamanoTablero.Location = new System.Drawing.Point(374, 402);
            this.tamanoTablero.Name = "tamanoTablero";
            this.tamanoTablero.ReadOnly = true;
            this.tamanoTablero.Size = new System.Drawing.Size(51, 20);
            this.tamanoTablero.TabIndex = 4;
            this.tamanoTablero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tamanoTablero.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.tamanoTablero.ValueChanged += new System.EventHandler(this.tamanoTablero_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(270, 404);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tamaño del tablero";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(590, 396);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Reiniciar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Reiniciar_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(698, 396);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Iniciar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Click_iniciarRecorrido);
            // 
            // OrigenRB
            // 
            this.OrigenRB.AutoSize = true;
            this.OrigenRB.Location = new System.Drawing.Point(5, 19);
            this.OrigenRB.Name = "OrigenRB";
            this.OrigenRB.Size = new System.Drawing.Size(56, 17);
            this.OrigenRB.TabIndex = 8;
            this.OrigenRB.Text = "Origen";
            this.OrigenRB.UseVisualStyleBackColor = true;
            // 
            // DestinoRB
            // 
            this.DestinoRB.AutoSize = true;
            this.DestinoRB.Location = new System.Drawing.Point(67, 19);
            this.DestinoRB.Name = "DestinoRB";
            this.DestinoRB.Size = new System.Drawing.Size(61, 17);
            this.DestinoRB.TabIndex = 9;
            this.DestinoRB.Text = "Destino";
            this.DestinoRB.UseVisualStyleBackColor = true;
            // 
            // ObstaculoRB
            // 
            this.ObstaculoRB.AutoSize = true;
            this.ObstaculoRB.Checked = true;
            this.ObstaculoRB.Location = new System.Drawing.Point(134, 19);
            this.ObstaculoRB.Name = "ObstaculoRB";
            this.ObstaculoRB.Size = new System.Drawing.Size(73, 17);
            this.ObstaculoRB.TabIndex = 10;
            this.ObstaculoRB.TabStop = true;
            this.ObstaculoRB.Text = "Obstáculo";
            this.ObstaculoRB.UseVisualStyleBackColor = true;
            // 
            // TipoNodo
            // 
            this.TipoNodo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TipoNodo.Controls.Add(this.ObstaculoRB);
            this.TipoNodo.Controls.Add(this.DestinoRB);
            this.TipoNodo.Controls.Add(this.OrigenRB);
            this.TipoNodo.Location = new System.Drawing.Point(22, 383);
            this.TipoNodo.Name = "TipoNodo";
            this.TipoNodo.Size = new System.Drawing.Size(242, 55);
            this.TipoNodo.TabIndex = 11;
            this.TipoNodo.TabStop = false;
            this.TipoNodo.Text = "Tipo de nodo";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TipoNodo);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tamanoTablero);
            this.Controls.Add(this.TableroPanel);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.tamanoTablero)).EndInit();
            this.TipoNodo.ResumeLayout(false);
            this.TipoNodo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown tamanoTablero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RadioButton OrigenRB;
        private System.Windows.Forms.RadioButton DestinoRB;
        private System.Windows.Forms.RadioButton ObstaculoRB;
        private System.Windows.Forms.GroupBox TipoNodo;
        private Recorridos.Graficos.PanelCustom TableroPanel;
    }
}

