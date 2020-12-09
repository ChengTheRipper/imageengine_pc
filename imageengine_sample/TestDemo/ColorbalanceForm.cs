﻿/*----------------------------------------------------------------------------------------------
*
* This file is XIUSDK's property. It contains XIUSDK's trade secret, proprietary and
* confidential information.
*
* The information and code contained in this file is only for authorized XIUSDK employees
* to design, create, modify, or review.
*
* DO NOT DISTRIBUTE, DO NOT DUPLICATE OR TRANSMIT IN ANY FORM WITHOUT PROPER AUTHORIZATION.
*
* If you are not an intended recipient of this file, you must not copy, distribute, modify,
* or take any action in reliance on it.
*
* If you have received this file in error, please immediately notify XIUSDK and
* permanently delete the original and any copy of any file and any printout thereof.
*
*---------------------------------------------------------------------------------------------*/
/*****************************************************************************
 Copyright:    www.xiusdk.cn(all rights reserved)
 Description:  beautyEngine sdk 包含人脸美化模块/滤镜模块
 Author:       xiusdk
 Version:      V1.2
 Date:         20200101-20231230
 qq group:     567648913(加群获取最新信息)
*****************************************************************************/
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestDemo
{
    public partial class ColorbalanceForm : CCWin.Skin_Mac
    {
        public ColorbalanceForm(string path)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            zPhoto = new ZPhotoEngineDll();
            Bitmap tmp = new Bitmap(path);
            if (tmp != null)
            {
                curBitmap = new Bitmap(tmp, 150 * tmp.Width / Math.Max(tmp.Width, tmp.Height), 150 * tmp.Height / Math.Max(tmp.Width, tmp.Height));
                pictureBox1.Image = (Image)curBitmap;
            }
        }
        private ZPhotoEngineDll zPhoto = null;
        private Bitmap curBitmap = null;
        private int cyan = 0, magenta = 0, yellow = 0;
        private bool preserveLuminosity = true;
        public int getCyan
        {
            get { return cyan; }
        }
        public int getMagenta
        {
            get { return magenta; }
        }
        public int getYellow
        {
            get { return yellow;  }
        }
        public bool getLum
        {
            get { return preserveLuminosity; }
        }
        private void skinButton1_Click(object sender, EventArgs e)
        {
            cyan = hScrollBar1.Value;
            magenta = hScrollBar2.Value;
            yellow = hScrollBar3.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        //cyan
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                cyan = hScrollBar1.Value;
                magenta = hScrollBar2.Value;
                yellow = hScrollBar3.Value;
                textBox1.Text = cyan.ToString();
                textBox2.Text = magenta.ToString();
                textBox3.Text = yellow.ToString();
                pictureBox1.Image = (Image)zPhoto.ColorBalanceProcess(curBitmap, cyan, magenta, yellow, 0, preserveLuminosity);
            }
        }
        //magenta
        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                cyan = hScrollBar1.Value;
                magenta = hScrollBar2.Value;
                yellow = hScrollBar3.Value;
                textBox1.Text = cyan.ToString();
                textBox2.Text = magenta.ToString();
                textBox3.Text = yellow.ToString();
                pictureBox1.Image = (Image)zPhoto.ColorBalanceProcess(curBitmap, cyan, magenta, yellow, 0, preserveLuminosity);
            }
        }
        //yellow
        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                cyan = hScrollBar1.Value;
                magenta = hScrollBar2.Value;
                yellow = hScrollBar3.Value;
                textBox1.Text = cyan.ToString();
                textBox2.Text = magenta.ToString();
                textBox3.Text = yellow.ToString();
                pictureBox1.Image = (Image)zPhoto.ColorBalanceProcess(curBitmap, cyan, magenta, yellow, 0, preserveLuminosity);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                preserveLuminosity = true;
                hScrollBar1.Value = 0;
                hScrollBar2.Value = 0;
                hScrollBar3.Value = 0;
                cyan = hScrollBar1.Value;
                magenta = hScrollBar1.Value;
                yellow = hScrollBar1.Value;
                textBox1.Text = cyan.ToString();
                textBox2.Text = magenta.ToString();
                textBox3.Text = yellow.ToString();
            }
            else
            {
                preserveLuminosity = false;
                hScrollBar1.Value = 0;
                hScrollBar2.Value = 0;
                hScrollBar3.Value = 0;
                cyan = hScrollBar1.Value;
                magenta = hScrollBar1.Value;
                yellow = hScrollBar1.Value;
                textBox1.Text = cyan.ToString();
                textBox2.Text = magenta.ToString();
                textBox3.Text = yellow.ToString();
            }
        }
    }
}
