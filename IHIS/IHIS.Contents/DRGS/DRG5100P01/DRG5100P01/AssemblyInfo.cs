using System.Reflection;
using System.Runtime.CompilerServices;

//
// ¾ûØÀºúÔ®¿¡ ´EÑ ÀÏ¹İ Á¤º¸´Â ´ÙÀ½ Æ¯¼º ÁıÇÕÀ» ÅEØ Á¦¾ûÑË´Ï´Ù. 
// ¾ûØÀºúÔ®¿Í °EÃµÈ Á¤º¸¸¦ ¼öÁ¤ÇÏ·Á¸E
// ÀÌ Æ¯¼º °ªÀ» º¯°æÇÏ½Ê½Ã¿À.
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
// ¾ûØÀºúÔ®ÀÇ ¹öÀEÁ¤º¸´Â ´ÙÀ½ ³× °¡ÁE°ªÀ¸·Î ±¸¼ºµË´Ï´Ù.
//
//      ÁÖ ¹öÀE
//      ºÎ ¹öÀE
//      ºôµE¹øÈ£
//      ¼öÁ¤ ¹øÈ£
//
// ¸ğµE°ªÀ» ÁöÁ¤ÇÏ°Å³ª
// ¾Æ·¡¿Í °°ÀÌ '*'¸¦ »ç¿EÏ¿© ¼öÁ¤ ¹øÈ£ ¹× ºôµE¹øÈ£°¡ ÀÚµ¿À¸·Î ÁöÁ¤µÇµµ·Ï ÇÒ ¼EÀÖ½À´Ï´Ù.

[assembly: AssemblyVersion("1.0.*")]

//
// ¾ûØÀºúÔ®¿¡ ¼­¸úãÏ·Á¸E»ç¿EÒ Å°¸¦ ÁöÁ¤ÇØ¾ß ÇÕ´Ï´Ù. 
// ¾ûØÀºúÔ® ¼­¸úÛ¡ °EÑ ÀÚ¼¼ÇÑ ³»¿Eº Microsoft .NET Framework ¼³¸úØ­¸¦ ÂE¶ÇÏ½Ê½Ã¿À.
//
// ´ÙÀ½ Æ¯¼ºÀ» »ç¿EÏ¸E¾ûÒ² Å°¸¦ »ç¿EÏ¿© ¼­¸úãÒÁEÁ¦¾ûãÒ ¼EÀÖ½À´Ï´Ù. 
//
// ÂEE 
//   (*) Å°¸¦ ÁöÁ¤ÇÏÁE¾ÊÀ¸¸E¾ûØÀºúÔ®¿¡ ¼­¸úãÒ ¼E¾ø½À´Ï´Ù.
//   (*) KeyNameÀº
//       »ç¿EÚ ÄÄÇ»ÅÍ¿¡¼­ CSP(¾ÏÈ£È­ ¼­ºñ½º °ø±ŞÀÚ)¿¡ ¼³Ä¡µÇ¾EÀÖ´Â Å°¸¦ ÂE¶ÇÏ°E
//       KeyFileÀº Å°°¡ Æ÷ÇÔµÈ ÆÄÀÏÀ» ÂE¶ÇÕ´Ï´Ù.
//   (*) KeyFile°EKeyName °ªÀ» ¸ğµÎ ÁöÁ¤ÇÏ¸E
//       ´ÙÀ½°E°°Àº ÇÁ·Î¼¼½º°¡ »ı¼ºµË´Ï´Ù.
//       (1) CSP ¾È¿¡ KeyNameÀÌ ÀÖÀ¸¸EÇØ´EÅ°°¡ »ç¿EË´Ï´Ù.
//       (2) KeyNameÀº ¾ø°E KeyFileÀÌ ÀÖÀ¸¸E
//           KeyFile ¾È¿¡ ÀÖ´Â Å°°¡ CSP¿¡ ¼³Ä¡µÈ ÈÄ »ç¿EË´Ï´Ù.
//   (*) sn.exe(°­·ÂÇÑ ÀÌ¸§ À¯Æ¿¸®Æ¼)¸¦ »ç¿EÏ¸EKeyFileÀ» ¸¸µE¼EÀÖ½À´Ï´Ù.
//        KeyFileÀ» ÁöÁ¤ÇÏ´Â °æ¿E
//       KeyFileÀÇ À§Ä¡´Â %Project Directory%\obj\<configuration>ÀÇ ÇÁ·ÎÁ§Æ® Ãâ·Â µğ·ºÅÍ¸® À§Ä¡¸¦ ±âÁØÀ¸·Î ÇÏ´Â »ó´EÀ§Ä¡ÀÌ¾ûÚß ÇÕ´Ï´Ù.
//       ¿¹¸¦ µé¾E KeyFileÀÌ ÇÁ·ÎÁ§Æ® µğ·ºÅÍ¸®¿¡ ÀÖ´Â °æ¿E
//       AssemblyKeyFile Æ¯¼ºÀ» 
//       [assembly: AssemblyKeyFile("..\\..\\mykey.snk")]·Î ÁöÁ¤ÇÕ´Ï´Ù.
//   (*) ¼­¸EÁö¿¬Àº °úÍŞ ¿É¼ÇÀÔ´Ï´Ù.
//       ÀÌ ¿É¼Ç¿¡ ´EÑ ÀÚ¼¼ÇÑ ³»¿Eº Microsoft .NET Framework ¼³¸úØ­¸¦ ÂE¶ÇÏ½Ê½Ã¿À.
//
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("")]
[assembly: AssemblyKeyName("")]
