using Microsoft.UI.Xaml.Controls;
using System;
using System.Linq;
using TypingPractice;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Keyboard;
public sealed partial class Exercise : UserControl
{
	public Exercise()
	{
		this.InitializeComponent();
		(this.prompt.PromptText, this.keyboard.KeyPrompt) = this.NextPrompt();

	}
	private readonly Random random = new();
	private Tuple<string, char> NextPrompt()
	{
		var table = DataModels.XiaoheKeyboard.PromptTable;
		var r = this.random.Next(table.Count());
		return table[r];
	}
	private void input_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
	{
		var key = sender.Text[0];
		if (char.ToUpper(key) == char.ToUpper(this.keyboard.KeyPrompt))
		{
			(this.prompt.PromptText, this.keyboard.KeyPrompt) = this.NextPrompt();

		}
		sender.Text = "";
	}
}
