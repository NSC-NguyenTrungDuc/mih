using System.Reflection;
using System.Runtime.CompilerServices;

//
// ������Ԯ�� ��E� �Ϲ� ������ ���� Ư�� ������ ŁE� �����˴ϴ�. 
// ������Ԯ�� ��Eõ� ������ �����Ϸ���E
// �� Ư�� ���� �����Ͻʽÿ�.
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
// ������Ԯ�� ����E������ ���� �� ����E������ �����˴ϴ�.
//
//      �� ����E
//      �� ����E
//      ����E��ȣ
//      ���� ��ȣ
//
// ��E���� �����ϰų�
// �Ʒ��� ���� '*'�� �翁EϿ� ���� ��ȣ �� ����E��ȣ�� �ڵ����� �����ǵ��� �� ��E�ֽ��ϴ�.

[assembly: AssemblyVersion("1.0.*")]

//
// ������Ԯ�� �����Ϸ���E�翁E� Ű�� �����ؾ� �մϴ�. 
// ������Ԯ ����ۡ ��E� �ڼ��� ����E� Microsoft .NET Framework ����ح�� E��Ͻʽÿ�.
//
// ���� Ư���� �翁Eϸ�E��Ҳ Ű�� �翁EϿ� ��������E������ ��E�ֽ��ϴ�. 
//
// E�E 
//   (*) Ű�� ��������E������E������Ԯ�� ������ ��E�����ϴ�.
//   (*) KeyName��
//       �翁E� ��ǻ�Ϳ��� CSP(��ȣȭ ���� ������)�� ��ġ�Ǿ�E�ִ� Ű�� E��ϰ�E
//       KeyFile�� Ű�� ���Ե� ������ E��մϴ�.
//   (*) KeyFile��EKeyName ���� ��� �����ϸ�E
//       ������E���� ���μ����� �����˴ϴ�.
//       (1) CSP �ȿ� KeyName�� ������E�ش�EŰ�� �翁E˴ϴ�.
//       (2) KeyName�� ����E KeyFile�� ������E
//           KeyFile �ȿ� �ִ� Ű�� CSP�� ��ġ�� �� �翁E˴ϴ�.
//   (*) sn.exe(������ �̸� ��ƿ��Ƽ)�� �翁Eϸ�EKeyFile�� ����E��E�ֽ��ϴ�.
//        KeyFile�� �����ϴ� �濁E
//       KeyFile�� ��ġ�� %Project Directory%\obj\<configuration>�� ������Ʈ ��� ���͸� ��ġ�� �������� �ϴ� ��E��ġ�̾��� �մϴ�.
//       ���� �龁E KeyFile�� ������Ʈ ���͸��� �ִ� �濁E
//       AssemblyKeyFile Ư���� 
//       [assembly: AssemblyKeyFile("..\\..\\mykey.snk")]�� �����մϴ�.
//   (*) ����E������ ���� �ɼ��Դϴ�.
//       �� �ɼǿ� ��E� �ڼ��� ����E� Microsoft .NET Framework ����ح�� E��Ͻʽÿ�.
//
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("")]
[assembly: AssemblyKeyName("")]
