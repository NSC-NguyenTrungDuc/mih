package nta.med.service.integration.nuro;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.integration.MessageRequestTest;

/**
 * @author DEV-NgocNV
 *
 */

public class OUT0101U02ChangePWDTest extends MessageRequestTest {
	@Test
	public void testOUT0101U02ChangePWDHandlerTest() throws Exception {
		NuroServiceProto.OUT0101U02ChangePWDRequest request = NuroServiceProto.OUT0101U02ChangePWDRequest.newBuilder()
				.setBunho("000100001")
				.setPwd("")
				.build();
		sentRequestToMedApp(request, NuroServiceProto.getDescriptor().getOptions().getExtension(Rpc.service)); 
	}
}
