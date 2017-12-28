package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INP1001U01DoubleGrdINP1008InfoHandlerTest extends MessageRequestTest {
	@Test
	public void test() throws Exception {

		InpsServiceProto.INP1001U01DoubleGrdINP1008Request request = InpsServiceProto.INP1001U01DoubleGrdINP1008Request.newBuilder()	
				.setBunho("000014277")
				.setFkinp1002("0")
				.setIpwonDate("2016/8/10")
				.setGubunIpwonDate("2016/8/11")	
				.setGubun("01")
				.build();
		
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	
		}
}