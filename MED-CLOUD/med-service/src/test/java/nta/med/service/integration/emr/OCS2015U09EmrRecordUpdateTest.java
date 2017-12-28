package nta.med.service.integration.emr;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2015U09EmrRecordUpdateTest extends MessageRequestTest{

	@Test
	public void testOCS2015U09EmrRecordUpdate() throws InterruptedException {
		
		EmrServiceProto.OCS2015U09EmrRecordUpdateRequest request =EmrServiceProto.OCS2015U09EmrRecordUpdateRequest
				.newBuilder()
				.setBunho("000000001")
				.setContent("\357\273\277<?xml version=\"1.0\" encoding=\"utf-8\"?><Mml version=\"2.3\" createDate=\"2016/03/10 T03:36:23\" xmlns:mmlCi=\"http://www.medxml.net/MML/SharedComponent/CreatorInfo/1.0\" xmlns:mmlPsi=\"http://www.medxml.net/MML/SharedComponent/PersonalizedInfo/1.0\" xmlns:mmlCm=\"http://www.medxml.net/MML/SharedComponent/Common/1.0\" xmlns:mmlAd=\"http://www.medxml.net/MML/SharedComponent/Address/1.0\" xmlns:mmlDp=\"http://www.medxml.net/MML/SharedComponent/Department/1.0\" xmlns:mmlFc=\"http://www.medxml.net/MML/SharedComponent/Facility/1.0\" xmlns:mmlNm=\"http://www.medxml.net/MML/SharedComponent/Name/1.0\" xmlns:mmlPh=\"http://www.medxml.net/MML/SharedComponent/Phone/1.0\" xmlns:mmlRd=\"http://www.medxml.net/MML/ContentModule/RegisteredDiagnosis/1.0\" xmlns:claim=\"http://www.medxml.net/claim/claimModule/2.1\" xmlns:mmlHi=\"http://www.medxml.net/MML/ContentModule/HealthInsurance/1.1\"><MmlHeader><mmlCi:CreatorInfo><mmlPsi:PersonalizedInfo><mmlCm:Id mmlCm:type=\"facility\" mmlCm:tableId=\"MML0024\"></mmlCm:Id><mmlPsi:personName><mmlNm:Name mmlNm:repCode=\"I\" mmlNm:tableId=\"MML0025\" /></mmlPsi:personName><mmlFc:Facility><mmlFc:Id><mmlCm:Id mmlCm:type=\"facility\" mmlCm:tableId=\"MML0024\"></mmlCm:Id></mmlFc:Id><mmlFc:name mmlFc:repCode=\"I\" mmlFc:tableId=\"MML0025\"></mmlFc:name></mmlFc:Facility><mmlDp:Department><mmlDp:Id><mmlCm:Id mmlCm:type=\"medical\" mmlCm:tableId=\"MML0029\"></mmlCm:Id></mmlDp:Id><mmlDp:name mmlDp:repCode=\"I\" mmlDp:tableId=\"MML0025\"></mmlDp:name></mmlDp:Department></mmlPsi:PersonalizedInfo></mmlCi:CreatorInfo><masterId><mmlCm:Id mmlCm:type=\"facility\" mmlCm:tableId=\"MML0024\">000000001</mmlCm:Id></masterId><toc><tocItem>http://www.medxml.net/MML/SharedComponent/Common/1.0</tocItem><tocItem>http://www.medxml.net/MML/SharedComponent/CreatorInfo/1.0</tocItem><tocItem>http://www.medxml.net/MML/SharedComponent/Department/1.0</tocItem><tocItem>http://www.medxml.net/MML/SharedComponent/Facility/1.0</tocItem><tocItem>http://www.medxml.net/MML/SharedComponent/Name/1.0</tocItem><tocItem>http://www.medxml.net/MML/SharedComponent/PersonalizedInfo/1.0</tocItem><tocItem>http://www.medxml.net/claim/claimModule/2.1</tocItem><tocItem>http://www.medxml.net/MML/ContentModule/HealthInsurance/1.1</tocItem></toc><encryptInfo>no encryption</encryptInfo></MmlHeader><MmlBody><MmlModuleItem><docInfo contentModuleType=\"progressCourse\"><docId><uid>1577</uid></docId><title>Progress Course</title><confirmDate>2016/02/19</confirmDate><securityLevel><accessRight permit=\"all\" /></securityLevel><mmlCi:CreatorInfo><mmlPsi:PersonalizedInfo><mmlCm:Id mmlCm:type=\"facility\" mmlCm:tableId=\"MML0024\">10333</mmlCm:Id><mmlPsi:personName><mmlNm:Name mmlNm:repCode=\"I\" mmlNm:tableId=\"MML0025\" /></mmlPsi:personName><mmlFc:Facility><mmlFc:Id><mmlCm:Id mmlCm:type=\"facility\" mmlCm:tableId=\"MML0024\">333</mmlCm:Id></mmlFc:Id><mmlFc:name mmlFc:repCode=\"I\" mmlFc:tableId=\"MML0025\">01</mmlFc:name></mmlFc:Facility><mmlDp:Department><mmlDp:Id><mmlCm:Id mmlCm:type=\"medical\" mmlCm:tableId=\"MML0029\"></mmlCm:Id></mmlDp:Id><mmlDp:name mmlDp:repCode=\"I\" mmlDp:tableId=\"MML0025\"></mmlDp:name></mmlDp:Department></mmlPsi:PersonalizedInfo></mmlCi:CreatorInfo></docInfo><content><mmlPc:ProgressCourseModule xmlns:mmlPc=\"http://www.medxml.net/MML/ContentModule/ProgressCourse/1.0\"><mmlPc:structuredExpression><mmlPc:problemItem><mmlPc:problem mmlPc:dxUid=\"2c2834d1-c92d-4a21-b42f-0c4449535c72\"></mmlPc:problem><mmlPc:plan><mmlPc:planNotes>#@# dftrgrt</mmlPc:planNotes></mmlPc:plan></mmlPc:problemItem><mmlPc:problemItem><mmlPc:problem mmlPc:dxUid=\"e61c6bd8-93e0-403e-b450-a4c10f5f865e\"></mmlPc:problem><mmlPc:plan><mmlPc:planNotes>$IMG$            C:\\Users\\Tuananh\\AppData\\Local\\Apps\\2.0\\OW5QJOGC.D3L\\M39VDWBR.404\\kcck..tion_8cac242e7bcedb40_0001.0000_b4c4de4d8ccc012c\\Data\\333\\000000001\\000000001__20160219154442427594.jpg</mmlPc:planNotes></mmlPc:plan></mmlPc:problemItem><mmlPc:problemItem><mmlPc:plan><mmlPc:txOrder>&lt;Orders&gt;\r\n  &lt;Order&gt;\r\n    &lt;Content&gt;3\351\214\240*3&lt;/Content&gt;\r\n    &lt;GubunBass&gt;0C&lt;/GubunBass&gt;\r\n    &lt;HangmogCode&gt;611130096&lt;/HangmogCode&gt;\r\n    &lt;ActionDoYn&gt;Y&lt;/ActionDoYn&gt;\r\n    &lt;Bunho&gt;000000001&lt;/Bunho&gt;\r\n    &lt;Doctor&gt;0110333&lt;/Doctor&gt;\r\n    &lt;Gwa&gt;01&lt;/Gwa&gt;\r\n    &lt;NaewonDate&gt;2016/02/19&lt;/NaewonDate&gt;\r\n    &lt;NaewonKey&gt;1577&lt;/NaewonKey&gt;\r\n    &lt;InputTab&gt;01&lt;/InputTab&gt;\r\n    &lt;HangmogName&gt;\343\202\242\343\203\254\343\203\223\343\202\242\343\203\201\343\203\263\351\214\240\357\274\221\357\274\220\357\274\220\357\275\215\357\275\207&lt;/HangmogName&gt;\r\n    &lt;InputGubunName&gt;\351\200\232\345\270\270&lt;/InputGubunName&gt;\r\n    &lt;OrderGubunName&gt;\345\206\205\346\234\215\350\226\254&lt;/OrderGubunName&gt;\r\n  &lt;/Order&gt;\r\n  &lt;Order&gt;\r\n    &lt;Content&gt;1\347\256\241*1&lt;/Content&gt;\r\n    &lt;GubunBass&gt;0B&lt;/GubunBass&gt;\r\n    &lt;HangmogCode&gt;641170026&lt;/HangmogCode&gt;\r\n    &lt;ActionDoYn&gt;Y&lt;/ActionDoYn&gt;\r\n    &lt;Bunho&gt;000000001&lt;/Bunho&gt;\r\n    &lt;Doctor&gt;0110333&lt;/Doctor&gt;\r\n    &lt;Gwa&gt;01&lt;/Gwa&gt;\r\n    &lt;NaewonDate&gt;2016/02/19&lt;/NaewonDate&gt;\r\n    &lt;NaewonKey&gt;1577&lt;/NaewonKey&gt;\r\n    &lt;InputTab&gt;03&lt;/InputTab&gt;\r\n    &lt;HangmogName&gt;\343\203\233\343\203\252\343\202\276\343\203\263\346\263\250\345\260\204\346\266\262\357\274\221\357\274\220\357\275\215\357\275\207&lt;/HangmogName&gt;\r\n    &lt;InputGubunName&gt;\351\200\232\345\270\270&lt;/InputGubunName&gt;\r\n    &lt;OrderGubunName&gt;\346\263\250\345\260\204&lt;/OrderGubunName&gt;\r\n  &lt;/Order&gt;\r\n  &lt;Order&gt;\r\n    &lt;Content&gt;1\347\204\241*1&lt;/Content&gt;\r\n    &lt;GubunBass&gt;0F&lt;/GubunBass&gt;\r\n    &lt;HangmogCode&gt;9025700&lt;/HangmogCode&gt;\r\n    &lt;ActionDoYn&gt;Y&lt;/ActionDoYn&gt;\r\n    &lt;Bunho&gt;000000001&lt;/Bunho&gt;\r\n    &lt;Doctor&gt;0110333&lt;/Doctor&gt;\r\n    &lt;Gwa&gt;01&lt;/Gwa&gt;\r\n    &lt;NaewonDate&gt;2016/02/19&lt;/NaewonDate&gt;\r\n    &lt;NaewonKey&gt;1577&lt;/NaewonKey&gt;\r\n    &lt;InputTab&gt;04&lt;/InputTab&gt;\r\n    &lt;HangmogName&gt;CK-MB[\350\241\200\346\270\205]&lt;/HangmogName&gt;\r\n    &lt;InputGubunName&gt;\351\200\232\345\270\270&lt;/InputGubunName&gt;\r\n    &lt;OrderGubunName&gt;\346\244\234\344\275\223\346\244\234\346\237\273&lt;/OrderGubunName&gt;\r\n  &lt;/Order&gt;\r\n  &lt;Order&gt;\r\n    &lt;Content&gt;1\347\204\241*1&lt;/Content&gt;\r\n    &lt;GubunBass&gt;0N&lt;/GubunBass&gt;\r\n    &lt;HangmogCode&gt;D295000005&lt;/HangmogCode&gt;\r\n    &lt;ActionDoYn&gt;Y&lt;/ActionDoYn&gt;\r\n    &lt;Bunho&gt;000000001&lt;/Bunho&gt;\r\n    &lt;Doctor&gt;0110333&lt;/Doctor&gt;\r\n    &lt;Gwa&gt;01&lt;/Gwa&gt;\r\n    &lt;NaewonDate&gt;2016/02/19&lt;/NaewonDate&gt;\r\n    &lt;NaewonKey&gt;1577&lt;/NaewonKey&gt;\r\n    &lt;InputTab&gt;05&lt;/InputTab&gt;\r\n    &lt;HangmogName&gt;\351\226\242\347\257\200\351\217\241\357\274\210\347\211\207\357\274\211&lt;/HangmogName&gt;\r\n    &lt;InputGubunName&gt;\351\200\232\345\270\270&lt;/InputGubunName&gt;\r\n    &lt;OrderGubunName&gt;\347\224\237\347\220\206\346\244\234\346\237\273&lt;/OrderGubunName&gt;\r\n  &lt;/Order&gt;\r\n  &lt;Order&gt;\r\n    &lt;Content&gt;1\345\233\236*1&lt;/Content&gt;\r\n    &lt;GubunBass&gt;0E&lt;/GubunBass&gt;\r\n    &lt;HangmogCode&gt;C00002&lt;/HangmogCode&gt;\r\n    &lt;ActionDoYn&gt;Y&lt;/ActionDoYn&gt;\r\n    &lt;Bunho&gt;000000001&lt;/Bunho&gt;\r\n    &lt;Doctor&gt;0110333&lt;/Doctor&gt;\r\n    &lt;Gwa&gt;01&lt;/Gwa&gt;\r\n    &lt;NaewonDate&gt;2016/02/19&lt;/NaewonDate&gt;\r\n    &lt;NaewonKey&gt;1577&lt;/NaewonKey&gt;\r\n    &lt;InputTab&gt;07&lt;/InputTab&gt;\r\n    &lt;HangmogName&gt;[CT]\351\240\255\351\203\250\357\274\210\351\252\250\346\235\241\344\273\266\357\274\211\343\200\200\343\200\224\345\215\230\347\264\224\343\200\225&lt;/HangmogName&gt;\r\n    &lt;InputGubunName&gt;\351\200\232\345\270\270&lt;/InputGubunName&gt;\r\n    &lt;OrderGubunName&gt;\347\224\273\345\203\217\350\250\272\346\226\255&lt;/OrderGubunName&gt;\r\n  &lt;/Order&gt;\r\n  &lt;Order&gt;\r\n    &lt;Content&gt;1\347\204\241*1&lt;/Content&gt;\r\n    &lt;GubunBass&gt;0H&lt;/GubunBass&gt;\r\n    &lt;HangmogCode&gt;J000000003&lt;/HangmogCode&gt;\r\n    &lt;ActionDoYn&gt;Y&lt;/ActionDoYn&gt;\r\n    &lt;Bunho&gt;000000001&lt;/Bunho&gt;\r\n    &lt;Doctor&gt;0110333&lt;/Doctor&gt;\r\n    &lt;Gwa&gt;01&lt;/Gwa&gt;\r\n    &lt;NaewonDate&gt;2016/02/19&lt;/NaewonDate&gt;\r\n    &lt;NaewonKey&gt;1577&lt;/NaewonKey&gt;\r\n    &lt;InputTab&gt;08&lt;/InputTab&gt;\r\n    &lt;HangmogName&gt;\350\241\223\345\276\214\345\211\265\345\202\267\345\207\246\347\275\256\357\274\210\357\274\225\357\274\220\357\274\220\357\275\203\357\275\215\357\274\222\344\273\245\344\270\212\357\274\223\357\274\220\357\274\220\357\274\220\357\275\203\357\275\215\357\274\222\346\234\252\346\272\200\357\274\211&lt;/HangmogName&gt;\r\n    &lt;InputGubunName&gt;\351\200\232\345\270\270&lt;/InputGubunName&gt;\r\n    &lt;OrderGubunName&gt;\345\207\246\347\275\256&lt;/OrderGubunName&gt;\r\n  &lt;/Order&gt;\r\n  &lt;Order&gt;\r\n    &lt;Content&gt;1\347\204\241*1&lt;/Content&gt;\r\n    &lt;GubunBass&gt;0G&lt;/GubunBass&gt;\r\n    &lt;HangmogCode&gt;K000000007&lt;/HangmogCode&gt;\r\n    &lt;ActionDoYn&gt;Y&lt;/ActionDoYn&gt;\r\n    &lt;Bunho&gt;000000001&lt;/Bunho&gt;\r\n    &lt;Doctor&gt;0110333&lt;/Doctor&gt;\r\n    &lt;Gwa&gt;01&lt;/Gwa&gt;\r\n    &lt;NaewonDate&gt;2016/02/19&lt;/NaewonDate&gt;\r\n    &lt;NaewonKey&gt;1577&lt;/NaewonKey&gt;\r\n    &lt;InputTab&gt;09&lt;/InputTab&gt;\r\n    &lt;HangmogName&gt;\345\211\265\345\202\267\345\207\246\347\220\206\357\274\210\347\255\213\350\202\211\343\200\201\350\207\223\345\231\250\343\201\253\351\201\224\343\201\227\343\201\252\343\201\204\357\274\211\351\225\267\345\276\204\357\274\225\357\275\203\357\275\215\346\234\252\346\272\200&lt;/HangmogName&gt;\r\n    &lt;InputGubunName&gt;\351\200\232\345\270\270&lt;/InputGubunName&gt;\r\n    &lt;OrderGubunName&gt;\346\211\213\350\241\223&lt;/OrderGubunName&gt;\r\n  &lt;/Order&gt;\r\n&lt;/Orders&gt;</mmlPc:txOrder></mmlPc:plan></mmlPc:problemItem></mmlPc:structuredExpression></mmlPc:ProgressCourseModule></content></MmlModuleItem><MmlModuleItem><docInfo contentModuleType=\"patientInfo\"><docId><uid>635932209831286113</uid></docId><title>Patient</title><confirmDate>2016/03/10</confirmDate><securityLevel><accessRight permit=\"all\" /></securityLevel><mmlCi:CreatorInfo><mmlPsi:PersonalizedInfo><mmlCm:Id mmlCm:type=\"facility\" mmlCm:tableId=\"MML0024\">10333</mmlCm:Id><mmlPsi:personName><mmlNm:Name mmlNm:repCode=\"I\" mmlNm:tableId=\"MML0025\" /></mmlPsi:personName><mmlFc:Facility><mmlFc:Id><mmlCm:Id mmlCm:type=\"facility\" mmlCm:tableId=\"MML0024\">333</mmlCm:Id></mmlFc:Id><mmlFc:name mmlFc:repCode=\"I\" mmlFc:tableId=\"MML0025\">01</mmlFc:name></mmlFc:Facility><mmlDp:Department><mmlDp:Id><mmlCm:Id mmlCm:type=\"medical\" mmlCm:tableId=\"MML0029\"></mmlCm:Id></mmlDp:Id><mmlDp:name mmlDp:repCode=\"I\" mmlDp:tableId=\"MML0025\"></mmlDp:name></mmlDp:Department></mmlPsi:PersonalizedInfo></mmlCi:CreatorInfo></docInfo><content><mmlPi:PatientModule xmlns:mmlPi=\"http://www.medxml.net/MML/ContentModule/PatientInfo/1.0\"><mmlPi:uniqueInfo><mmlPi:masterId><mmlCm:Id mmlCm:type=\"\" mmlCm:tableId=\"\">000000001</mmlCm:Id></mmlPi:masterId></mmlPi:uniqueInfo><mmlPi:birthday>1998/05/08</mmlPi:birthday><mmlPi:sex>M</mmlPi:sex><mmlPi:addresses><mmlAd:Address mmlAd:repCode=\"I\" mmlAd:tableId=\"MML0002\" mmlAd:addressClass=\"current\"><mmlAd:prefecture></mmlAd:prefecture><mmlAd:city></mmlAd:city><mmlAd:town></mmlAd:town><mmlAd:homeNumber></mmlAd:homeNumber><mmlAd:zip> - </mmlAd:zip><mmlAd:countryCode>JPN</mmlAd:countryCode></mmlAd:Address></mmlPi:addresses><mmlPi:phones><mmlPh:Phone mmlPh:telEquipType=\"PH\"><mmlPh:area></mmlPh:area><mmlPh:city></mmlPh:city><mmlPh:number></mmlPh:number><mmlPh:country>JPN</mmlPh:country></mmlPh:Phone></mmlPi:phones></mmlPi:PatientModule></content></MmlModuleItem><MmlModuleItem><docInfo contentModuleType=\"progressCourse\"><docId><uid>1983</uid></docId><title>Progress Course</title><confirmDate>2016/03/10</confirmDate><securityLevel><accessRight permit=\"all\" /></securityLevel><mmlCi:CreatorInfo><mmlPsi:PersonalizedInfo><mmlCm:Id mmlCm:type=\"facility\" mmlCm:tableId=\"MML0024\">1</mmlCm:Id><mmlPsi:personName><mmlNm:Name mmlNm:repCode=\"I\" mmlNm:tableId=\"MML0025\" /></mmlPsi:personName><mmlFc:Facility><mmlFc:Id><mmlCm:Id mmlCm:type=\"facility\" mmlCm:tableId=\"MML0024\">333</mmlCm:Id></mmlFc:Id><mmlFc:name mmlFc:repCode=\"I\" mmlFc:tableId=\"MML0025\">01</mmlFc:name></mmlFc:Facility><mmlDp:Department><mmlDp:Id><mmlCm:Id mmlCm:type=\"medical\" mmlCm:tableId=\"MML0029\"></mmlCm:Id></mmlDp:Id><mmlDp:name mmlDp:repCode=\"I\" mmlDp:tableId=\"MML0025\"></mmlDp:name></mmlDp:Department></mmlPsi:PersonalizedInfo></mmlCi:CreatorInfo></docInfo><content><mmlPc:ProgressCourseModule xmlns:mmlPc=\"http://www.medxml.net/MML/ContentModule/ProgressCourse/1.0\"><mmlPc:structuredExpression><mmlPc:problemItem><mmlPc:assessment><mmlPc:assessmentItem>#A# \347\263\226\345\260\277\347\227\205\343\201\256\345\217\243\346\270\207\345\244\232\351\243\262\343\201\257\350\252\215\343\202\201\343\201\246\343\201\204\343\201\252\343\201\204\343\200\202\r\n\351\243\237\344\272\213\347\231\202\346\263\225\343\202\222\350\241\214\343\201\243\343\201\246\343\201\204\343\202\213\343\201\214\343\200\201\350\241\200\347\263\226\345\200\244\343\201\256\343\202\263\343\203\263\343\203\210\343\203\255\343\203\274\343\203\253\343\201\253\351\226\242\343\201\227\343\201\246\343\201\257\346\224\271\345\226\204\343\201\214\346\261\202\343\202\201\343\202\211\343\202\214\343\202\213\343\200\202\r\n\351\201\213\345\213\225\347\231\202\346\263\225\343\201\250\343\201\256\344\275\265\347\224\250\343\202\222\346\244\234\350\250\216\343\201\231\343\202\213\343\200\202\r\n\347\233\256\346\250\231\343\201\2576%\345\211\215\345\215\212\343\201\247\343\201\202\343\202\212\343\200\201\346\234\254\346\227\245\343\202\210\343\202\212\347\265\214\345\217\243\347\263\226\345\260\277\347\227\205\350\226\254\343\201\256\346\212\225\344\270\216\343\202\222\351\226\213\345\247\213\343\201\227\343\201\237\343\200\202</mmlPc:assessmentItem></mmlPc:assessment><mmlPc:problem mmlPc:dxUid=\"3e0348d5-3f96-44a0-9dfb-a98e6cbb9d5e\"></mmlPc:problem></mmlPc:problemItem><mmlPc:problemItem><mmlPc:assessment><mmlPc:assessmentItem>#MA# \347\263\226\345\260\277\347\227\205</mmlPc:assessmentItem></mmlPc:assessment><mmlPc:problem mmlPc:dxUid=\"6978323a-a48b-44ae-8bdc-5c3b9f7959a8\"></mmlPc:problem></mmlPc:problemItem><mmlPc:problemItem><mmlPc:problem mmlPc:dxUid=\"738768ef-c3ca-4011-a1af-f26e80e285cf\"></mmlPc:problem><mmlPc:objective><mmlPc:objectiveNotes>#O# \347\251\272\350\205\271\346\231\202\350\241\200\347\263\226\345\200\244153\343\200\200HbA1c 6.6%</mmlPc:objectiveNotes></mmlPc:objective></mmlPc:problemItem><mmlPc:problemItem><mmlPc:problem mmlPc:dxUid=\"cb1c079f-c9e3-40de-99b2-209e6a25a218\"></mmlPc:problem><mmlPc:plan><mmlPc:planNotes>#P# SU\345\211\244\351\226\213\345\247\213\343\200\200\346\254\241\345\233\236\345\244\226\346\235\245\343\201\247\345\212\271\346\236\234\345\210\244\345\256\232\343\200\202\r\n\351\225\267\346\234\237\346\227\205\350\241\214\343\201\253\345\207\272\343\202\213\343\201\250\343\201\256\343\201\223\343\201\250\343\201\252\343\201\256\343\201\247\343\200\201\346\254\241\345\233\236\346\235\245\351\231\242\343\201\276\343\201\247\343\201\253\345\256\271\344\275\223\343\201\214\346\202\252\345\214\226\343\201\227\343\201\237\345\240\264\345\220\210\343\201\257\r\n\346\227\205\350\241\214\345\205\210\343\201\256\345\214\273\351\231\242\343\201\247\346\244\234\346\237\273\343\202\222\345\217\227\343\201\221\343\202\213\343\201\223\343\201\250\343\202\222\344\274\235\343\201\210\343\201\237\343\200\202</mmlPc:planNotes></mmlPc:plan></mmlPc:problemItem><mmlPc:problemItem><mmlPc:problem mmlPc:dxUid=\"33f9f1c5-8b68-41d3-bf75-adaeb6b99ec0\"></mmlPc:problem><mmlPc:subjective><mmlPc:subjectiveItem><mmlPc:timeExpression>2016/03/10</mmlPc:timeExpression><mmlPc:eventExpression>#S# \345\217\243\343\201\214\346\270\207\343\201\215\351\240\273\347\271\201\343\201\253\346\260\264\343\202\222\351\243\262\343\202\200\343\201\223\343\201\250\343\201\214\345\242\227\343\201\210\343\201\237\343\200\202</mmlPc:eventExpression></mmlPc:subjectiveItem></mmlPc:subjective></mmlPc:problemItem></mmlPc:structuredExpression></mmlPc:ProgressCourseModule></content></MmlModuleItem><MmlModuleItem><docInfo contentModuleType=\"patientInfo\"><docId><uid>635932209831286113</uid></docId><title>Patient</title><confirmDate>2016/03/10</confirmDate><securityLevel><accessRight permit=\"all\" /></securityLevel><mmlCi:CreatorInfo><mmlPsi:PersonalizedInfo><mmlCm:Id mmlCm:type=\"facility\" mmlCm:tableId=\"MML0024\">1</mmlCm:Id><mmlPsi:personName><mmlNm:Name mmlNm:repCode=\"I\" mmlNm:tableId=\"MML0025\" /></mmlPsi:personName><mmlFc:Facility><mmlFc:Id><mmlCm:Id mmlCm:type=\"facility\" mmlCm:tableId=\"MML0024\">333</mmlCm:Id></mmlFc:Id><mmlFc:name mmlFc:repCode=\"I\" mmlFc:tableId=\"MML0025\">01</mmlFc:name></mmlFc:Facility><mmlDp:Department><mmlDp:Id><mmlCm:Id mmlCm:type=\"medical\" mmlCm:tableId=\"MML0029\"></mmlCm:Id></mmlDp:Id><mmlDp:name mmlDp:repCode=\"I\" mmlDp:tableId=\"MML0025\"></mmlDp:name></mmlDp:Department></mmlPsi:PersonalizedInfo></mmlCi:CreatorInfo></docInfo><content><mmlPi:PatientModule xmlns:mmlPi=\"http://www.medxml.net/MML/ContentModule/PatientInfo/1.0\"><mmlPi:uniqueInfo><mmlPi:masterId><mmlCm:Id mmlCm:type=\"\" mmlCm:tableId=\"\">000000001</mmlCm:Id></mmlPi:masterId></mmlPi:uniqueInfo><mmlPi:birthday>1998/05/08</mmlPi:birthday><mmlPi:sex>M</mmlPi:sex><mmlPi:addresses><mmlAd:Address mmlAd:repCode=\"I\" mmlAd:tableId=\"MML0002\" mmlAd:addressClass=\"current\"><mmlAd:prefecture></mmlAd:prefecture><mmlAd:city></mmlAd:city><mmlAd:town></mmlAd:town><mmlAd:homeNumber></mmlAd:homeNumber><mmlAd:zip> - </mmlAd:zip><mmlAd:countryCode>JPN</mmlAd:countryCode></mmlAd:Address></mmlPi:addresses><mmlPi:phones><mmlPh:Phone mmlPh:telEquipType=\"PH\"><mmlPh:area></mmlPh:area><mmlPh:city></mmlPh:city><mmlPh:number></mmlPh:number><mmlPh:country>JPN</mmlPh:country></mmlPh:Phone></mmlPi:phones></mmlPi:PatientModule></content></MmlModuleItem></MmlBody></Mml>")
				.setSysId("1")
				.setRecordLog("\346\226\260\350\246\217\344\275\234\346\210\220")
				.build();    
		sentRequestToMedApp(request, EmrServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));

	}
}