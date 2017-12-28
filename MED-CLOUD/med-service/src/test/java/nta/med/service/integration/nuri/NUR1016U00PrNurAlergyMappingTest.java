package nta.med.service.integration.nuri;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

import nta.med.core.glossary.DataRowState;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;

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
public class NUR1016U00PrNurAlergyMappingTest {
	@Autowired
	protected Vertx vertx;

	@Test
	public void nUR1016U00PrNurAlergyMappingTest() throws InterruptedException {
		NuriModelProto.NUR1016U00GrdNUR1016ListItemInfo.Builder info = NuriModelProto.NUR1016U00GrdNUR1016ListItemInfo.newBuilder();
	    info.setPknur1016("6");
	    info.setBunho("123");
	    info.setAllergyGubun("AL");
	    info.setAllergyInfo("ALLERGY_INII");
	    info.setStartDate("2012/3/3");
	    info.setEndDate("9998/12/31");
	    info.setEndSayu("SA");
	    info.setInputText("INPUT_TEXT");
	    info.setYValue( "Y");
	    info.setRowState(DataRowState.DELETED.toString());

		NuriServiceProto.NUR1016U00PrNurAlergyMappingRequest request = NuriServiceProto.NUR1016U00PrNurAlergyMappingRequest
				.newBuilder()
				.addGrdNUR1016List(info)
				.setBunho("")
				.setUserId("")
				.setTableId("")
				.build();
		Rpc.RpcMessage rpcMessage = Rpc.RpcMessage
				.newBuilder()
				.setId(System.currentTimeMillis())
				.setService("patientInsurance")
				.setVersion("1.0.0")
				.setPayloadClass(
						NuriServiceProto.NUR1016U00PrNurAlergyMappingRequest.class
								.getSimpleName())
				.setPayloadData(request.toByteString()).build();
		final CountDownLatch latch = new CountDownLatch(1);
		vertx.eventBus()
				.send(NuriServiceProto.NUR1016U00PrNurAlergyMappingRequest.class
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

