package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INP1001U01GrdOut0106Test extends MessageRequestTest{

	@Test
	public void test() throws Exception{
		InpsServiceProto.INP1001U01GrdOut0106Request request = InpsServiceProto.INP1001U01GrdOut0106Request.newBuilder()
				.setBunho("000000056")
				.setPageNumber("1")
				.setOffset("10")
				.build();
		
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
	
}
