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


namespace TypingExercises;

public sealed partial class KeyPromptView : UserControl
{
	public KeyPromptView()
	{
		this.InitializeComponent();
	}
	public string PromptText
	{
		get { return (string)GetValue(PromptTextProperty); }
		set { SetValue(PromptTextProperty, value); }
	}
	public static readonly DependencyProperty PromptTextProperty =
		DependencyProperty.Register("PromptText", typeof(string), typeof(KeyPromptView), new PropertyMetadata(0));
}
