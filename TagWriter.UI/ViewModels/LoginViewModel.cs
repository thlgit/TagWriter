using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TagWriter.UI.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
    private readonly MainWindowViewModel _mainViewModel;

    public LoginViewModel(MainWindowViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;
    }

    [ObservableProperty]
    private string _password = string.Empty;

    [ObservableProperty]
    private string _errorMessage = string.Empty;

    [RelayCommand]
    private void Cancel()
    {
        _mainViewModel.Content = null;
    }

    [RelayCommand]
    private void Login()
    {
        if (_password == "admin") // 这里应该使用加密的密码验证
        {
            ErrorMessage = string.Empty;
            _mainViewModel.Content = new DeviceSettingsViewModel(_mainViewModel);
        }
        else
        {
            Password = string.Empty;
            ErrorMessage = "密码错误，请重试";
        }
    }
} 