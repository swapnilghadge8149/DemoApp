// -----------------------------------------------------------------------
//  <copyright file="CustomImageButton.cs" company="YASH Technologies">
//      Copyright (c) YASH Technologies. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------
using Microsoft.Maui.Graphics.Converters;
using System.Windows.Input;

namespace DemoApp.CustomControls;

public partial class CustomImageButton : ContentView
{
    public event EventHandler Clicked;
    private static ColorTypeConverter colorTypeConverter;

    /// <summary>
    /// Bindable TextProperty
    /// </summary>
    public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(CustomImageButton), defaultBindingMode: BindingMode.TwoWay, propertyChanged : TextChanged);

    /// <summary>
    /// Gets or sets Text
    /// </summary>
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    /// <summary>
    /// Bindable ButtonLeftImage
    /// </summary>
    public static readonly BindableProperty ButtonLeftImage
    = BindableProperty.Create(nameof(LeftImage), typeof(string), typeof(CustomImageButton), propertyChanged: LeftImageChanged);

    /// <summary>
    /// Gets or sets LeftImage
    /// </summary>
    public string LeftImage
    {
        get => (string)GetValue(ButtonLeftImage);
        set => SetValue(ButtonLeftImage, value);
    }

    /// <summary>
    /// Bindable ButtonRightImage Property
    /// </summary>
    public static readonly BindableProperty ButtonRightImage
   = BindableProperty.Create(nameof(RightImage), typeof(string), typeof(CustomImageButton), propertyChanged: RightImageChanged);

    /// <summary>
    /// Gets or sets RightImage
    /// </summary>
    public string RightImage
    {
        get => (string)GetValue(ButtonRightImage);
        set => SetValue(ButtonRightImage, value);
    }

    /// <summary>
    /// Bindable BgColor Property
    /// </summary>
    public static readonly BindableProperty BgColor
    = BindableProperty.Create(nameof(FrameBackgroundColor), typeof(string), typeof(CustomImageButton), "fff", defaultBindingMode: BindingMode.TwoWay, propertyChanged: FrameColorChanged);

    /// <summary>
    /// Gets or sets FrameBackgroundColor
    /// </summary>
    public string FrameBackgroundColor
    {
        get => (string)GetValue(BgColor);
        set => SetValue(BgColor, value);
    }

    /// <summary>
    /// Bindable TxtColor Property 
    /// </summary>
    public static readonly BindableProperty TxtColor
    = BindableProperty.Create(nameof(TextColor), typeof(string), typeof(CustomImageButton), "#000");

    /// <summary>
    /// Gets or sets TextColor
    /// </summary>
    public string TextColor
    {
        get => (string)GetValue(TxtColor);
        set => SetValue(TxtColor, value);
    }

    /// <summary>
    /// Bindable Command Property 
    /// </summary>
    public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command),
    typeof(ICommand), typeof(CustomImageButton), null);

    /// <summary>
    /// Gets or sets Command
    /// </summary>
    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    /// <summary>
    /// Bindable CommandPropertyParam Property 
    /// </summary>
    public static readonly BindableProperty CommandPropertyParam = BindableProperty.Create(nameof(CommandParam),
    typeof(object), typeof(CustomImageButton), null);

    /// <summary>
    /// Gets or sets CommandParam
    /// </summary>
    public object CommandParam
    {
        get => (object)GetValue(CommandPropertyParam);
        set => SetValue(CommandPropertyParam, value);
    }

    /// <summary>
    /// CustomImageButton constructor
    /// </summary>
    public CustomImageButton()
    {
        InitializeComponent();
        colorTypeConverter = new ColorTypeConverter();
        this.GestureRecognizers.Add(new TapGestureRecognizer
        {
            Command = new Command(() => {
                Clicked?.Invoke(this, EventArgs.Empty);
                if (Command != null)
                {
                    if (Command.CanExecute(this))
                        Command.Execute(this);
                }
            })

        });
    }

    /// <summary>
    /// OnParentSet
    /// </summary>
    protected override void OnParentSet()
    {
        base.OnParentSet();
        if (LeftImage != null)
        {
            leftBtnIcon.IsVisible = true;
            leftBtnIcon.Source = LeftImage;
        }
        if (RightImage != null)
        {
            rightBtnIcon.IsVisible = true;
            rightBtnIcon.Source = RightImage;
        }
        btnText.Text = Text;
        Color frameBackground = (Color)(colorTypeConverter.ConvertFromInvariantString(FrameBackgroundColor));
        myFrame.BackgroundColor = frameBackground;
        btnText.TextColor = (Color)(colorTypeConverter.ConvertFromInvariantString(TextColor));

        stack.BackgroundColor = frameBackground;
        btnText.BackgroundColor = frameBackground;
        leftBtnIcon.BackgroundColor = frameBackground;
        rightBtnIcon.BackgroundColor = frameBackground;
    }

    /// <summary>
    /// On TextChanged
    /// </summary>
    /// <param name="bindable">bindable</param>
    /// <param name="oldValue">oldValue</param>
    /// <param name="newValue">newValue</param>
    private static void TextChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CustomImageButton)bindable;
        control.btnText.Text = newValue.ToString();
    }

    /// <summary>
    /// On FrameColorChanged
    /// </summary>
    /// <param name="bindable">bindable</param>
    /// <param name="oldValue">oldValue</param>
    /// <param name="newValue">newValue</param>
    private static void FrameColorChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CustomImageButton)bindable;
        Color btnColor =  (Color)colorTypeConverter.ConvertFromInvariantString(newValue.ToString());
        control.myFrame.BackgroundColor = btnColor;
        control.stack.BackgroundColor = btnColor;
        control.btnText.BackgroundColor = btnColor;
        control.leftBtnIcon.BackgroundColor = btnColor;
        control.rightBtnIcon.BackgroundColor = btnColor;
    }

    /// <summary>
    /// On LeftImageChanged
    /// </summary>
    /// <param name="bindable">bindable</param>
    /// <param name="oldValue">oldValue</param>
    /// <param name="newValue">newValue</param>
    private static void LeftImageChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CustomImageButton)bindable;
        control.leftBtnIcon.Source = newValue.ToString();
    }

    /// <summary>
    /// On RightImageChanged
    /// </summary>
    /// <param name="bindable">bindable</param>
    /// <param name="oldValue">oldValue</param>
    /// <param name="newValue">newValue</param>
    private static void RightImageChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CustomImageButton)bindable;
        control.rightBtnIcon.Source = newValue.ToString();
    }

}