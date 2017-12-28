package nta.med.service.integration.cpls;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.CplsServiceProto;

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
public class CplsCPL2010U00GrdSpecimenCPL2010RequestTest {
	@Autowired
	protected Vertx vertx;

	@Test
	public void cplsCPL2010U00GrdSpecimenCPL2010RequestTest() throws InterruptedException {
		CplsServiceProto.CPL2010U00GrdSpecimenRequest request = CplsServiceProto.CPL2010U00GrdSpecimenRequest
				.newBuilder()
				.setMJubsuYn("1")
				.setBunho("fadsf")
				.setOrderDate("1990/01/01")
				.setGroupSer("10")
				.setGwa("hg")
				.setOrderTime("1900")
				.setDoctor("15454")
				.setJubsuDate("1989/01/02")
				//.setJubsuTime("1800")
				.setJubsuja("fsadf")
				.setReserYn("N")
				.setReserDate("1897/01/02")
				.setEmergencyYn("Y")
				.build();
		Rpc.RpcMessage rpcMessage = Rpc.RpcMessage
				.newBuilder()
				.setId(System.currentTimeMillis())
				.setService("patientInsurance")
				.setVersion("1.0.0")
				.setPayloadClass(
						CplsServiceProto.CPL2010U00GrdSpecimenRequest.class
								.getSimpleName())
				.setPayloadData(request.toByteString()).build();
		final CountDownLatch latch = new CountDownLatch(1);
		vertx.eventBus()
				.send(CplsServiceProto.CPL2010U00GrdSpecimenRequest.class
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

