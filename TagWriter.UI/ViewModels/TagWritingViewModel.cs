using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TagWriter.UI.ViewModels;

public partial class TagWritingViewModel : ViewModelBase
{
    private readonly MainWindowViewModel _mainViewModel;

    public TagWritingViewModel(MainWindowViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;
    }

    [ObservableProperty]
    private string _writeBarcode = string.Empty;

    [ObservableProperty]
    private string _writeLibraryCode = string.Empty;

    [ObservableProperty]
    private string _readBarcode = string.Empty;

    [ObservableProperty]
    private string _readLibraryCode = string.Empty;

    [ObservableProperty]
    private string _statusMessage = string.Empty;

    [ObservableProperty]
    private double _progressValue = 0;

    [ObservableProperty]
    private int _currentTask = 1;

    [RelayCommand]
    private void Cancel()
    {
        // 返回主页面
        _mainViewModel.Content = null;
    }

    [RelayCommand]
    private void Confirm()
    {
        // 确认写入标签
    }
} 