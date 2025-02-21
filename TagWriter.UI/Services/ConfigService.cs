using System.IO;
using System.Text.Json;
using System.Reflection;
using TagWriter.UI.Models;

namespace TagWriter.UI.Services;

public class ConfigService
{
    private const string ConfigFile = "config.dat";  // 改为.dat后缀以表明是加密文件
    private readonly string _configPath;
    private readonly EncryptionService _encryptionService;

    public ConfigService()
    {
        // 获取应用程序执行目录
        var exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        _configPath = Path.Combine(exePath!, ConfigFile);
        _encryptionService = new EncryptionService();
    }

    public DeviceConfig LoadConfig()
    {
        try
        {
            if (File.Exists(_configPath))
            {
                // 读取加密的配置文件
                var encryptedJson = File.ReadAllText(_configPath);
                // 解密
                var json = _encryptionService.Decrypt(encryptedJson);
                return JsonSerializer.Deserialize<DeviceConfig>(json) ?? new DeviceConfig();
            }
        }
        catch
        {
            // 如果解密失败，返回默认配置
        }
        return new DeviceConfig();
    }

    public void SaveConfig(DeviceConfig config)
    {
        // 序列化配置
        var json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
        // 加密
        var encryptedJson = _encryptionService.Encrypt(json);
        // 保存加密后的内容
        File.WriteAllText(_configPath, encryptedJson);
    }
} 