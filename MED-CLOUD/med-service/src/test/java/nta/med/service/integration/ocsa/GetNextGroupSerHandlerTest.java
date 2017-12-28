package nta.med.service.integration.ocsa;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class GetNextGroupSerHandlerTest extends MessageRequestTest {

	@Test
	public void test() throws InterruptedException{
		SystemServiceProto.GetNextGroupSerRequest.Builder request = SystemServiceProto.GetNextGroupSerRequest.newBuilder()
				.setBunho("000114130")
				.setPkKey("135")
				.setInputTab("01")
				.setKeyObj("OCS2003");
		
		sentRequestToMedApp(request.build(), SystemServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
	}
}
