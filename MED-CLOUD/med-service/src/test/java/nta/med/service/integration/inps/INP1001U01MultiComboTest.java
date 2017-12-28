package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INP1001U01MultiComboTest extends MessageRequestTest{

	@Test
	public void test () throws Exception{
		
		InpsServiceProto.INP1001U01MultiComboRequest request = InpsServiceProto.INP1001U01MultiComboRequest.newBuilder()
				//.setKaikeiHodong("T")
				.build();
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
