
﻿using System;
using System.Windows.Controls;
using System.Windows.Interop;

namespace Copilot.Sw.Controls;

/// <summary>
/// TextBox Used in SolidWorks
/// </summary>
public class IOTextBox : TextBox
{
    private const UInt32 DLGC_WANTARROWS = 0x0001;
    private const UInt32 DLGC_HASSETSEL = 0x0008;
    private const UInt32 DLGC_WANTCHARS = 0x0080;
    private const UInt32 WM_GETDLGCODE = 0x0087;

    public IOTextBox() : base()
    {
        Loaded += delegate
        {
            HwndSource s = HwndSource.FromVisual(this) as HwndSource;
            if (s != null)
                s.AddHook(new HwndSourceHook(ChildHwndSourceHook));
        };
    }

    IntPtr ChildHwndSourceHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
    {
        if (msg == WM_GETDLGCODE)
        {
            handled = true;
            return new IntPtr(DLGC_WANTCHARS | DLGC_WANTARROWS | DLGC_HASSETSEL);
        }
        return IntPtr.Zero;
    }
}