using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TypingExercises;

public sealed partial class KeyView : UserControl
{
	public KeyView()
	{
		this.InitializeComponent();
	}
	public KeyView(object keyText)
	{
		this.InitializeComponent();
		this.KeyText = keyText;
		border.Child = KeyText switch
		{
			string str => new LetterKeyView(str),
			char ch => new LetterKeyView(ch.ToString()),
			(char top, char bottom) => new PunctKeyView(top.ToString(), bottom.ToString()),
			_ => throw new NotImplementedException("unreachable")
		};
	}
	public object KeyText
	{
		get { return GetValue(KeyTextProperty); }
		set { SetValue(KeyTextProperty, value); }
	}
	public static readonly DependencyProperty KeyTextProperty =
		DependencyProperty.Register("KeyText", typeof(object), typeof(KeyView), new PropertyMetadata(0));
}
