using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;


namespace Keyboard;

public sealed partial class KeyPromptView : UserControl
{
	public KeyPromptView()
	{
		this.InitializeComponent();
	}
	public string PromptText
	{
		get => (string)this.GetValue(PromptTextProperty);
		set => this.SetValue(PromptTextProperty, value);
	}
	public static readonly DependencyProperty PromptTextProperty =
		DependencyProperty.Register("PromptText", typeof(string), typeof(KeyPromptView), new PropertyMetadata(0));
}
