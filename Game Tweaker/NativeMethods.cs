namespace ToolTipBalloon
{
	using System;
	using System.Drawing;
	using System.Reflection;
	using System.Runtime.InteropServices;
	using System.Windows.Forms;
	/// <summary>
	/// Summary description for NativeMethods.
	/// </summary>
	public class NativeMethods
	{
		private const long WS_POPUP = 0x80000000;
		private const long TTS_BALLOON = 0x40;
		private const long TTS_NOFADE = 0x20;
		private const int GWL_STYLE = -16;
		private const int WM_USER = 0x0400;
		private const int TTM_SETTIPBKCOLOR = WM_USER + 19;

 		private NativeMethods() {}


		public static void SetBalloonStyle ( ToolTip toolTip )
		{
			NativeWindow window = GetNativeWindow ( toolTip );
 			NativeMethods.SetWindowLong ( window.Handle, GWL_STYLE , WS_POPUP | TTS_BALLOON | TTS_NOFADE );
			
		}

		public static void SetBackColor ( ToolTip toolTip, Color color )
		{
			int backColor =  ColorTranslator.ToWin32( color );
			NativeWindow window = GetNativeWindow ( toolTip );
			//setting back color
			SendMessage( window.Handle, TTM_SETTIPBKCOLOR, backColor, 0 );  
		}

		private static NativeWindow GetNativeWindow ( ToolTip toolTip )
		{
			FieldInfo windowField = toolTip.GetType().GetField("window", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance );
			NativeWindow window  = (NativeWindow)windowField.GetValue ( toolTip );
            if (window.Handle == IntPtr.Zero)
            {
            }
			return window;
		}

		[DllImport("user32.dll")]
		private static extern long SetWindowLong(IntPtr hwnd,int index,long val);

		[DllImport("user32.dll")]
		private static extern int SendMessage( IntPtr hwnd, int msg, int wParam, int lParam);
  	}
 
}
