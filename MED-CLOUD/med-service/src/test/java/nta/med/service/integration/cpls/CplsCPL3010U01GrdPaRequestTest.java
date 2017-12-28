package nta.med.service.integration.cpls;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsModelProto.CPL3010U01PrCplInsertCpl9000Info;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U01PrCplInsertCpl9000Request;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.XrtsServiceProto;

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
public class CplsCPL3010U01GrdPaRequestTest {

	@Autowired
	protected Vertx vertx;

	@Test
	public void cplsCPL3010U01GrdPaRequestTest() throws InterruptedException {
		CPL3010U01PrCplInsertCpl9000Info.Builder info =  CPL3010U01PrCplInsertCpl9000Info.newBuilder();
		info.setIraiKey("1401080618000036326");
		info.setBunho("000036326");
		info.setPartJubsuDate("2014/01/08");
		info.setPartJubsuTime("0618");
		info.setGubun("01");
		info.setCenterCode("SAN");
		
		
		XrtsServiceProto.XRT0201U00GrdRadioListRequest request = XrtsServiceProto.XRT0201U00GrdRadioListRequest
				.newBuilder()
				.setOrderDate("2014/09/12")
				.setBunho("000043488")
				.setInOutGubun("I")
				.build();
		Rpc.RpcMessage rpcMessage = Rpc.RpcMessage
				.newBuilder()
				.setId(System.currentTimeMillis())
				.setService("patientInsurance")
				.setVersion("1.0.0")
				.setPayloadClass(
						XrtsServiceProto.XRT0201U00GrdRadioListRequest.class
								.getSimpleName())
				.setPayloadData(request.toByteString()).build();
		final CountDownLatch latch = new CountDownLatch(1);
		vertx.eventBus()
				.send(XrtsServiceProto.XRT0201U00GrdRadioListRequest.class
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

