package nta.med.service.integration.ihis;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import org.vertx.java.core.Handler;
import org.vertx.java.core.Vertx;
import org.vertx.java.core.eventbus.Message;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(locations = {"classpath:META-INF/spring/spring-master.xml"})
public class M2HTest {
	@Autowired
    protected Vertx vertx;

    @Test
    public void testHandleMessage() throws Exception {
       
//    	OcsoServiceProto.OcsoOCS1003Q05DiseaseListRequest request = OcsoServiceProto.OcsoOCS1003Q05DiseaseListRequest.newBuilder()
//    			.setHospCode("K01")
//    			.setIoGubun("O")    
//    			.setGwa("01")     
//    			.setBunho("099990001")   
//    			.setFkinp1001("")
//    			.setSangCode("2500014")
//    			.setSangName("１型糖尿病")
//    			.setPostModifierName("NL")
//    			.setPreModifierName("NL")
//    			.setSangStartDate("2013/1/11")  
//    			.setSangEndDate("")  
//    			.setSangJindanDate("2013/1/11")
//    			.setDataGubun("")
//    			.setJuSangYn("N")    			
//        		.build();  
    	
//    	OcsoServiceProto.OcsoOCS1003Q05OrderListRequest request = OcsoServiceProto.OcsoOCS1003Q05OrderListRequest.newBuilder()
//    			.setGenericYn("N")
//    			.setPkOrder("316996")
//    			.setInputTab("01")
//    			.setInputGubun("D0")
//    			.setTelYn("N")
//    			.setBunho("000026870")
//    			.setJubsuNo("1606165")
//    			.setKijun("H")
//    			.setNaewonDate("2012/04/06")
//    			.setGwa("01")
//    			.setDoctor("0110099")
//        		.build();
    	
//    	OcsoServiceProto.OcsoOCS1003Q05DiseaseListRequest request = OcsoServiceProto.OcsoOCS1003Q05DiseaseListRequest.newBuilder()
//    			.setJubsuNo("1606165")
//    			.setNaewonDate("2013/3/30")
//    			.setNaewonType("222")
//    			.setBunho("000026870")
//    			.setGwa("01")
//    			.setDoctor("1606165")
//    			.setIoGubun("O")
//        		.build();       	
    	
//    	SchsModelProto.SCH3001U00XSavePerformerCase7Info.Builder info = SchsModelProto.SCH3001U00XSavePerformerCase7Info.newBuilder();
//    	info.setUserId("M2H");  
//    	info.setJundalTable("M2H");
    	
//    	info.setJundalPart("A");
//    	info.setStartTime("0900");
//    	info.setEndTime("1800");
//    	info.setInwon("2");
//    	info.setAddInwon("1");
//      
//    	CommonModelProto.DataStringListItemInfo.Builder yoil1 = CommonModelProto.DataStringListItemInfo.newBuilder();
//    	yoil1.setDataValue("2");
//    	CommonModelProto.DataStringListItemInfo.Builder yoil2 = CommonModelProto.DataStringListItemInfo.newBuilder();
//    	yoil2.setDataValue("3");
    	
//    	EmrModelProto.OCS2015U09EmrBookmarkInfo.Builder builder1 = EmrModelProto.OCS2015U09EmrBookmarkInfo.newBuilder();
//    	builder1.setBookmarkText("kjsdhfkjdsflhkj").setNaewonDate("20150608").setPkout1001("329645");
//    	EmrModelProto.OCS2015U09EmrBookmarkInfo.Builder builder2 = EmrModelProto.OCS2015U09EmrBookmarkInfo.newBuilder();
//    	builder2.setBookmarkText("kjsdfhlkjsdfj").setNaewonDate("20150608").setPkout1001("329645");
    	SystemServiceProto.AdmMessageCallRequest request = SystemServiceProto.AdmMessageCallRequest.newBuilder()
    			.build();
    	
        Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
                .setId(System.currentTimeMillis())
                .setService("DRG9040U01GrdOrderListOutRequest")
                .setVersion("1.0.0")
                .setPayloadClass(SystemServiceProto.AdmMessageCallRequest.class.getSimpleName())
                .setPayloadData(request.toByteString())
                .build();

        final CountDownLatch latch = new CountDownLatch(1);
//        final byte[] idBytes = new byte[36];
//        System.out.print("idBytes lenght: " + idBytes.length);
//        byte[] dataBytes = rpcMessage.toByteArray();
//        byte[] sendBytes = new byte[dataBytes.length + idBytes.length];
//        System.arraycopy(dataBytes, 0, sendBytes, 0, dataBytes.length);
//        System.arraycopy(idBytes, 0, sendBytes, dataBytes.length, idBytes.length);
        
        vertx.eventBus().send(SystemServiceProto.AdmMessageCallRequest.class.getSimpleName(),  rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
            @Override
            public void handle(Message<byte[]> event) {
                System.out.println("Success!");
                latch.countDown();
            }
        });
        latch.await(10, TimeUnit.SECONDS);
    }
}
