using System;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows;
using System.Drawing;

namespace LeftRightOneTap{
	class Program{
		[DllImport("user32.dll")]
		public static extern int GetAsyncKeyState(Int32 i);
		
		[DllImport("user32.dll",CharSet=CharSet.Auto, CallingConvention=CallingConvention.StdCall)]
	   	public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
	   	
	   	//Mouse actions
	  	private const int MOUSEEVENTF_LEFTDOWN = 0x02;
	   	private const int MOUSEEVENTF_LEFTUP = 0x04;
	   	private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
	   	private const int MOUSEEVENTF_RIGHTUP = 0x10;
	   	
		public static void DoMouseClick(){
		  //Call the imported function with the cursor's current position
		  uint X = 0;
		  uint Y = 0;
		  mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
		}
	   	
		public static void Main(string[] args){
	   		System.Console.WriteLine("Перед использованием программы нужно знать, что она может привести к непредвиденным ситуация в виде многократного запуска приложений, морганий окон и так далее если будет выбран пункт \"1.\".\nОсновной способ применения - быстрая атака в Майнкрафте, не более");
	   		System.Console.WriteLine("На какую клавишу установить бинд?\n1 -> ЛКМ.\n2 -> ПКМ.\nДРУГОЕ -> Выход из программы.");
			string input = System.Console.ReadLine();
			string keyBind = "LButton";
			switch (input) {
				case "1":
					break;
				case "2":
					keyBind = "RButton";
					break;
				default:		
					System.Environment.Exit(0);
					break;
			}
			
	   		string buf = "";
	   		Console.WriteLine("\nУспешно запущено.\nВыход CTRL + C");
			while (true) {
			   for (int i = 0; i < 255; i++){
			      int state = GetAsyncKeyState(i);
			      if (state != 0){
			        buf = ((Keys)i).ToString(); 
			        if (buf == keyBind) {
			        	DoMouseClick();
			        }
			      }
			   }
			}
		}
	}
}
