using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System;
using static TypingExercises.DataModels;

namespace TypingExercises;
public static partial class Exstension
{
	public static void SetCenterAlign(this FrameworkElement element)
	{
		element.HorizontalAlignment = HorizontalAlignment.Center;
		element.VerticalAlignment = VerticalAlignment.Center;
	}
	public static void SetGridPostion(this FrameworkElement element, int row, int rowSpan, int column, int columnSpan)
	{
		Grid.SetRow(element, row);
		Grid.SetRowSpan(element, rowSpan);
		Grid.SetColumn(element, column);
		Grid.SetColumnSpan(element, columnSpan);
	}
}
public sealed partial class KeyboardView : UserControl
{
	public KeyboardView()
	{
		this.InitializeComponent();
		SetGridRowColumn(grid, 8, 29);

		foreach (var row in KeyboardModel)
		{
			foreach (var key in row)
			{
				(var text, var rowIndex, var colIndex, var colspan) = key;
				FrameworkElement keyView = new KeyView(text);
				keyView.SetGridPostion(rowIndex, 2, colIndex, colspan);
				grid.Children.Add(keyView);
			}
		}
	}

	public static void SetGridRowColumn(Grid grid, int rowNum, int ColNum)
	{
		for (var i = 0; i < rowNum; i++)
		{
			grid.RowDefinitions.Add(new RowDefinition());
		}
		for (var i = 0; i < ColNum; i++)
		{
			grid.ColumnDefinitions.Add(new ColumnDefinition());
		}
	}
	#region KeyPromptBrushProperty
	public Brush KeyPromptBrush
	{
		get { return (Brush)GetValue(KeyPromptBrushProperty); }
		set { SetValue(KeyPromptBrushProperty, value); }
	}

	public static readonly DependencyProperty KeyPromptBrushProperty =
		DependencyProperty.Register(
			"KeyPromptBrush",
			typeof(Brush),
			typeof(KeyboardView),
			new PropertyMetadata(null, OnKeyPromptBrushPropertyChanged));


	private static void OnKeyPromptBrushPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var keyboardView = (KeyboardView)d;
		keyboardView.SetKeyViewBackground(keyboardView.KeyPrompt, keyboardView.KeyPromptBrush);
	}
	#endregion

	#region KeyPromptProperty
	public char KeyPrompt
	{
		get { return (char)GetValue(KeyPromptProperty); }
		set { SetValue(KeyPromptProperty, value); }
	}

	public static readonly DependencyProperty KeyPromptProperty =
		DependencyProperty.Register(
			"KeyPrompt",
			typeof(char),
			typeof(KeyboardView),
			new PropertyMetadata(' ', OnKeyPromptPropertyChanged));
	private static void OnKeyPromptPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var keyboardView = (KeyboardView)d;
		keyboardView.SetKeyViewBackground((char)e.NewValue, keyboardView.KeyPromptBrush);
		keyboardView.SetKeyViewBackground((char)e.OldValue, keyboardView.Background);
	}
	#endregion
	private void SetKeyViewBackground(char key, Brush brush)
	{
		if (key != ' ')
		{
			var keyviews = grid.Children;
			var keyview = (KeyView)keyviews[KeyboardMap[key]];
			keyview.Background = brush;
		}
	}
}

