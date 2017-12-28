package nta.med.service.integration.cpls;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import org.vertx.java.core.Handler;
import org.vertx.java.core.Vertx;
import org.vertx.java.core.eventbus.Message;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(locations = { "classpath:META-INF/spring/spring-master.xml" })
public class CPL3010U01IsWriteFileSelectCodeValueRequestTest {
	@Autowired
	protected Vertx vertx;

	@Test
	public void cPL3010U01IsWriteFileSelectCodeValueRequestTest() throws InterruptedException {
//		CplsServiceProto.CPL3010U01IsWriteFileSelectCodeValueRequest request = CplsServiceProto.CPL3010U01IsWriteFileSelectCodeValueRequest
//				.newBuilder()
//				.build();
//		
//		Rpc.RpcMessage rpcMessage = Rpc.RpcMessage
//				.newBuilder()
//				.setId(System.currentTimeMillis())
//				.setService("patientInsurance")
//				.setVersion("1.0.0")
//				.setPayloadClass(
//						CplsServiceProto.CPL3010U01IsWriteFileSelectCodeValueRequest.class
//								.getSimpleName())
//				.setPayloadData(request.toByteString()).build();
//		final CountDownLatch latch = new CountDownLatch(1);
//		vertx.eventBus()
//				.send(CplsServiceProto.CPL3010U01IsWriteFileSelectCodeValueRequest.class
//						.getSimpleName(),
//						rpcMessage.toByteArray(),
//						new Handler<Message<byte[]>>() {
//							@Override
//							public void handle(Message<byte[]> event) {
//								System.out.println("Success!");
//								latch.countDown();
//							}
//						});
//		latch.await(100, TimeUnit.SECONDS);
		OcsoServiceProto.OCS1003R00FormLoadRequest  request = OcsoServiceProto.OCS1003R00FormLoadRequest
				.newBuilder()
				.setBunho("011223456")
				.setJubsuNo("0")
				.setNaewonDate("1990/01/01")
				.build();
		
		Rpc.RpcMessage rpcMessage = Rpc.RpcMessage
				.newBuilder()
				.setId(System.currentTimeMillis())
				.setService("patientInsurance")
				.setVersion("1.0.0")
				.setPayloadClass(
						OcsoServiceProto.OCS1003R00FormLoadRequest.class
								.getSimpleName())
				.setPayloadData(request.toByteString()).build();
		final CountDownLatch latch = new CountDownLatch(1);
		vertx.eventBus()
				.send(OcsoServiceProto.OCS1003R00FormLoadRequest.class
						.getSimpleName(),
						rpcMessage.toByteArray(),
						new Handler<Message<byte[]>>() {
							@Override
							public void handle(Message<byte[]> event) {
								System.out.println("Success!");
								latch.countDown();
							}
						});
		latch.await(100, TimeUnit.SECONDS);
	}
}

