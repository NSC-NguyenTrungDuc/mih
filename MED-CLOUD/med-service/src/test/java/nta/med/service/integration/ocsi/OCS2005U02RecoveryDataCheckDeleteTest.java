package nta.med.service.integration.ocsi;

import org.junit.Test;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2005U02RecoveryDataCheckDeleteTest extends MessageRequestTest{
	@Test
	public void Test() throws Exception{
		OcsiServiceProto.OCS2005U02RecoveryDataCheckDeleteRequest request = OcsiServiceProto.OCS2005U02RecoveryDataCheckDeleteRequest.newBuilder()
				.setPkocs2005("43842")
				.setDrtFromDate("2016/10/10")
				.setDrtToDate("2016/12/12")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
