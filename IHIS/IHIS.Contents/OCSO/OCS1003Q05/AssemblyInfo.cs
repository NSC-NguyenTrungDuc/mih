using System.Reflection;
using System.Runtime.CompilerServices;

//
// �E��E�블리�E�E�E����E�E��E�E�E�보�E�E�E��E�E����E� �E�합�E�E������ �E�어�E��E�다. 
// �E��E�블리�E� �E��E��E�E�E�보�E� �E�정하�E��E�
// �E� ����E� �E�을 �E��E����십�E�오.
//
[assembly: AssemblyTitle("")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("")]
[assembly: AssemblyCopyright("")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]		

//
// �E��E�블리�E�E�E�E��E�E�보�E�E�E��E�E�E� �E��E� �E�으�E�E�E��E��E��E�다.
//
//      �E� �E�E��E
//      �E� �E�E��E
//      �E�드 �E�호
//      �E�적E�E�호
//
// �E��E� �E�을 �E��E�하�E��E�E
// �E�E���E� �E�이 '*'�E� �E��E����여 �E�적E�E�호 �E�E�E�드 �E�호�E� �E�동�E��E�E�E��E�되�E�E��E��� �E�E�E�습�E�다.

[assembly: AssemblyVersion("1.0.*")]

//
// �E��E�블리�E�E�E�몁E���E��E� �E��E���� ����E� �E��E�해�E� ����E�다. 
// �E��E�블리 �E�몁E�� �E����E�E�세���E�E��E��E� Microsoft .NET Framework �E��E�E�E�E� �E��E����십�E�오.
//
// �E��E�E����E��E�E�E��E����면 �E��E� ����E� �E��E����여 �E�몁E���E� �E�어��� �E�E�E�습�E�다. 
//
// �E��E�: 
//   (*) ����E� �E��E�하�E� �E�으�E� �E��E�블리�E�E�E�몁E�� �E�E�E�E���E�다.
//   (*) KeyName�E�
//       �E��E��E�E�E��������E��E CSP(�E�호���E�E�빁E�� �E��E�자)�E�E�E��E�되�E� �E�는 ����E� �E��E����고
//       KeyFile�E� ����E� �������E�E���일�E�E�E��E�����E�다.
//   (*) KeyFile�E� KeyName �E�을 �E��E�E�E��E�하�E�
//       �E��E�과 �E�은 ���E��세�E��E� �E�성�E��E�다.
//       (1) CSP �E�에 KeyName�E� �E�으�E� ����E� ����E� �E��E��E��E�다.
//       (2) KeyName�E� �E�E��, KeyFile�E� �E�으�E� 
//           KeyFile �E�에 �E�는 ����E� CSP�E�E�E��E�된 ���E�E��E��E��E�다.
//   (*) sn.exe(�E�력���E�E��E�E�E�����E����)�E� �E��E����면 KeyFile�E�E�E�들 �E�E�E�습�E�다.
//        KeyFile�E�E�E��E�하�E�E�E��E�
//       KeyFile�E�E�E�E��는 %Project Directory%\obj\<configuration>�E�E���E��젝트 �E�력 �E�렉터�E� �E�E��를 �E��E��E��E�E���는 �E�E�� �E�E��이�E��E� ����E�다.
//       �E�를 �E��E�, KeyFile�E� ���E��젝트 �E�렉터�E��E�E�E�는 �E��E�
//       AssemblyKeyFile ����E��E�E
//       [assembly: AssemblyKeyFile("..\\..\\mykey.snk")]�E�E�E��E�합�E�다.
//   (*) �E�몁E�E��E��E� �E��E�E�E��E�입�E�다.
//       �E� �E��E�에 �E����E�E�세���E�E��E��E� Microsoft .NET Framework �E��E�E�E�E� �E��E����십�E�오.
//
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("")]
[assembly: AssemblyKeyName("")]
