using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ModernVPN.Core;
using ModernVPN.MVVM.Model;

namespace ModernVPN.MVVM.ViewModel
{
    internal class ProtectionViewModel : ObservableObject
    {
        public ObservableCollection<ServerModel> Servers { get; set; }

        public GlobalViewModel Global { get; } = GlobalViewModel.Instance;

        public RelayCommand ConnectCommand { get; set; }

        private string _connectButton = "Connect";

        public string ConnectButton
        {
            get { return _connectButton; }
            set
            {
                _connectButton = value;
                OnPropertyChanged();
            }
        }


        private string _connectionStatus;

        public string ConnectionStatus
        {
            get { return _connectionStatus; }
            set
            {
                _connectionStatus = value;
                OnPropertyChanged();
            }
        }


        public ProtectionViewModel()
        {
            Servers = new ObservableCollection<ServerModel>();
            // populate the  list with servers (countries)
            
            
            
            
            for (int i = 0; i < 10; i++)
            {
                switch (i)
                {
                    case 0:
                        Servers.Add(new ServerModel
                        {
                            Country = "USA",
                            Flag = "C:\\Users\\ikell\\source\\repos\\ModernVPN\\ModernVPN\\src\\images\\usa.jpeg"
                        });
                        break;
                    case 1:
                        Servers.Add(new ServerModel
                        {
                            Country = "Canada",
                            Flag = "C:\\Users\\ikell\\source\\repos\\ModernVPN\\ModernVPN\\src\\images\\canada.jpg"
                        });
                        break;
                    case 2:
                        Servers.Add(new ServerModel
                        {
                            Country = "Germany",
                            Flag = "C:\\Users\\ikell\\source\\repos\\ModernVPN\\ModernVPN\\src\\images\\germany.jpeg"
                        });
                        break;
                    case 3:
                        Servers.Add(new ServerModel
                        {
                            Country = "Italy",
                            Flag = "C:\\Users\\ikell\\source\\repos\\ModernVPN\\ModernVPN\\src\\images\\italy.jpeg"
                        });
                        break;
                    case 4:
                        Servers.Add(new ServerModel
                        {
                            Country = "France",
                            Flag = "C:\\Users\\ikell\\source\\repos\\ModernVPN\\ModernVPN\\src\\images\\france.jpeg"
                        });
                        break;
                    case 5:
                        Servers.Add(new ServerModel
                        {
                            Country = "UK",
                            Flag = "C:\\Users\\ikell\\source\\repos\\ModernVPN\\ModernVPN\\src\\images\\uk.jpeg"
                        });
                        break;
                    case 6:
                        Servers.Add(new ServerModel
                        {
                            Country = "Netherlands",
                            Flag = "C:\\Users\\ikell\\source\\repos\\ModernVPN\\ModernVPN\\src\\images\\netherlands.jpeg"
                        });
                        break;
                    case 7:
                        Servers.Add(new ServerModel
                        {
                            Country = "Switzerland",
                            Flag = "C:\\Users\\ikell\\source\\repos\\ModernVPN\\ModernVPN\\src\\images\\switzerland.jpeg"
                        });
                        break;
                    case 8:
                        Servers.Add(new ServerModel
                        {
                            Country = "Sweden",
                            Flag = "C:\\Users\\ikell\\source\\repos\\ModernVPN\\ModernVPN\\src\\images\\sweden.jpeg"
                        });
                        break;
                    case 9:
                        Servers.Add(new ServerModel
                        {
                            Country = "Ghana",
                            Flag = "C:\\Users\\ikell\\source\\repos\\ModernVPN\\ModernVPN\\src\\images\\ghana.jpeg"
                        });
                        break;
                }
            }

            ConnectCommand = new RelayCommand(o =>
            {
                if (ConnectButton == "Connect")
                {
                    Task.Run(() =>
                    {
                        ConnectionStatus = "Connecting";

                        var process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
                        process.StartInfo.ArgumentList.Add(@"/c rasdial MyServer vpnbook n8rfzew /phonebook:./VPN/VPN.pbk");
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.CreateNoWindow = true;

                        process.Start();
                        process.WaitForExit();

                        switch (process.ExitCode)
                        {
                            case 0:
                                ConnectionStatus = "Connected";
                                ConnectButton = "Disconnect";
                                Debug.WriteLine("Connected");
                                break;
                            case 691:
                                ConnectionStatus = "Invalid Username or Password";
                                Debug.WriteLine("Invalid Username or Password");
                                break;
                            case 619:
                                ConnectionStatus = "Connection Failed";
                                Debug.WriteLine("Connection Failed");
                                break;
                            default:
                                ConnectionStatus = "Unknown Error";
                                Debug.WriteLine($"Error: {process.ExitCode}");
                                break;
                        }

                    });
                }
                else
                {
                    Task.Run(() =>
                    {
                        ConnectionStatus = "Disconnecting..";

                        var process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
                        process.StartInfo.ArgumentList.Add(@"/c rasdial /d");
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.CreateNoWindow = true;

                        process.Start();
                        process.WaitForExit();

                        ConnectionStatus = "Disconnected";
                        ConnectButton = "Connect";
                        Debug.WriteLine("Disconnected");

                    });
                }
                

            });
        }

        private void ServerBuilder()
        {
            var address = "US1.vpnbook.com";
            var FolderPath = $"{Directory.GetCurrentDirectory()}/VPN";
            var PbkPath = $"{FolderPath}/{address}.pbk";

            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }

            if (File.Exists(PbkPath))
            {
                MessageBox.Show("Connection already exists");
                return;
            }

            var sb = new StringBuilder();
            sb.AppendLine("[MyServer]");
            sb.AppendLine("MEDIA=rastapi");
            sb.AppendLine("Port=VPN2-0");
            sb.AppendLine("Device=WAN Miniport (IKEv2)");
            sb.AppendLine("DEVICE=vpn");
            sb.AppendLine($"PhoneNumber={address}");
            File.WriteAllText(PbkPath, sb.ToString());


        }

    }
}
