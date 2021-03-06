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
using CCWin;

namespace TestDemo
{
    public partial class SoftskinForm :  Skin_Mac
    {
        public SoftskinForm(Bitmap srcBitmap, int[] landmark)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            curBitmap = new Bitmap(srcBitmap);
            zSoftSkin = new ZBeautyEngineDll();
            _landMark = landmark;
        }
        private Form1 mForm = null;
        private Bitmap curBitmap = null;
        //ZMakeupEngineDll zMakeup = null;
        private ZBeautyEngineDll zSoftSkin = null;
        int[] _landMark;
        
        private void skinButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void skinHScrollBar1_Scroll(object sender, ScrollEventArgs e)
        { 
            mForm = (Form1)this.Owner;
            int softRatio = softskinHScrollBar1.Value;
           
            mForm.RefreshDisplay(zSoftSkin.DoSoftSkin(curBitmap, _landMark, softRatio));
            textBox1.Text = softskinHScrollBar1.Value.ToString();      
        }


    }
}
