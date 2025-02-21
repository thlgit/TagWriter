using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TagWriter.UI.ViewModels;

public partial class DeviceSettingsViewModel : ViewModelBase
{
    private readonly MainWindowViewModel _mainViewModel;

    public DeviceSettingsViewModel(MainWindowViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;
    }

    [ObservableProperty]
    private string _antennaType = string.Empty;

    [ObservableProperty]
    private string _connectionType = string.Empty;

    [ObservableProperty]
    private string _port = string.Empty;

    [ObservableProperty]
    private string _baudRate = string.Empty;

    [ObservableProperty]
    private string _startAddress = string.Empty;

    [ObservableProperty]
    private string _endAddress = string.Empty;

    [ObservableProperty]
    private string _libraryCode = string.Empty;

    [ObservableProperty]
    private string _benefitCode = string.Empty;

    [ObservableProperty]
    private string _inAFI = string.Empty;

    [ObservableProperty]
    private string _outAFI = string.Empty;

    [ObservableProperty]
    private bool _useAFI = false;

    [ObservableProperty]
    private bool _useDSFID = false;

    [RelayCommand]
    private void Save()
    {
        // 保存配置
        _mainViewModel.Content = null;
    }

    [RelayCommand]
    private void Exit()
    {
        _mainViewModel.Content = null;
    }
} 