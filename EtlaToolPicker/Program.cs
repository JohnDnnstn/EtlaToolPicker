using EtlaToolPicker.BackingData;

namespace EtlaToolPicker;

public static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.

        ApplicationConfiguration.Initialize();

        var data = new TopLevelData
        {
            TargetDirectory = "C:/Projects/Tests/PickerTest",
            TargetNamespace = "PickerTest",
            HasBlackAndWhite = true,
            Next = TopLevelData.AllTopLevelData[2]
        };
        Application.Run(new TopLevelForm(data));
    }

    public enum ZeroToThree { ZERO, ONE, TWO, THREE};
}