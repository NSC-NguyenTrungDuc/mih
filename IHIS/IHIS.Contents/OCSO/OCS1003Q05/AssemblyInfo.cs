using System.Reflection;
using System.Runtime.CompilerServices;

//
// E´Eˆë¸”ë¦¬EEE€ú±EE¼EEE•ë³´EEE¤EEú¦¹E± E‘í•©EEú¢µú±´ Eœì–´E©Eˆë‹¤. 
// E´Eˆë¸”ë¦¬E€ E€E¨EEE•ë³´E¼ E˜ì •í•˜E¤E´
// E´ ú¦¹E± E’ì„ E€E½ú±˜ì‹­Eœì˜¤.
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
// E´Eˆë¸”ë¦¬EEEE EE•ë³´EEE¤EEE¤ E€E€ E’ìœ¼EEE¬E±E©Eˆë‹¤.
//
//      E¼ EE E
//      E€ EE E
//      EŒë“œ Eˆí˜¸
//      E˜ì EEˆí˜¸
//
// E¨E  E’ì„ E€E•í•˜E°EE
// EE˜E€ E™ì´ '*'E¼ E¬E©ú±˜ì—¬ E˜ì EEˆí˜¸ EEEŒë“œ Eˆí˜¸E€ Eë™E¼EEE€E•ë˜EE¡Eú±  EEEˆìŠµEˆë‹¤.

[assembly: AssemblyVersion("1.0.*")]

//
// E´Eˆë¸”ë¦¬EEEœëªE•˜E¤E´ E¬E©ú±  ú¤E¼ E€E•í•´E¼ ú±©Eˆë‹¤. 
// E´Eˆë¸”ë¦¬ EœëªE— E€ú±EEì„¸ú±EE´E©E€ Microsoft .NET Framework E¤EEEE¼ E¸E°ú±˜ì‹­Eœì˜¤.
//
// E¤EEú¦¹E±EEE¬E©ú±˜ë©´ E´E¤ ú¤E¼ E¬E©ú±˜ì—¬ EœëªE• E€ Eœì–´ú±  EEEˆìŠµEˆë‹¤. 
//
// E¸E : 
//   (*) ú¤E¼ E€E•í•˜E€ EŠìœ¼E´ E´Eˆë¸”ë¦¬EEEœëªE•  EEEEŠµEˆë‹¤.
//   (*) KeyNameE€
//       E¬E©EEE´ú¯¨ú °EìE CSP(E”í˜¸úµEEœë¹EŠ¤ EµE‰ì)EEE¤E˜ë˜E´ EˆëŠ” ú¤E¼ E¸E°ú±˜ê³ 
//       KeyFileE€ ú¤E€ ú«¬ú±¨EEú¨Œì¼EEE¸E°ú±©Eˆë‹¤.
//   (*) KeyFileE¼ KeyName E’ì„ E¨EEE€E•í•˜E´
//       E¤EŒê³¼ E™ì€ ú°E¡œì„¸E¤E€ Eì„±E©Eˆë‹¤.
//       (1) CSP Eˆì— KeyNameE´ Eˆìœ¼E´ ú±´E¹ ú¤E€ E¬E©E©Eˆë‹¤.
//       (2) KeyNameE€ EE³ , KeyFileE´ Eˆìœ¼E´ 
//           KeyFile Eˆì— EˆëŠ” ú¤E€ CSPEEE¤E˜ëœ ú·EE¬E©E©Eˆë‹¤.
//   (*) sn.exe(E•ë ¥ú±EE´EEE ú§¸E¬ú§°)E¼ E¬E©ú±˜ë©´ KeyFileEEEŒë“¤ EEEˆìŠµEˆë‹¤.
//        KeyFileEEE€E•í•˜EEE½E°
//       KeyFileEEEE¹˜ëŠ” %Project Directory%\obj\<configuration>EEú°E¡œì íŠ¸ Eœë ¥ E”ë ‰í„°E¬ EE¹˜ë¥¼ E°E€E¼EEú±˜ëŠ” EEŒ€ EE¹˜ì´E´E¼ ú±©Eˆë‹¤.
//       Eˆë¥¼ E¤E´, KeyFileE´ ú°E¡œì íŠ¸ E”ë ‰í„°E¬EEEˆëŠ” E½E°
//       AssemblyKeyFile ú¦¹E±EE
//       [assembly: AssemblyKeyFile("..\\..\\mykey.snk")]EEE€E•í•©Eˆë‹¤.
//   (*) EœëªEE€E°E€ E EEEµE˜ì…Eˆë‹¤.
//       E´ EµE˜ì— E€ú±EEì„¸ú±EE´E©E€ Microsoft .NET Framework E¤EEEE¼ E¸E°ú±˜ì‹­Eœì˜¤.
//
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("")]
[assembly: AssemblyKeyName("")]
