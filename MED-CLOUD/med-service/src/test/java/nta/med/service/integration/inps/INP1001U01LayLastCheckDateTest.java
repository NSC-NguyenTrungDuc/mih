package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INP1001U01LayLastCheckDateTest extends MessageRequestTest{

	@Test
	public void test () throws Exception{
		
		InpsServiceProto.INP1001U01LayLastCheckDateRequest request = InpsServiceProto.INP1001U01LayLastCheckDateRequest.newBuilder()
				.setBunho("000000011")
				.setGubun("04")
				.setDate("2016/11/01")
				.build();
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
