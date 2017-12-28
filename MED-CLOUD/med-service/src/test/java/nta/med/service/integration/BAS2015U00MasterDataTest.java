//package nta.med.service.integration;
//
//import java.io.ByteArrayOutputStream;
//import java.io.File;
//import java.io.FileInputStream;
//import java.io.IOException;
//
//import nta.med.common.remoting.rpc.protobuf.Rpc;
//import nta.med.service.ihis.proto.BassServiceProto;
//import nta.med.service.ihis.proto.CommonModelProto;
//
//import org.junit.Test;
//
//import com.google.protobuf.ByteString;
//
//public class BAS2015U00MasterDataTest extends MessageRequestTest {
//    @Test
//    public void test() throws InterruptedException {
////    	String data = "60334, 1, 2.0, 383, うっ血性心不全のある患者, 疾病（現況）";
////    	byte[] bytesType = data.getBytes();
//    	
//    	byte bytes[] = null;
//    	try (FileInputStream fis = new FileInputStream(new File("D:\\cache\\Drug_Interaction.zip"))) {
//    	    try (ByteArrayOutputStream baos = new ByteArrayOutputStream()) {
//    	        byte[] buffer = new byte[1024];
//    	        int read = -1;
//    	        while ((read = fis.read(buffer)) != -1) {
//    	            baos.write(buffer, 0, read);
//    	        }
//    	        bytes = baos.toByteArray();
//    	    } 
//    	} catch (IOException exp) {
//    	    exp.printStackTrace();
//    	}
//    	
//		 ByteString data = ByteString.copyFrom(bytes);
//    	CommonModelProto.KinkiType enumType = CommonModelProto.KinkiType.INTERATION;
//    	
//    	BassServiceProto.BAS2015U00MasterDataRequest request = BassServiceProto.BAS2015U00MasterDataRequest
//                .newBuilder()
//                .setKinkiType(enumType)
//                .setData(data)
//                .build();
//        sentRequestToMedApp(request, BassServiceProto.getDescriptor().
//                getOptions().getExtension(Rpc.service));
//    }
//}
