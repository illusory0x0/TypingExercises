using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TypingExercises;
public sealed partial class TypingExercises : UserControl
{
	public TypingExercises()
	{
		this.InitializeComponent();
		(this.prompt.PromptText, this.keyboard.KeyPrompt) = NextPrompt();

	}
	private Random random = new Random();
	private Tuple<string, char> NextPrompt()
	{
		var table = DataModels.XiaoheKeyboard.PromptTable;
		var r = random.Next(table.Count());
		return table[r];
	}
	private void input_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
	{
		var key = sender.Text[0];
		if (char.ToUpper(key) == char.ToUpper(keyboard.KeyPrompt))
		{
			(this.prompt.PromptText, this.keyboard.KeyPrompt) = NextPrompt();

		}
		sender.Text = "";
	}
}
