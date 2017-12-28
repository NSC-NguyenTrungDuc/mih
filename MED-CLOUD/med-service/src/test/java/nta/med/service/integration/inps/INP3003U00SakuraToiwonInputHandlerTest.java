package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INP3003U00SakuraToiwonInputHandlerTest extends MessageRequestTest {
	@Test
	public void test () throws Exception{
		
		InpsServiceProto.INP3003U00SakuraToiwonInputRequest request = InpsServiceProto.INP3003U00SakuraToiwonInputRequest.newBuilder()
				.setPkinp1001("1608093")
				.build();
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}

}
