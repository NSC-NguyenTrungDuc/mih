package nta.med.service.integration.system;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OBIsCPPatientTest extends MessageRequestTest {

	@Test
	public void test() throws InterruptedException {
		SystemServiceProto.OBIsCPPatientRequest request = SystemServiceProto.OBIsCPPatientRequest.newBuilder()
				.setFkinp1001("1978.0")
				.build();

		sentRequestToMedApp(request, SystemServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
