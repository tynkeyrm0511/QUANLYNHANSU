namespace NHANSU_UIUX
{
    partial class ConfirmationDialog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmationDialog));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges4 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.lblThemSua = new Bunifu.UI.WinForms.BunifuLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnHuy = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnDongY = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 30;
            this.bunifuElipse1.TargetControl = this;
            // 
            // lblThemSua
            // 
            this.lblThemSua.AllowParentOverrides = false;
            this.lblThemSua.AutoEllipsis = false;
            this.lblThemSua.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblThemSua.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblThemSua.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblThemSua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(145)))), ((int)(((byte)(90)))));
            this.lblThemSua.Location = new System.Drawing.Point(44, 28);
            this.lblThemSua.Name = "lblThemSua";
            this.lblThemSua.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblThemSua.Size = new System.Drawing.Size(444, 45);
            this.lblThemSua.TabIndex = 10;
            this.lblThemSua.Text = "Bạn có chắc chắn muốn xóa?";
            this.lblThemSua.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblThemSua.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NHANSU_UIUX.Properties.Resources.chacchua_s;
            this.pictureBox1.Location = new System.Drawing.Point(136, 81);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 250);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // btnHuy
            // 
            this.btnHuy.AllowAnimations = true;
            this.btnHuy.AllowMouseEffects = true;
            this.btnHuy.AllowToggling = false;
            this.btnHuy.AnimationSpeed = 200;
            this.btnHuy.AutoGenerateColors = false;
            this.btnHuy.AutoRoundBorders = false;
            this.btnHuy.AutoSizeLeftIcon = true;
            this.btnHuy.AutoSizeRightIcon = true;
            this.btnHuy.BackColor = System.Drawing.Color.Transparent;
            this.btnHuy.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnHuy.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHuy.BackgroundImage")));
            this.btnHuy.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnHuy.ButtonText = "       Hủy";
            this.btnHuy.ButtonTextMarginLeft = 0;
            this.btnHuy.ColorContrastOnClick = 45;
            this.btnHuy.ColorContrastOnHover = 45;
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.btnHuy.CustomizableEdges = borderEdges3;
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnHuy.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnHuy.DisabledFillColor = System.Drawing.Color.Empty;
            this.btnHuy.DisabledForecolor = System.Drawing.Color.Empty;
            this.btnHuy.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.btnHuy.IconLeft = global::NHANSU_UIUX.Properties.Resources.huy;
            this.btnHuy.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnHuy.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnHuy.IconMarginLeft = 11;
            this.btnHuy.IconPadding = 10;
            this.btnHuy.IconRight = null;
            this.btnHuy.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuy.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnHuy.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnHuy.IconSize = 25;
            this.btnHuy.IdleBorderColor = System.Drawing.Color.Empty;
            this.btnHuy.IdleBorderRadius = 0;
            this.btnHuy.IdleBorderThickness = 0;
            this.btnHuy.IdleFillColor = System.Drawing.Color.Empty;
            this.btnHuy.IdleIconLeftImage = global::NHANSU_UIUX.Properties.Resources.huy;
            this.btnHuy.IdleIconRightImage = null;
            this.btnHuy.IndicateFocus = false;
            this.btnHuy.Location = new System.Drawing.Point(259, 337);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnHuy.OnDisabledState.BorderRadius = 25;
            this.btnHuy.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnHuy.OnDisabledState.BorderThickness = 2;
            this.btnHuy.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnHuy.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnHuy.OnDisabledState.IconLeftImage = null;
            this.btnHuy.OnDisabledState.IconRightImage = null;
            this.btnHuy.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.btnHuy.onHoverState.BorderRadius = 25;
            this.btnHuy.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnHuy.onHoverState.BorderThickness = 2;
            this.btnHuy.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(181)))), ((int)(((byte)(145)))));
            this.btnHuy.onHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.btnHuy.onHoverState.IconLeftImage = null;
            this.btnHuy.onHoverState.IconRightImage = null;
            this.btnHuy.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.btnHuy.OnIdleState.BorderRadius = 25;
            this.btnHuy.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnHuy.OnIdleState.BorderThickness = 2;
            this.btnHuy.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(145)))), ((int)(((byte)(90)))));
            this.btnHuy.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.btnHuy.OnIdleState.IconLeftImage = global::NHANSU_UIUX.Properties.Resources.huy;
            this.btnHuy.OnIdleState.IconRightImage = null;
            this.btnHuy.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(145)))), ((int)(((byte)(90)))));
            this.btnHuy.OnPressedState.BorderRadius = 25;
            this.btnHuy.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnHuy.OnPressedState.BorderThickness = 2;
            this.btnHuy.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(60)))));
            this.btnHuy.OnPressedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.btnHuy.OnPressedState.IconLeftImage = null;
            this.btnHuy.OnPressedState.IconRightImage = null;
            this.btnHuy.Size = new System.Drawing.Size(138, 52);
            this.btnHuy.TabIndex = 12;
            this.btnHuy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnHuy.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnHuy.TextMarginLeft = 0;
            this.btnHuy.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnHuy.UseDefaultRadiusAndThickness = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnDongY
            // 
            this.btnDongY.AllowAnimations = true;
            this.btnDongY.AllowMouseEffects = true;
            this.btnDongY.AllowToggling = false;
            this.btnDongY.AnimationSpeed = 200;
            this.btnDongY.AutoGenerateColors = false;
            this.btnDongY.AutoRoundBorders = false;
            this.btnDongY.AutoSizeLeftIcon = true;
            this.btnDongY.AutoSizeRightIcon = true;
            this.btnDongY.BackColor = System.Drawing.Color.Transparent;
            this.btnDongY.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnDongY.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDongY.BackgroundImage")));
            this.btnDongY.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnDongY.ButtonText = "      Đồng ý";
            this.btnDongY.ButtonTextMarginLeft = 0;
            this.btnDongY.ColorContrastOnClick = 45;
            this.btnDongY.ColorContrastOnHover = 45;
            this.btnDongY.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges4.BottomLeft = true;
            borderEdges4.BottomRight = true;
            borderEdges4.TopLeft = true;
            borderEdges4.TopRight = true;
            this.btnDongY.CustomizableEdges = borderEdges4;
            this.btnDongY.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDongY.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnDongY.DisabledFillColor = System.Drawing.Color.Empty;
            this.btnDongY.DisabledForecolor = System.Drawing.Color.Empty;
            this.btnDongY.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnDongY.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDongY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.btnDongY.IconLeft = global::NHANSU_UIUX.Properties.Resources.dongy;
            this.btnDongY.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDongY.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnDongY.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnDongY.IconMarginLeft = 11;
            this.btnDongY.IconPadding = 10;
            this.btnDongY.IconRight = null;
            this.btnDongY.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDongY.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnDongY.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnDongY.IconSize = 25;
            this.btnDongY.IdleBorderColor = System.Drawing.Color.Empty;
            this.btnDongY.IdleBorderRadius = 0;
            this.btnDongY.IdleBorderThickness = 0;
            this.btnDongY.IdleFillColor = System.Drawing.Color.Empty;
            this.btnDongY.IdleIconLeftImage = global::NHANSU_UIUX.Properties.Resources.dongy;
            this.btnDongY.IdleIconRightImage = null;
            this.btnDongY.IndicateFocus = false;
            this.btnDongY.Location = new System.Drawing.Point(115, 337);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnDongY.OnDisabledState.BorderRadius = 25;
            this.btnDongY.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnDongY.OnDisabledState.BorderThickness = 2;
            this.btnDongY.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnDongY.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnDongY.OnDisabledState.IconLeftImage = null;
            this.btnDongY.OnDisabledState.IconRightImage = null;
            this.btnDongY.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.btnDongY.onHoverState.BorderRadius = 25;
            this.btnDongY.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnDongY.onHoverState.BorderThickness = 2;
            this.btnDongY.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(181)))), ((int)(((byte)(145)))));
            this.btnDongY.onHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.btnDongY.onHoverState.IconLeftImage = null;
            this.btnDongY.onHoverState.IconRightImage = null;
            this.btnDongY.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.btnDongY.OnIdleState.BorderRadius = 25;
            this.btnDongY.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnDongY.OnIdleState.BorderThickness = 2;
            this.btnDongY.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(145)))), ((int)(((byte)(90)))));
            this.btnDongY.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.btnDongY.OnIdleState.IconLeftImage = global::NHANSU_UIUX.Properties.Resources.dongy;
            this.btnDongY.OnIdleState.IconRightImage = null;
            this.btnDongY.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(145)))), ((int)(((byte)(90)))));
            this.btnDongY.OnPressedState.BorderRadius = 25;
            this.btnDongY.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnDongY.OnPressedState.BorderThickness = 2;
            this.btnDongY.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(60)))));
            this.btnDongY.OnPressedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.btnDongY.OnPressedState.IconLeftImage = null;
            this.btnDongY.OnPressedState.IconRightImage = null;
            this.btnDongY.Size = new System.Drawing.Size(138, 52);
            this.btnDongY.TabIndex = 11;
            this.btnDongY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDongY.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnDongY.TextMarginLeft = 0;
            this.btnDongY.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnDongY.UseDefaultRadiusAndThickness = true;
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // ConfirmationDialog
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(247)))), ((int)(((byte)(241)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 412);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnDongY);
            this.Controls.Add(this.lblThemSua);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConfirmationDialog";
            this.Text = "ConfirmationDialog";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.UI.WinForms.BunifuLabel lblThemSua;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnHuy;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnDongY;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}