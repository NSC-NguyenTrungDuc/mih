package nta.med.service.integration.ihis;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.BassServiceProto;

import org.junit.Ignore;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import org.vertx.java.core.Handler;
import org.vertx.java.core.Vertx;
import org.vertx.java.core.eventbus.Message;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(locations={"classpath:META-INF/spring/spring-master.xml"})
public class BAS0270U00HandlerTest {

	@Autowired
	protected Vertx vertx;
    
//	@Ignore
    /*@Test
    public void testBAS0270U00InitializeRequest() throws Exception {
        BassServiceProto.BAS0270U00InitializeRequest request = BassServiceProto.BAS0270U00InitializeRequest.newBuilder()
        		.setBuseoYmd("2015/03/10")
        		.build();
        
        // 000002327 ; 2013/08/15

        Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
                .setId(System.currentTimeMillis())
                .setService("PatientInsurance")
                .setVersion("1.0.0")
                .setPayloadClass(BassServiceProto.BAS0270U00InitializeRequest.class.getSimpleName())
                .setPayloadData(request.toByteString())
                .build();

        final CountDownLatch latch = new CountDownLatch(1);

        vertx.eventBus().send(BassServiceProto.BAS0270U00InitializeRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
            @Override
            public void handle(Message<byte[]> event) {
                System.out.println("Success!");
                latch.countDown();
            }
        });
        latch.await(100, TimeUnit.SECONDS);
    }*/
    
    @Ignore
    @Test
    public void testBAS0270U00GrdBAS0272Request() throws Exception {
        BassServiceProto.BAS0270U00GrdBAS0272Request request = BassServiceProto.BAS0270U00GrdBAS0272Request.newBuilder()
              .build();
        
        // 000002327 ; 2013/08/15

        Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
                .setId(System.currentTimeMillis())
                .setService("PatientInsurance")
                .setVersion("1.0.0")
                .setPayloadClass(BassServiceProto.BAS0270U00GrdBAS0272Request.class.getSimpleName())
                .setPayloadData(request.toByteString())
                .build();

        final CountDownLatch latch = new CountDownLatch(1);

        vertx.eventBus().send(BassServiceProto.BAS0270U00GrdBAS0272Request.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
            @Override
            public void handle(Message<byte[]> event) {
                System.out.println("Success!");
                latch.countDown();
            }
        });
        latch.await(100, TimeUnit.SECONDS);
    }
    
    @Ignore
    @Test
    public void testBAS0270U00LayDoctorNameRequest() throws Exception {
    	BassServiceProto.BAS0270U00LayDoctorNameRequest request = BassServiceProto.BAS0270U00LayDoctorNameRequest.newBuilder()
    			.build();
    	
    	// 000002327 ; 2013/08/15
    	
    	Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
    			.setId(System.currentTimeMillis())
    			.setService("PatientInsurance")
    			.setVersion("1.0.0")
    			.setPayloadClass(BassServiceProto.BAS0270U00LayDoctorNameRequest.class.getSimpleName())
    			.setPayloadData(request.toByteString())
    			.build();
    	
    	final CountDownLatch latch = new CountDownLatch(1);
    	
    	vertx.eventBus().send(BassServiceProto.BAS0270U00LayDoctorNameRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
    		@Override
    		public void handle(Message<byte[]> event) {
    			System.out.println("Success!");
    			latch.countDown();
    		}
    	});
    	latch.await(100, TimeUnit.SECONDS);
    }
    
    @Ignore
    @Test
    public void testBAS0270U00LayDoctorGradeRequest() throws Exception {
    	BassServiceProto.BAS0270U00LayDoctorGradeRequest request = BassServiceProto.BAS0270U00LayDoctorGradeRequest.newBuilder()
    			.build();
    	
    	// 000002327 ; 2013/08/15
    	
    	Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
    			.setId(System.currentTimeMillis())
    			.setService("PatientInsurance")
    			.setVersion("1.0.0")
    			.setPayloadClass(BassServiceProto.BAS0270U00LayDoctorGradeRequest.class.getSimpleName())
    			.setPayloadData(request.toByteString())
    			.build();
    	
    	final CountDownLatch latch = new CountDownLatch(1);
    	
    	vertx.eventBus().send(BassServiceProto.BAS0270U00LayDoctorGradeRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
    		@Override
    		public void handle(Message<byte[]> event) {
    			System.out.println("Success!");
    			latch.countDown();
    		}
    	});
    	latch.await(100, TimeUnit.SECONDS);
    }
    
    @Ignore
    @Test
    public void testBAS0270U00LayGwaRequest() throws Exception {
    	BassServiceProto.BAS0270U00LayGwaRequest request = BassServiceProto.BAS0270U00LayGwaRequest.newBuilder()
    			.build();
    	
    	// 000002327 ; 2013/08/15
    	
    	Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
    			.setId(System.currentTimeMillis())
    			.setService("PatientInsurance")
    			.setVersion("1.0.0")
    			.setPayloadClass(BassServiceProto.BAS0270U00LayGwaRequest.class.getSimpleName())
    			.setPayloadData(request.toByteString())
    			.build();
    	
    	final CountDownLatch latch = new CountDownLatch(1);
    	
    	vertx.eventBus().send(BassServiceProto.BAS0270U00LayGwaRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
    		@Override
    		public void handle(Message<byte[]> event) {
    			System.out.println("Success!");
    			latch.countDown();
    		}
    	});
    	latch.await(100, TimeUnit.SECONDS);
    }
    
    @Ignore
    @Test
    public void testBAS0270U00LayDupCheckRequest() throws Exception {
    	BassServiceProto.BAS0270U00LayDupCheckRequest request = BassServiceProto.BAS0270U00LayDupCheckRequest.newBuilder()
    			.build();
    	
    	// 000002327 ; 2013/08/15
    	
    	Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
    			.setId(System.currentTimeMillis())
    			.setService("PatientInsurance")
    			.setVersion("1.0.0")
    			.setPayloadClass(BassServiceProto.BAS0270U00LayDupCheckRequest.class.getSimpleName())
    			.setPayloadData(request.toByteString())
    			.build();
    	
    	final CountDownLatch latch = new CountDownLatch(1);
    	
    	vertx.eventBus().send(BassServiceProto.BAS0270U00LayDupCheckRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
    		@Override
    		public void handle(Message<byte[]> event) {
    			System.out.println("Success!");
    			latch.countDown();
    		}
    	});
    	latch.await(100, TimeUnit.SECONDS);
    }
}
