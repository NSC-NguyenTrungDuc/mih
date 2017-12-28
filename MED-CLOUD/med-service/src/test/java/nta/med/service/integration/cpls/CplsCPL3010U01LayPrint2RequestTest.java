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
public class CplsCPL3010U01LayPrint2RequestTest {
	@Autowired
	protected Vertx vertx;
	@Test
	public void cplsCPL3010U01LayPrint2RequestTest() throws InterruptedException {
		CplsServiceProto.CPL3010U01LayPrint2Request request = CplsServiceProto.CPL3010U01LayPrint2Request
				.newBuilder()
				//.setCbxJubsuDateChecked(false)
				.setFromPartJubsuDate("1990/01/01")
				.setFromSeq("fadsf")
				.setToPartJubsuDate("1991/01/01")
				.setToSeq("fsaf")
				.setFromSpecimenSer("fadsfd")
				.setToSpecimenSer("fadsffd")
				.build();
		Rpc.RpcMessage rpcMessage = Rpc.RpcMessage
				.newBuilder()
				.setId(System.currentTimeMillis())
				.setService("patientInsurance")
				.setVersion("1.0.0")
				.setPayloadClass(
						CplsServiceProto.CPL3010U01LayPrint2Request.class
								.getSimpleName())
				.setPayloadData(request.toByteString()).build();
		final CountDownLatch latch = new CountDownLatch(1);
		vertx.eventBus()
				.send(CplsServiceProto.CPL3010U01LayPrint2Request.class
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