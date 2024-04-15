using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Keyboard;

public sealed partial class PunctKeyView : UserControl
{
	public PunctKeyView()
	{
		this.InitializeComponent();
	}
	public PunctKeyView(string topText, string bottomText)
	{
		this.InitializeComponent();
		this.TopText = topText;
		this.BottomText = bottomText;
	}
	public string TopText
	{
		get => (string)this.GetValue(TopTextProperty);
		set => this.SetValue(TopTextProperty, value);
	}
	public static readonly DependencyProperty TopTextProperty =
		DependencyProperty.Register("TopText", typeof(string), typeof(PunctKeyView), new PropertyMetadata(0));
	public string BottomText
	{
		get => (string)this.GetValue(BottomTextProperty);
		set => this.SetValue(BottomTextProperty, value);
	}
	public static readonly DependencyProperty BottomTextProperty =
		DependencyProperty.Register("BottomText", typeof(string), typeof(PunctKeyView), new PropertyMetadata(0));
}




