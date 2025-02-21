using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Avalonia.Controls;
using System;

namespace TagWriter.UI.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _title = "标签转换程序";

    [RelayCommand]
    private void NavigateToTagWriting()
    {
        Content = new TagWritingViewModel(this);
    }

    [RelayCommand]
    private void NavigateToNormalWork()
    {
        // 导航到馆员工作页面
    }

    [RelayCommand]
    private void MinimizeWindow(Window window)
    {
        window.WindowState = WindowState.Minimized;
    }

    [RelayCommand]
    private void MaximizeWindow(Window window)
    {
        window.WindowState = window.WindowState == WindowState.Maximized 
            ? WindowState.Normal 
            : WindowState.Maximized;
    }

    [RelayCommand]
    private void CloseWindow(Window window)
    {
        window.Close();
    }

    [RelayCommand]
    private void ShowLogin()
    {
        Content = new LoginViewModel(this);
    }

    [ObservableProperty]
    private ViewModelBase _content;
}
