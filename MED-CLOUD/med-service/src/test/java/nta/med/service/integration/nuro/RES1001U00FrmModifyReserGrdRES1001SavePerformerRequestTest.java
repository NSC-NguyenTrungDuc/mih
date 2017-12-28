package nta.med.service.integration.nuro;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroServiceProto;

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
public class RES1001U00FrmModifyReserGrdRES1001SavePerformerRequestTest {
	@Autowired
	protected Vertx vertx;
	@Test
	public void nUR1001R98LayReserInfoQueryEndRequestTest() throws InterruptedException {
		
		NuroServiceProto.RES1001U00FrmModifyReserGrdRES1001SavePerformerRequest request = NuroServiceProto.RES1001U00FrmModifyReserGrdRES1001SavePerformerRequest
				.newBuilder()
				.setQUserId("test")
				.setBunho("")
				.setGwa("")
				.setGubun("")
				.setJinryoPreDate("")
				.setJinryoPreTime("")
				.setDoctor("")
				.setInputGubun("")
				.setPkres1001("")
				.setPkout1001("")
				.setChanggu("")
				.setChojae("")
				.setJubsuNo("")
				.setResGubun("")
				.setRowstate("")
				.setNewrow("")
				.build();
		
		Rpc.RpcMessage rpcMessage = Rpc.RpcMessage
				.newBuilder()
				.setId(System.currentTimeMillis())
				.setService("patientInsurance")
				.setVersion("1.0.0")
				.setPayloadClass(
						NuroServiceProto.RES1001U00FrmModifyReserGrdRES1001SavePerformerRequest.class
								.getSimpleName())
				.setPayloadData(request.toByteString()).build();
		final CountDownLatch latch = new CountDownLatch(1);
		vertx.eventBus()
				.send(NuroServiceProto.RES1001U00FrmModifyReserGrdRES1001SavePerformerRequest.class
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

