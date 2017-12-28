package nta.med.service.integration.system;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class CheckHideButtonHandlerTest extends MessageRequestTest {

	@Test
	public void testCheckHideButtonHandler() throws InterruptedException {
		SystemServiceProto.CheckHideButtonRequest request = SystemServiceProto.CheckHideButtonRequest.newBuilder()
				.setCodeType("BR_CODE").build();

		sentRequestToMedApp(request, SystemServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));

	}

}
