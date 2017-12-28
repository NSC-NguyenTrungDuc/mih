package nta.med.service.integration.nuro;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class RES1001U00MapingCodeTest extends MessageRequestTest{

	@Test
	public void testRES1001U00MapingCode() throws InterruptedException{
		
		NuroServiceProto.RES1001U00MapingCodeRequest request = NuroServiceProto.RES1001U00MapingCodeRequest
				.newBuilder()
				.setGwa("")
				.setDoctor("")
				.build();
		
        sentRequestToMedApp(request, NuroServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
		
	}
	
}
