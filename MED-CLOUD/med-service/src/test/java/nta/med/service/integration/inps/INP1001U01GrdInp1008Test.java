package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INP1001U01GrdInp1008Test extends MessageRequestTest{

	@Test
	public void test () throws Exception{
		
		InpsServiceProto.INP1001U01GrdInp1008Request request = InpsServiceProto.INP1001U01GrdInp1008Request.newBuilder()
				.setPkinp1002("12345")
				.setBunho("000000120")
				.setGubun("G")
				.setIpwonDate("2016/04/30")
				.setGubunIpwonDate("2016/04/30")
				.setPageNumber("1")
				.setOffset("10")
				.build();
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
