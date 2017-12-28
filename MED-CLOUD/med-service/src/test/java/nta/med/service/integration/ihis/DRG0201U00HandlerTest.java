package nta.med.service.integration.ihis;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;

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
public class DRG0201U00HandlerTest {

	@Autowired
	protected Vertx vertx;
    
	@Ignore
    @Test
    public void testDRG0140U00ChangeRequest() throws Exception {
        DrgsServiceProto.DRG0201U00CboGridRequest request = DrgsServiceProto.DRG0201U00CboGridRequest.newBuilder()
              .build();
        
        // 000002327 ; 2013/08/15

        Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
                .setId(System.currentTimeMillis())
                .setService("PatientInsurance")
                .setVersion("1.0.0")
                .setPayloadClass(DrgsServiceProto.DRG0201U00CboGridRequest.class.getSimpleName())
                .setPayloadData(request.toByteString())
                .build();

        final CountDownLatch latch = new CountDownLatch(1);

        vertx.eventBus().send(DrgsServiceProto.DRG0201U00CboGridRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
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
    public void testDRG0201U00GrdPaidRequest() throws Exception {
    	DrgsServiceProto.DRG0201U00GrdPaidRequest request = DrgsServiceProto.DRG0201U00GrdPaidRequest.newBuilder()
    			.setBunho("000038796")
    			.setGubun("3")
    			.build();
    	
    	// 000002327 ; 2013/08/15
    	
    	Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
    			.setId(System.currentTimeMillis())
    			.setService("PatientInsurance")
    			.setVersion("1.0.0")
    			.setPayloadClass(DrgsServiceProto.DRG0201U00GrdPaidRequest.class.getSimpleName())
    			.setPayloadData(request.toByteString())
    			.build();
    	
    	final CountDownLatch latch = new CountDownLatch(1);
    	
    	vertx.eventBus().send(DrgsServiceProto.DRG0201U00GrdPaidRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
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
    public void testDRG0201U00DetailServerCallRequest() throws Exception {
    	DrgsServiceProto.DRG0201U00DetailServerCallRequest request = DrgsServiceProto.DRG0201U00DetailServerCallRequest.newBuilder()
    			.setBunho("000005329")
    			.setDrgBunho("N")
    			.setJubsuDate("2014/08/16")
    			.build();
    	
    	// 000002327 ; 2013/08/15
    	
    	Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
    			.setId(System.currentTimeMillis())
    			.setService("PatientInsurance")
    			.setVersion("1.0.0")
    			.setPayloadClass(DrgsServiceProto.DRG0201U00GrdPaidRequest.class.getSimpleName())
    			.setPayloadData(request.toByteString())
    			.build();
    	
    	final CountDownLatch latch = new CountDownLatch(1);
    	
    	vertx.eventBus().send(DrgsServiceProto.DRG0201U00DetailServerCallRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
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
	public void testDRG0201U00ValidatePrintAdmMediRequest() throws Exception {
		DrgsServiceProto.DRG0201U00ValidatePrintAdmMediRequest request = DrgsServiceProto.DRG0201U00ValidatePrintAdmMediRequest.newBuilder()
				.setBunho("000038796")
				.setDrgBunho("4")
				.setJubsuDate("2013/01/31")
				.build();
		
		// 000002327 ; 2013/08/15
		
		Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
				.setId(System.currentTimeMillis())
				.setService("PatientInsurance")
				.setVersion("1.0.0")
				.setPayloadClass(DrgsServiceProto.DRG0201U00ValidatePrintAdmMediRequest.class.getSimpleName())
				.setPayloadData(request.toByteString())
				.build();
		
		final CountDownLatch latch = new CountDownLatch(1);
		
		vertx.eventBus().send(DrgsServiceProto.DRG0201U00ValidatePrintAdmMediRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
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
	public void testDRG0201U00ActChkRequest() throws Exception {
		DrgsServiceProto.DRG0201U00ActChkRequest request = DrgsServiceProto.DRG0201U00ActChkRequest.newBuilder()
				.setOrderDate("2011/04/07")
				.setDrgBunho("1001")
				.build();
		
		// 000002327 ; 2013/08/15
		
		Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
				.setId(System.currentTimeMillis())
				.setService("PatientInsurance")
				.setVersion("1.0.0")
				.setPayloadClass(DrgsServiceProto.DRG0201U00ActChkRequest.class.getSimpleName())
				.setPayloadData(request.toByteString())
				.build();
		
		final CountDownLatch latch = new CountDownLatch(1);
		
		vertx.eventBus().send(DrgsServiceProto.DRG0201U00ActChkRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
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
	public void testDRG0201U00ProcAtcInterfaceRequest() throws Exception {
		DrgsServiceProto.DRG0201U00ProcAtcInterfaceRequest request = DrgsServiceProto.DRG0201U00ProcAtcInterfaceRequest.newBuilder()
				.setGubun("D")
//				.setGubun("I")
				.setJubsuDate("2014/11/10")
				.setDrgBunho("2")
				.setIInOutGubun("O")
				.setBunho("888888888")
				.setIDataDubun("0")
				.setIFk("270190")
				.setUserId("123456")
				.build();
		
		// 000002327 ; 2013/08/15
		
		Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
				.setId(System.currentTimeMillis())
				.setService("PatientInsurance")
				.setVersion("1.0.0")
				.setPayloadClass(DrgsServiceProto.DRG0201U00ProcAtcInterfaceRequest.class.getSimpleName())
				.setPayloadData(request.toByteString())
				.build();
		
		final CountDownLatch latch = new CountDownLatch(1);
		
		vertx.eventBus().send(DrgsServiceProto.DRG0201U00ProcAtcInterfaceRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
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
	public void testDRG0201U00GetPatientIdRequest() throws Exception {
		DrgsServiceProto.DRG0201U00GetPatientIdRequest request = DrgsServiceProto.DRG0201U00GetPatientIdRequest.newBuilder()
				.setJubsuDate("2014/11/10")
				.setDrgBunho("2")
				.build();
		
		// 000002327 ; 2013/08/15
		
		Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
				.setId(System.currentTimeMillis())
				.setService("PatientInsurance")
				.setVersion("1.0.0")
				.setPayloadClass(DrgsServiceProto.DRG0201U00GetPatientIdRequest.class.getSimpleName())
				.setPayloadData(request.toByteString())
				.build();
		
		final CountDownLatch latch = new CountDownLatch(1);
		
		vertx.eventBus().send(DrgsServiceProto.DRG0201U00GetPatientIdRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
			@Override
			public void handle(Message<byte[]> event) {
				System.out.println("Success!");
				latch.countDown();
			}
		});
		latch.await(100, TimeUnit.SECONDS);
	}
	
	@Test
	public void testDRG0201U00PrDrgUpdateChulgoRequest() throws Exception {
		DrgsServiceProto.DRG0201U00PrDrgUpdateChulgoRequest request = DrgsServiceProto.DRG0201U00PrDrgUpdateChulgoRequest.newBuilder()
				.setJubsuDate("2014/11/10")
				.setDrgBunho("1003")
				.setChulgoDate("2015/02/15")
				.setActUser("test")
				.setChulgoBuseo("test")
				.setWonyoiOrderYn("N")
				.setActYn("N")
				.build();
		
		// 000002327 ; 2013/08/15
		
		Rpc.RpcMessage rpcMessage = Rpc.RpcMessage.newBuilder()
				.setId(System.currentTimeMillis())
				.setService("PatientInsurance")
				.setVersion("1.0.0")
				.setPayloadClass(DrgsServiceProto.DRG0201U00PrDrgUpdateChulgoRequest.class.getSimpleName())
				.setPayloadData(request.toByteString())
				.build();
		
		final CountDownLatch latch = new CountDownLatch(1);
		
		vertx.eventBus().send(DrgsServiceProto.DRG0201U00PrDrgUpdateChulgoRequest.class.getSimpleName(), rpcMessage.toByteArray(), new Handler<Message<byte[]>>() {
			@Override
			public void handle(Message<byte[]> event) {
				System.out.println("Success!");
				latch.countDown();
			}
		});
		latch.await(100, TimeUnit.SECONDS);
	}
}
