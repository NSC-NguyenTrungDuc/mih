using System.Reflection;
using System.Runtime.CompilerServices;

//
// ・ｴ・壱ｸ罷ｦｬ・・・��ｱ・・ｼ・・・簿ｳｴ・・・､・・�ｦｹ・ｱ ・啄鮒・・�｢ｵ�ｱｴ ・懍牟・ｩ・壱共. 
// ・ｴ・壱ｸ罷ｦｬ・� ・�・ｨ・・・簿ｳｴ・ｼ ・們�倣葺・､・ｴ
// ・ｴ �ｦｹ・ｱ ・廷揆 ・�・ｽ�ｱ們強・懍丶.
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
// ・ｴ・壱ｸ罷ｦｬ・・・・�・・簿ｳｴ・・・､・・・､ ・�・� ・廷愍・・・ｬ・ｱ・ｩ・壱共.
//
//      ・ｼ ・・�・
//      ・� ・・�・
//      ・誤糖 ・逸从
//      ・們�・・逸从
//
// ・ｨ・� ・廷揆 ・�・倣葺・ｰ・・
// ・・椈・� ・呷擽 '*'・ｼ ・ｬ・ｩ�ｱ們流 ・們�・・逸从 ・・・誤糖 ・逸从・� ・尖徐・ｼ・・・�・簿据・・｡・�ｱ� ・・・溢慣・壱共.

[assembly: AssemblyVersion("1.0.*")]

//
// ・ｴ・壱ｸ罷ｦｬ・・・罹ｪ・葺・､・ｴ ・ｬ・ｩ�ｱ� �椄・ｼ ・�・倣紛・ｼ �ｱｩ・壱共. 
// ・ｴ・壱ｸ罷ｦｬ ・罹ｪ・乱 ・��ｱ・・川┷�ｱ・・ｴ・ｩ・� Microsoft .NET Framework ・､・・・・ｼ ・ｸ・ｰ�ｱ們強・懍丶.
//
// ・､・・�ｦｹ・ｱ・・・ｬ・ｩ�ｱ俯ｩｴ ・ｴ・､ �椄・ｼ ・ｬ・ｩ�ｱ們流 ・罹ｪ・腹・� ・懍牟�ｱ� ・・・溢慣・壱共. 
//
// ・ｸ・�: 
//   (*) �椄・ｼ ・�・倣葺・� ・喜愍・ｴ ・ｴ・壱ｸ罷ｦｬ・・・罹ｪ・腹 ・・・・慣・壱共.
//   (*) KeyName・�
//       ・ｬ・ｩ・・・ｴ�ｯｨ��ｰ・川・ CSP(・被从�ｵ・・罹ｹ・侃 ・ｵ・餓梵)・・・､・俯据・ｴ ・壱株 �椄・ｼ ・ｸ・ｰ�ｱ俾ｳ�
//       KeyFile・� �椄・� �ｫｬ�ｱｨ・・�ｨ護攵・・・ｸ・ｰ�ｱｩ・壱共.
//   (*) KeyFile・ｼ KeyName ・廷揆 ・ｨ・・・�・倣葺・ｴ
//       ・､・語ｳｼ ・呷捩 �ｰ・｡懍┷・､・� ・晧┳・ｩ・壱共.
//       (1) CSP ・溢乱 KeyName・ｴ ・溢愍・ｴ �ｱｴ・ｹ �椄・� ・ｬ・ｩ・ｩ・壱共.
//       (2) KeyName・� ・・ｳ�, KeyFile・ｴ ・溢愍・ｴ 
//           KeyFile ・溢乱 ・壱株 �椄・� CSP・・・､・俯頗 �ｷ・・ｬ・ｩ・ｩ・壱共.
//   (*) sn.exe(・簿�･�ｱ・・ｴ・・・��ｧｸ・ｬ�ｧｰ)・ｼ ・ｬ・ｩ�ｱ俯ｩｴ KeyFile・・・誤豆 ・・・溢慣・壱共.
//        KeyFile・・・�・倣葺・・・ｽ・ｰ
//       KeyFile・・・・ｹ俯株 %Project Directory%\obj\<configuration>・・�ｰ・｡懍�晨敢 ・罹�･ ・罷�駕┣・ｬ ・・ｹ俯･ｼ ・ｰ・�・ｼ・・�ｱ俯株 ・・劇 ・・ｹ們擽・ｴ・ｼ �ｱｩ・壱共.
//       ・壱･ｼ ・､・ｴ, KeyFile・ｴ �ｰ・｡懍�晨敢 ・罷�駕┣・ｬ・・・壱株 ・ｽ・ｰ
//       AssemblyKeyFile �ｦｹ・ｱ・・
//       [assembly: AssemblyKeyFile("..\\..\\mykey.snk")]・・・�・倣鮒・壱共.
//   (*) ・罹ｪ・・�・ｰ・� ・�・・・ｵ・們桿・壱共.
//       ・ｴ ・ｵ・們乱 ・��ｱ・・川┷�ｱ・・ｴ・ｩ・� Microsoft .NET Framework ・､・・・・ｼ ・ｸ・ｰ�ｱ們強・懍丶.
//
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("")]
[assembly: AssemblyKeyName("")]
