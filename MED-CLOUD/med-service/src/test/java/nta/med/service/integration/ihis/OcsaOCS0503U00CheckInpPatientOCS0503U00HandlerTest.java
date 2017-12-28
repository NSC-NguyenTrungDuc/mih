package nta.med.service.integration.ihis;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsaServiceProto;

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
public class OcsaOCS0503U00CheckInpPatientOCS0503U00HandlerTest {
	@Autowired
	protected Vertx vertx;
	
	@Test
	public void testCheckInPatientOCS0503U00 () throws Exception{
		OcsaServiceProto.OCS0503U00CheckInpPatientRequest request= OcsaServiceProto.OCS0503U00CheckInpPatientRequest.newBuilder().setBunho("000041461").build();
		Rpc.RpcMessage rpcMessage=Rpc.RpcMessage.newBuilder()
				.setId(System.currentTimeMillis())
				.setService("PatientInsurance")
				.setVersion("1.0.0")
				.setPayloadClass(OcsaServiceProto.OCS0503U00CheckInpPatientRequest.class.getSimpleName())
				.setPayloadData(request.toByteString()).build();
		final CountDownLatch latch= new CountDownLatch(1);
		vertx.eventBus().send(OcsaServiceProto.OCS0503U00CheckInpPatientRequest.class.getSimpleName(), rpcMessage.toByteArray(),new Handler<Message<byte[]>>() {
			@Override
			public void handle(Message<byte[]> event) {
				System.out.println("Success!");
				latch.countDown();
				
			}
		});
		latch.await(100,TimeUnit.SECONDS);
	}
}
