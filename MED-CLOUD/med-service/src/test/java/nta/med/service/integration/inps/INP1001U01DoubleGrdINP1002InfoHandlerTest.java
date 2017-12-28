package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INP1001U01DoubleGrdINP1002InfoHandlerTest extends MessageRequestTest {
	@Test
	public void test() throws Exception {

		InpsServiceProto.INP1001U01DoubleGrdINP1002Request request = InpsServiceProto.INP1001U01DoubleGrdINP1002Request
				.newBuilder().setBunho("000003227").setGubunIpwonDate("2016/8/6").setExistDoubleType("Y")
				.setDoublePkinp1001("1607391").build();
		
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
