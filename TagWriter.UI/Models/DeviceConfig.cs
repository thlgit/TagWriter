namespace TagWriter.UI.Models;

public class DeviceConfig
{
    // 设备配置
    public string AntennaType { get; set; } = string.Empty;
    public string ConnectionType { get; set; } = "USB";
    public string Port { get; set; } = "COM1";
    public int BaudRate { get; set; } = 115200;
    public int StartBlock { get; set; } = 0;
    public int EndBlock { get; set; } = 10;

    // 系统配置
    public string AdminPassword { get; set; } = "admin";  // 配置的管理员密码
    public string LibraryCode { get; set; } = string.Empty;  // 馆代码
    public string InAFI { get; set; } = "C2";  // 改为字符串类型
    public string OutAFI { get; set; } = "C1";  // 改为字符串类型
} 