package nta.med.service.integration.xrts;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import org.vertx.java.core.Vertx;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(locations = { "classpath:META-INF/spring/spring-master.xml" })
public class XRT0122U00TransactionalTest {
	@Autowired
	protected Vertx vertx;

	@Test
	public void nUR1016U00PrNurAlergyMappingTest() throws InterruptedException {
//		XrtsModelProto.XRT0122U00grdMCodeListItemInfo.Builder info = XrtsModelProto.XRT0122U00grdMCodeListItemInfo.newBuilder();
//	    info.setBuwiBunryu("H");
//	    info.setBuwiBunryuName("TEST1");
//	    info.setDataRowState(DataRowState.DELETED.toString());
//	    
//	    XrtsModelProto.XRT0122U00grdDCodeListItemInfo.Builder info1 = XrtsModelProto.XRT0122U00grdDCodeListItemInfo.newBuilder();
//	    info1.setBuwiBunryu("H1");
//	    info1.setBuwiCode("12");
//	    info1.setBuwiName("TEST1");
//	    info1.setSortSeq("1");
//	    info1.setKey("1");
//	    info1.setDataRowState(DataRowState.DELETED.toString());
//		XrtsServiceProto.XRT0122U00TransactionalRequest request = XrtsServiceProto.XRT0122U00TransactionalRequest
//				.newBuilder()
//				.addGrdDCodeList(info1)
//				.setUserId("HIE")
//				.build();
//		Rpc.RpcMessage rpcMessage = Rpc.RpcMessage
//				.newBuilder()
//				.setId(System.currentTimeMillis())
//				.setService("patientInsurance")
//				.setVersion("1.0.0")
//				.setPayloadClass(
//						XrtsServiceProto.XRT0122U00TransactionalRequest.class
//								.getSimpleName())
//				.setPayloadData(request.toByteString()).build();
//		final CountDownLatch latch = new CountDownLatch(1);
//		vertx.eventBus()
//				.send(XrtsServiceProto.XRT0122U00TransactionalRequest.class
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
	}
}

