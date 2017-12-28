package nta.med.service.integration.xrts;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

import nta.med.common.remoting.rpc.protobuf.Rpc;
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
public class XRT0001U00ExecuteCase1RequestTest {
	@Autowired
	protected Vertx vertx;
	@Test
	public void xRT0001U00ExecuteCase1RequestTest() throws InterruptedException {
//		XrtsServiceProto.XRT0001U00ExecuteCase1Request request = XrtsServiceProto.XRT0001U00ExecuteCase1Request
//				.newBuilder()
//				.setRowState("Deleted")
//				.setUserId("test")
//				.setXrayCode("test")
//				.setXrayName("test")
//				.setXrayRoom("test")
//				.setXrayGubun("t")
//				.setXrayBuwi("test")
//				.setXrayBuwiKaikei("test")
//				.setXrayBuwiTong("test")
//				.setXrayCnt("123456")
//				.setNamePrintYn("Y")
//				.setSugaCode("123")
//				.setSpecialYn("Y")
//				.setXrayName2("test")
//				.setXrayRealCnt("12345647")
//				.setSlipCode("123")
//				.setReserType("t")
//				.setJaeryoYn("Y")
//				.setSort("test")
//				.setXrayWay("t")
//				.setTongGubun("test")
//				.setRequestYn("Y")
//				.setModality("test")
//				.setFrequentUseYn("Y")
//				.setTubeVol("test")
//				.setTubeCur("test")
//				.setXrayTime("test")
//				.setTubeCurTime("test")
//				.setIrradiationTime("test 1")
//				.setXrayDistance("test 1")
//				.build();
//		
//		Rpc.RpcMessage rpcMessage = Rpc.RpcMessage
//				.newBuilder()
//				.setId(System.currentTimeMillis())
//				.setService("patientInsurance")
//				.setVersion("1.0.0")
//				.setPayloadClass(
//						XrtsServiceProto.XRT0001U00ExecuteCase1Request.class
//								.getSimpleName())
//				.setPayloadData(request.toByteString()).build();
//		final CountDownLatch latch = new CountDownLatch(1);
//		vertx.eventBus()
//				.send(XrtsServiceProto.XRT0001U00ExecuteCase1Request.class
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
