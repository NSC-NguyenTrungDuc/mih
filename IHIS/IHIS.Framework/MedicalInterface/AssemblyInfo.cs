using System.Reflection;
using System.Runtime.CompilerServices;

//
// ｾ錡ﾀｺ昤ｮｿ｡ ｴ・ﾑ ﾀﾏｹﾝ ﾁ､ｺｸｴﾂ ｴﾙﾀｽ ﾆｯｼｺ ﾁﾇﾕﾀｻ ﾅ・ﾘ ﾁｦｾ鋙ﾋｴﾏｴﾙ. 
// ｾ錡ﾀｺ昤ｮｿﾍ ｰ・ﾃｵﾈ ﾁ､ｺｸｸｦ ｼ､ﾇﾏｷﾁｸ・
// ﾀﾌ ﾆｯｼｺ ｰｪﾀｻ ｺｯｰ貮ﾏｽﾊｽﾃｿﾀ.
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
// ｾ錡ﾀｺ昤ｮﾀﾇ ｹ・ﾁ､ｺｸｴﾂ ｴﾙﾀｽ ｳﾗ ｰ｡ﾁ・ｰｪﾀｸｷﾎ ｱｸｼｺｵﾋｴﾏｴﾙ.
//
//      ﾁﾖ ｹ・
//      ｺﾎ ｹ・
//      ｺ・ｹ｣
//      ｼ､ ｹ｣
//
// ｸ・ｰｪﾀｻ ﾁ､ﾇﾏｰﾅｳｪ
// ｾﾆｷ｡ｿﾍ ｰｰﾀﾌ '*'ｸｦ ｻ鄙・ﾏｿｩ ｼ､ ｹ｣ ｹﾗ ｺ・ｹ｣ｰ｡ ﾀﾚｵｿﾀｸｷﾎ ﾁ､ｵﾇｵｵｷﾏ ﾇﾒ ｼ・ﾀﾖｽﾀｴﾏｴﾙ.

[assembly: AssemblyVersion("1.0.*")]

//
// ｾ錡ﾀｺ昤ｮｿ｡ ｼｭｸ桒ﾏｷﾁｸ・ｻ鄙・ﾒ ﾅｰｸｦ ﾁ､ﾇﾘｾﾟ ﾇﾕｴﾏｴﾙ. ｾ錡ﾀｺ昤ｮ ｼｭｸ暠｡ ｴ・ﾑ ﾀﾚｼｼﾇﾑ ｳｻｿ・ｺ 
// Microsoft .NET Framework ｼｳｸ晴ｭｸｦ ﾂ・ｶﾇﾏｽﾊｽﾃｿﾀ.
//
// ｼｭｸ桒ﾏｴﾂ ｵ･ ｻ鄙・ﾒ ﾅｰｸｦ ﾁｦｾ鏞ﾏｷﾁｸ・ｾﾆｷ｡ ﾆｯｼｺﾀｻ ｻ鄙・ﾕｴﾏｴﾙ. 
//
// ﾂ・・ 
//   (*) ﾅｰｸｦ ﾁ､ﾇﾏﾁ・ｾﾊﾀｸｸ・ｾ錡ﾀｺ昤ｮｿ｡ ｼｭｸ桒ﾒ ｼ・ｾﾀｴﾏｴﾙ.
//   (*) KeyNameﾀｺ
//       ｻ鄙・ﾚ ﾄﾄﾇｻﾅﾍﾀﾇ CSP(ｾﾏﾈ｣ﾈｭ ｼｭｺｺ ｰﾞﾀﾚ)ｿ｡
//        ｼｳﾄ｡ｵﾇｾ・ﾀﾖｴﾂ ﾅｰｸｦ ﾂ・ｶﾇﾏｰ・KeyFileﾀｺ ﾅｰｰ｡ ﾆﾔｵﾈ ﾆﾄﾀﾏﾀｻ
//        ﾂ・ｶﾇﾕｴﾏｴﾙ.
//   (*) KeyFileｰ・KeyName ｰｪﾀｻ ｸﾎ ﾁ､ﾇﾏｸ・
//       ｴﾙﾀｽｰ・ｰｰﾀｺ ﾇﾁｷﾎｼｼｽｺｰ｡ ｹﾟｻﾇﾕｴﾏｴﾙ.
//       (1) CSPｿ｡ KeyNameﾀﾌ ﾀﾖﾀｸｸ・ﾇﾘｴ・ﾅｰｰ｡ ｻ鄙・ﾋｴﾏｴﾙ.
//       (2) KeyNameﾀｺ ｾ・ KeyFileﾀﾌ ﾀﾖﾀｸｸ・
//           KeyFileﾀﾇ ﾅｰｰ｡ CSPｿ｡ ｼｳﾄ｡ｵﾇｾ・ｻ鄙・ﾋｴﾏｴﾙ.
//   (*) sn.exe(ｰｭｷﾂﾇﾑ ﾀﾌｸｧ ﾀｯﾆｿｸｮﾆｼ)ｸｦ ｻ鄙・ﾏｸ・KeyFileﾀｻ ｸｸｵ・ｼ・ﾀﾖｽﾀｴﾏｴﾙ.
//        KeyFileﾀｻ ﾁ､ﾇﾏｴﾂ ｰ豼・
//       KeyFileﾀﾇ ﾀｧﾄ｡ｴﾂ %Project Directory%\obj\<configuration>ﾀﾇ ﾇﾁｷﾎﾁｧﾆｮ ﾃ箙ﾂ ｵｺﾅﾍｸｮ ﾀｧﾄ｡ｸｦ ｱ簔ﾘﾀｸｷﾎ ﾇﾏｴﾂ ｻ・ﾀｧﾄ｡ﾀﾌｾ﨨ﾟ ﾇﾕｴﾏｴﾙ.
//       ｿｹｸｦ ｵ鮴・ KeyFileﾀﾌ ﾇﾁｷﾎﾁｧﾆｮ ｵｺﾅﾍｸｮｿ｡ ﾀﾖｴﾂ ｰ豼・
//       AssemblyKeyFile ﾆｯｼｺﾀｻ 
//       [assembly: AssemblyKeyFile("..\\..\\mykey.snk")]ｷﾎ ﾁ､ﾇﾕｴﾏｴﾙ.
//   (*) ｼｭｸ・ｿｬｱ箒ﾂ ｰ敎ﾞ ｿﾉｼﾇﾀﾔｴﾏｴﾙ.
//       ﾀﾌ ｿﾉｼﾇｿ｡ ｴ・ﾑ ﾀﾚｼｼﾇﾑ ｳｻｿ・ｺ Microsoft .NET Framework ｼｳｸ晴ｭｸｦ ﾂ・ｶﾇﾏｽﾊｽﾃｿﾀ.
//
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("")]
[assembly: AssemblyKeyName("")]
