using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TagWriter.UI.Models;
using TagWriter.UI.Services;

namespace TagWriter.UI.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
    private readonly MainWindowViewModel _mainViewModel;
    private readonly ConfigService _configService;
    private const string MASTER_PASSWORD = "XZAdmin";  // 终极密码

    public LoginViewModel(MainWindowViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;
        _configService = new ConfigService();
    }

    [ObservableProperty]
    private string _password = string.Empty;

    [ObservableProperty]
    private string _errorMessage = string.Empty;

    [RelayCommand]
    private void Login()
    {
        // 检查终极密码
        if (_password == MASTER_PASSWORD)
        {
            ErrorMessage = string.Empty;
            _mainViewModel.Content = new DeviceSettingsViewModel(_mainViewModel);
            return;
        }

        // 检查配置的密码
        var config = _configService.LoadConfig();
        if (_password == config.AdminPassword)
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

    [RelayCommand]
    private void Cancel()
    {
        _mainViewModel.Content = null;
    }
} 