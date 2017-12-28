package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2003Q02xEditGridCellTest extends MessageRequestTest {

	@Test
	public void test() throws Exception {
		OcsiServiceProto.OCS2003Q02xEditGridCellRequest request = OcsiServiceProto.OCS2003Q02xEditGridCellRequest
				.newBuilder().build();
		
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
