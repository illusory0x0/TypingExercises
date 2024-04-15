using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Keyboard;
public sealed partial class LetterKeyView : UserControl
{
	public LetterKeyView()
	{
		this.InitializeComponent();
	}
	public LetterKeyView(string text)
	{
		this.InitializeComponent();
		this.Text = text;
	}

	public string Text
	{
		get => (string)this.GetValue(TextProperty);
		set => this.SetValue(TextProperty, value);
	}

	// Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
	public static readonly DependencyProperty TextProperty =
		DependencyProperty.Register("Text", typeof(string), typeof(LetterKeyView), new PropertyMetadata(0));


}
