using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using TagWriter.UI.Models;
using TagWriter.UI.Services;

namespace TagWriter.UI.ViewModels;

public partial class DeviceSettingsViewModel : ViewModelBase
{
    private readonly MainWindowViewModel _mainViewModel;
    private readonly ConfigService _configService;
    private DeviceConfig _config;

    public DeviceSettingsViewModel(MainWindowViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;
        _configService = new ConfigService();
        _config = _configService.LoadConfig();
        LoadConfig();
        SaveStatus = string.Empty;  // 初始化时清空保存状态
    }

    [ObservableProperty]
    private string _antennaType = string.Empty;

    [ObservableProperty]
    private string _connectionType = "USB";

    [ObservableProperty]
    private string _port = "COM1";

    [ObservableProperty]
    private int _baudRate = 9600;

    [ObservableProperty]
    private int _startBlock;

    [ObservableProperty]
    private int _endBlock;

    [ObservableProperty]
    private string _adminPassword = string.Empty;

    [ObservableProperty]
    private string _libraryCode = string.Empty;

    [ObservableProperty]
    private string _inAFI = string.Empty;

    [ObservableProperty]
    private string _outAFI = string.Empty;

    [ObservableProperty]
    private string _connectionStatus = string.Empty;

    [ObservableProperty]
    private string _saveStatus = string.Empty;

    public string[] ConnectionTypes { get; } = new[] { "USB", "COM" };
    public string[] Ports { get; } = new[] { "COM1", "COM2", "COM3", "COM4" };

    private void LoadConfig()
    {
        AntennaType = _config.AntennaType;
        ConnectionType = string.IsNullOrEmpty(_config.ConnectionType) ? "USB" : _config.ConnectionType;
        Port = string.IsNullOrEmpty(_config.Port) ? "COM1" : _config.Port;
        BaudRate = _config.BaudRate == 0 ? 9600 : _config.BaudRate;
        StartBlock = _config.StartBlock;
        EndBlock = _config.EndBlock;
        AdminPassword = _config.AdminPassword;
        LibraryCode = _config.LibraryCode;
        InAFI = _config.InAFI;
        OutAFI = _config.OutAFI;
    }

    [RelayCommand]
    private void Save()
    {
        try
        {
            _config.AntennaType = AntennaType;
            _config.ConnectionType = ConnectionType;
            _config.Port = Port;
            _config.BaudRate = BaudRate;
            _config.StartBlock = StartBlock;
            _config.EndBlock = EndBlock;
            _config.AdminPassword = AdminPassword;
            _config.LibraryCode = LibraryCode;
            _config.InAFI = InAFI;
            _config.OutAFI = OutAFI;

            _configService.SaveConfig(_config);
            SaveStatus = "✓ 保存成功";

            // 3秒后清空保存状态
            Task.Delay(3000).ContinueWith(_ => 
            {
                SaveStatus = string.Empty;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        catch (Exception ex)
        {
            SaveStatus = $"❌ 保存失败: {ex.Message}";
        }
    }

    [RelayCommand]
    private async Task TestConnection()
    {
        try
        {
            ConnectionStatus = "正在连接...";
            // TODO: 实现实际的设备连接测试
            await Task.Delay(1000); // 模拟连接测试
            ConnectionStatus = "连接成功";
        }
        catch (Exception ex)
        {
            ConnectionStatus = $"连接失败: {ex.Message}";
        }
    }

    [RelayCommand]
    private void Exit()
    {
        _mainViewModel.Content = null;
    }
} 